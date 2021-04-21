using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using KdTree;

namespace all_rgb
{
	public class AllRGBGenerator
	{
		public AllRGBGenerator()
		{ }

		public List<Color> ShuffledColours;
		HashSet<Color> SetOfAllColours;
		ImageBuffer buffer;

		public bool UseMin;

		public Image GetPalette()
		{
			var img = new Bitmap(1, SetOfAllColours.Count);
			var i = 0;
			foreach (var c in SetOfAllColours)
			{
				img.SetPixel(0, i++, c);
			}
			return img;
		}

		public Image GetShuffledPalette()
		{
			var img = new Bitmap(1, ShuffledColours.Count);
			var i = 0;
			foreach (var c in ShuffledColours)
			{
				img.SetPixel(0, i++, c);
			}
			return img;
		}

		public void Run()
		{
			CreateBuffer();

			GenerateColours();

			ShuffleColours();

			Paint();

			Save();
		}

		public Image GetCurrentImage()
		{
			return buffer.GetImage();
		}

		public void CreateBuffer(int width = 64, int height = 64)
		{
			buffer = new ImageBuffer(width, height);
		}

		public void Save()
		{
			buffer.Save();
		}


		public void ShuffleColours()
		{
			Console.WriteLine("Shuffling");
			ShuffledColours = SetOfAllColours.ToList();
			ShuffledColours.Shuffle();
		}

		public void GenerateColours()
		{
			Console.WriteLine("Generating colours");

			var pixelCount = buffer.Width * buffer.Height;

			if (pixelCount == 0)
			{
				Console.WriteLine("no pixels");
				return;
			}

			SetOfAllColours = new HashSet<Color>(pixelCount);

			var stepsPerChannel = (int)Math.Round(Math.Pow(pixelCount, 1f / 3f));
			var rSteps = stepsPerChannel;
			var gSteps = stepsPerChannel;
			var bSteps = stepsPerChannel;

			{
				for (var r = 0; r < rSteps; ++r)
				{
					for (var g = 0; g < gSteps; ++g)
					{
						for (var b = 0; b < bSteps; ++b)
						{
							var c = Color.FromArgb(
								255,
								255 / (rSteps - 1) * r,
								255 / (gSteps - 1) * g,
								255 / (bSteps - 1) * b);

							if (!SetOfAllColours.Add(c))
							{
								Trace.Assert(false, "duplicate colour detected", c.ToString());
							}
						}
					}
				}
			}

			var rnd = new Random(1);
			// leftover
			while (SetOfAllColours.Count < pixelCount)
			{
				SetOfAllColours.Add(Color.FromArgb(
					255,
					rnd.Next(0, 255),
					rnd.Next(0, 255),
					rnd.Next(0, 255)));
			}

			Trace.Assert(SetOfAllColours.Count == pixelCount);
		}

		public void ClearSeenPoints()
		{
			buffer?.Clear();
		}

		public void Paint()
		{
			var progress = new Progress<int>(value => ProgressCallback(value));
			Task.Run(() => Paint(buffer, ShuffledColours, progress)).Wait();
		}

		public Action<int> ProgressCallback = new((_) => { });

		void Paint(ImageBuffer buf, List<Color> cols, IProgress<int> progress)
		{
			Console.WriteLine("Painting");

			var counter = 0;
			var available = new HashSet<Point>();
			var availableTree = new KdTree<int, (Color col, Point xy)>(3, new KdTree.Math.IntMath());

			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var allCols = new KdTree<int, Color>(3, new KdTree.Math.IntMath());
			foreach (var col in cols)
			{
				_ = allCols.Add(new int[] { col.R, col.G, col.B }, col);
			}

			using (var pb = new ProgressBar())
			{
				foreach (var col in cols)
				{
					Point bestXY;
					//int[] kdtreepoint = null;
					KdTreeNode<int, (Color col, Point xy)> node = new KdTreeNode<int, (Color col, Point xy)>();

					if (available.Count == 0)
					{
						bestXY = buf.Middle;
					}
					else
					{
						// this is the time consumer
						// it has to search everything in the available queue for every pixel we place
						// optimising this would be a big win
						// maybe use an octree to store where in 3d space each colour in the queue is located,
						// and this wil mean instead of searching every colour O(n) we can get O(log(n)), at
						// the cost of sorting, but if octree insertion is quick, this could be minimal

						//bestXY = available
						//	.AsParallel()
						//	.OrderBy(xy => GetNearestColour(buf, xy, col, UseMin))
						//	.First();

						node = availableTree.GetNearestNeighbours(new int[] { col.R, col.G, col.B }, 1).FirstOrDefault();
						bestXY = node.Value.xy;
						//kdtreepoint = node.Point;
					}

					//if (counter++ % 256 == 0)
					//{
					//	Console.WriteLine("{0:P}, queue size {1}", (double)counter / buf.NumberOfPixels, available.Count);
					//	// save checkpoint
					//	buf.Save(counter / 256);
					//}

					buf.SetPixel(bestXY, col);
					available.Remove(bestXY);
					if (node.Point != null)
					{
						availableTree.RemoveAt(node.Point);
						allCols.RemoveAt(node.Point);
					}

					// add neighbours
					foreach (var nxy in GetNeighbours(buf, bestXY))
					{
						if (buf.IsEmpty(nxy))
						{
							_ = available.Add(nxy);

							var avg = GetAverageColour(buf, nxy);
							var closestAvailable = allCols.GetNearestNeighbours(new int[] { avg.R, avg.G, avg.B }, 1).FirstOrDefault();
							//if (closestAvailable == null)
							//	continue;
							//allCols.RemoveAt(closestAvailable.Point);
							_ = availableTree.Add(new int[] { closestAvailable.Value.R, closestAvailable.Value.G, closestAvailable.Value.B }, (col, nxy));
						}
					}

					counter++;

					var percentDone = (float)counter / cols.Count;
					if (counter % 100 == 0)
					{
						var timeElapsed = stopwatch.ElapsedMilliseconds;
						var eta = 1f / percentDone * timeElapsed;
						var timeStr = $"Elapsed={timeElapsed / 1000}s ETA={(int)(eta / 1000)}s Fine%={percentDone:P}";
						//Console.Title = timeStr;
						pb.Report(percentDone, timeStr);
					}
					progress.Report((int)percentDone);
				}
			}

			stopwatch.Reset();
		}

		static int GetNearestColour(ImageBuffer buf, Point xy, Color c, bool UseMin)
		{
			// get the diffs for each neighbor separately
			var diffs = new List<int>(8);
			foreach (var nxy in GetNeighbours(buf, xy))
			{
				var pixel = buf.GetPixel(nxy);
				if (!pixel.IsEmpty)
				{
					diffs.Add(Distance(pixel, c));
				}
			}

			// average or minimum selection
			return UseMin
				? (int)diffs.Average()
				: diffs.Min();
		}

		static Color GetAverageColour(ImageBuffer buf, Point xy)
		{
			// get the diffs for each neighbor separately
			(int R, int G, int B) diff = (0, 0, 0);
			var count = 0;

			foreach (var nxy in GetNeighbours(buf, xy))
			{
				var pixel = buf.GetPixel(nxy);
				if (!pixel.IsEmpty)
				{
					diff.R += pixel.R;
					diff.G += pixel.G;
					diff.B += pixel.B;
					count++;
				}
			}

			if (count == 0)
			{
				return Color.White;
			}

			return Color.FromArgb(diff.R / count, diff.G / count, diff.B / count);

			// average or minimum selection
			//return UseMin
			//	? (int)diffs.Average()
			//	: diffs.Min();
		}

		static IEnumerable<Point> GetNeighbours(ImageBuffer buf, Point p)
		{
			for (var x = -1; x < 2; ++x)
			{
				for (var y = -1; y < 2; ++y)
				{
					if (p.X + x >= 0 && p.X + x < buf.Width && p.Y + y >= 0 && p.Y + y < buf.Height)
					{
						yield return new Point(p.X + x, p.Y + y);
					}
				}
			}
		}

		static int Distance(Color a, Color b)
			=> ((a.R - b.R) * (a.R - b.R))
			 + ((a.G - b.G) * (a.G - b.G))
			 + ((a.B - b.B) * (a.B - b.B));
	}

}
