using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KdTree;
using KdTree.Math;
using procgenart_core;

namespace all_rgb
{
	public interface IAction
	{
		void Run();
		void Pause();
		void Abort();

		IProgress<ProgressReport> Progress { get; }

		Action<IProgress<ProgressReport>> Action { get; init; }
	}

	public class AllRGBGenerator
	{
		public AllRGBGenerator()
		{
			// todo: read this list from UI
			// save/reload this list as config
			pixelSelectorDelegates.Add(ColourAlgorithms.RGBandHSB);
			//pixelSelectorDelegates.Add(DistanceAlgorithms.DistanceFromCenter);
			//pixelSelectorDelegates.Add(NeighbourAlgorithms.AddMaxAgain);
		}

		public List<Colour> Colours = new();
		public bool UseMin;

		public static Image GetImageFromColours(List<Colour> colours, int width, int height)
		{
			var img = new ImageBuffer(width, height);
			var coloursPerPixel = (float)colours.Count / (width * height);
			var i = 0;
			var colourCounter = 0f;

			while (i < width * height && colourCounter < colours.Count)
			{
				img.SetPixel(
					i % width,
					i / width,
					colours[(int)colourCounter]);

				colourCounter += coloursPerPixel;
				++i;
			}

			return img.GetImage();
		}

		private static List<Colour> SortColoursRGB(List<Colour> colours, RGBComparerComponents rgbComponents)
		{
			if (rgbComponents != RGBComparerComponents.Empty)
			{
				colours.Sort(new RGBComponentColorComparer(rgbComponents));
			}
			else
			{
				colours = colours
					.OrderBy(c => c.R)
					.ThenBy(c => c.G)
					.ThenBy(c => c.B)
					.ToList();
			}

			return colours;
		}

		private static List<Colour> SortColoursHSB(List<Colour> colours, HSBComparerComponents hsbComponents)
		{
			//IComparer<Colour> comparer = hsbComponents != HSBComparerComponents.Empty
			//	? new HSBComponentColorComparer(hsbComponents)
			//	: new HSBSumColorComparer();

			//colours.Sort(comparer);

			if (hsbComponents.HasFlag(HSBComparerComponents.Hue))
			{
				var result = colours.OrderBy(c => c.Hue);

				if (hsbComponents.HasFlag(HSBComparerComponents.Saturation))
				{
					result = result.ThenBy(c => c.Saturation);
				}

				if (hsbComponents.HasFlag(HSBComparerComponents.Brightness))
				{
					result = result.ThenBy(c => c.Brightness);
				}

				return result.ToList();
			}
			else if (hsbComponents.HasFlag(HSBComparerComponents.Saturation))
			{
				var result = colours.OrderBy(c => c.Saturation);
				if (hsbComponents.HasFlag(HSBComparerComponents.Brightness))
				{
					result = result.ThenBy(c => c.Brightness);
				}

				if (hsbComponents.HasFlag(HSBComparerComponents.Hue))
				{
					result = result.ThenBy(c => c.Hue);
				}

				return result.ToList();
			}
			else if (hsbComponents.HasFlag(HSBComparerComponents.Brightness))
			{
				var result = colours.OrderBy(c => c.Brightness);
				if (hsbComponents.HasFlag(HSBComparerComponents.Saturation))
				{
					result = result.ThenBy(c => c.Saturation);
				}

				if (hsbComponents.HasFlag(HSBComparerComponents.Hue))
				{
					result = result.ThenBy(c => c.Hue);
				}

				return result.ToList();
			}

			return colours;
		}

		private static List<Colour> SortColoursNNKDTree(List<Colour> colours)
		{
			var tree = new KdTree<float, Colour>(3, new FloatMath());
			List<Colour> result = new();
			var curr = colours[0];

			// add to tree
			foreach (var c in colours.Skip(1))
			{
				_ = tree.Add(new float[] { c.R, c.G, c.B }, c);
			}

			// construct result
			result.Add(curr);
			var currIndex = new float[3];
			currIndex[0] = curr.R;
			currIndex[1] = curr.G;
			currIndex[2] = curr.B;

			while (tree.Count > 0)
			{
				var neighbour = tree.GetNearestNeighbours(currIndex, 1);
				curr = neighbour[0].Value;
				result.Add(curr);
				currIndex[0] = curr.R;
				currIndex[1] = curr.G;
				currIndex[2] = curr.B;
				tree.RemoveAt(currIndex);
			}

			Trace.Assert(result.Count == colours.Count);
			return result;
		}

		public Image GetCurrentImage()
			=> CurrentBuffer.GetImage();

		public void BufferFromImage(Bitmap image)
		{
			Frontier.Clear();
			CreateBuffer(image.Width, image.Height);

			for (var y = 0; y < image.Height; ++y)
			{
				for (var x = 0; x < image.Width; ++x)
				{
					CurrentBuffer.SetPixel(new Point(x, y), Colour.FromSystemColor(image.GetPixel(x, y)));
				}
			}
		}

		public void CreateTemplate(Bitmap templateImage)
		{
			Frontier.Clear();
			CreateBuffer(templateImage.Width, templateImage.Height);

			for (var y = 0; y < templateImage.Height; ++y)
			{
				for (var x = 0; x < templateImage.Width; ++x)
				{
					if (Colour.FromSystemColor(templateImage.GetPixel(x, y)) == Colour.FromSystemColor(Color.Black))
					{
						_ = Frontier.Add(new Point(x, y));
					}
				}
			}
		}

		public void CreatePalette(Bitmap paletteImage)
		{
			Frontier.Clear();
			var imgBuf = new ImageBuffer(paletteImage);
			var colours = new HashSet<Colour>();

			for (var y = 0; y < imgBuf.Height; ++y)
			{
				for (var x = 0; x < imgBuf.Width; ++x)
				{
					_ = colours.Add(imgBuf.GetPixel(x, y));
				}
			}

			Colours = colours.ToList();
		}

		public void CreateBuffer(int width = 128, int height = 128)
			=> CurrentBuffer = new ImageBuffer(width, height);

		public enum GenSaveOptions
		{
			Palette, Image
		}

		public void Save(GenSaveOptions options)
		{
			switch (options)
			{
				case GenSaveOptions.Palette:
					SavePalette();
					break;
				case GenSaveOptions.Image:
					CurrentBuffer.Save();
					break;
			}
		}

		void SavePalette()
		{
			var paletteBuffer = new ImageBuffer(CurrentBuffer.Width, CurrentBuffer.Height);
			var count = 0;
			foreach (var c in Colours)
			{
				paletteBuffer.SetPixel(count % CurrentBuffer.Width, count / CurrentBuffer.Width, c);
				count++;
			}

			paletteBuffer.Save();
		}

		#region PaletteSelection

		public static List<Colour> ReverseColours(List<Colour> colours)
		{
			colours.Reverse();
			return colours;
		}

		public static List<Colour> ShuffleColours(List<Colour> colours, float percentToDeviate = 1f, int skip = 1)
		{
			colours.Shuffle(percentToDeviate, skip);
			return colours;
		}

		public enum SortType { RGB, HSB, NN };

		public static List<Colour> SortColours(List<Colour> colours, SortType sortType, RGBComparerComponents? rgbComparerComponents = null, HSBComparerComponents? hsbComparerComponents = null)
			=> sortType switch
			{
				SortType.RGB => SortColoursRGB(colours, rgbComparerComponents.Value),
				SortType.HSB => SortColoursHSB(colours, hsbComparerComponents.Value),
				SortType.NN => SortColoursNNKDTree(colours),
				_ => throw new NotImplementedException(),
			};

		#endregion

		public ImageBuffer CurrentBuffer { get; private set; }

		public Task<Image> Paint(PaintParams paintParams)
		{
			var progress = new Progress<ProgressReport>(value => ProgressCallback(value));
			PaintTask = Task.Run(() => Paint(progress, Colours, paintParams));
			return PaintTask;
		}

		public Task<Image> PaintTask;

		public Action<ProgressReport> ProgressCallback = new((_) => { });

		public bool Pause { get; set; }

		public bool Abort { get; private set; }

		public void AbortPaint() => Abort = true;

		readonly HashSet<Point> Frontier = new();

		static readonly ProgressReport BaseRecord = new(0f, "Forever", null, "Unknown", 0f);

		Image Paint(IProgress<ProgressReport> progress, List<Colour> cols, PaintParams paintParams)
		{
			var size = (int)Math.Sqrt(cols.Count);
			if (CurrentBuffer == null)
			{
				CurrentBuffer = new ImageBuffer(size, size);
			}
			else
			{
				CurrentBuffer.Clear();
			}

			Abort = false;

			Console.WriteLine("Painting");

			var counter = 0;
			var refreshRate = size * 2;

			var swTotal = new Stopwatch();
			swTotal.Start();

			var swBatch = new Stopwatch();
			swBatch.Start();

			// prefilling spots
			if (paintParams.SeedType == SeedType.Random)
			{
				var rnd = new Random();
				for (var i = 0; i < paintParams.SeedCount; i++)
				{
					var randomPoint = new Point(rnd.Next(CurrentBuffer.Width), rnd.Next(CurrentBuffer.Height));
					CurrentBuffer.SetPixel(randomPoint, cols[i]);
					UpdateFrontier(randomPoint);
				}

				cols = cols.Skip(paintParams.SeedCount).ToList();
			}
			else if (paintParams.SeedType == SeedType.Centre)
			{
				CurrentBuffer.SetPixel(CurrentBuffer.Middle, cols[0]);
				UpdateFrontier(CurrentBuffer.Middle);
			}

			cols = cols.Skip(1).ToList();

			using (var consoleProgressBar = new ConsoleProgressBar())
			{
				Point bestXY;

				foreach (var col in cols)
				{
					#region Abort

					if (Abort)
					{
						var abortStr = $"Aborted at {swTotal.Elapsed:g}";
						progress.Report(BaseRecord with { Percent = 1f, ETAText = abortStr, ProgressReportImage = GetCurrentImage() });
						break;
					}

					#endregion

					#region Pause

					while (Pause)
					{
						swTotal.Stop();
						Thread.Sleep(50);
						_ = Thread.Yield();
					}

					if (!swTotal.IsRunning)
					{
						swTotal.Start();
					}

					#endregion

					var avgDistance = Frontier.Sum((p) => MathsHelpers.DistanceEuclidean(p, CurrentBuffer.Middle));
					avgDistance /= CurrentBuffer.Radius * Frontier.Count; // scale to 0-1 range

					bestXY = Frontier
						.AsParallel()
						.OrderByDescending(xy => GetNearestColourFromAlgos(CurrentBuffer, xy, col, paintParams, avgDistance, pixelSelectorDelegates))
						.First();

					CurrentBuffer.SetPixel(bestXY, col);
					_ = Frontier.Remove(bestXY);
					UpdateFrontier(bestXY);

					counter++;

					var percentDone = (float)counter / cols.Count;
					if (counter % refreshRate == 0)
					{
						var timeElapsed = swTotal.ElapsedMilliseconds;
						var eta = (1f / percentDone * timeElapsed) - timeElapsed;
						var ts = new TimeSpan(0, 0, 0, 0, (int)eta);
						var timeStr = $"Elapsed={swTotal.Elapsed:g} ETA={ts:g} Progress={percentDone:P}";

						consoleProgressBar.Report(percentDone, timeStr);
						progress.Report(BaseRecord with
						{
							Percent = percentDone,
							ETAText = timeStr,
							ProgressReportImage = counter % refreshRate == 0 ? GetCurrentImage() : null,
							BatchInfo = $"BatchSize={refreshRate} BatchTime={swBatch.ElapsedMilliseconds}ms FrontierSize={Frontier.Count}",
							CurrentAverageRadius = avgDistance * CurrentBuffer.Radius, // put from 0-1 to 0-radius
						});

						swBatch.Restart();
					}
				}

				swTotal.Stop();
				var doneStr = $"Done in {swTotal.Elapsed:g}";
				consoleProgressBar.Report(1, doneStr);
				progress.Report(BaseRecord with { Percent = 1f, ETAText = doneStr, ProgressReportImage = GetCurrentImage() });
			}

			swTotal.Reset();
			Frontier.Clear();

			var img = GetCurrentImage();
			if (!Abort)
			{
				Save(GenSaveOptions.Image); // autosave a completed image
			}

			return img;

			void UpdateFrontier(Point newPixel)
			{
				foreach (var nxy in Utilities.GetNonEmptyNeighbourPoints(CurrentBuffer, newPixel))
				{
					_ = Frontier.Add(nxy);
				}
			}
		}

		readonly List<PixelSelectorDelegate> pixelSelectorDelegates = new();

		static float GetNearestColourFromAlgos(ImageBuffer buf, Point xy, Colour c, PaintParams paintParams, float avgDistanceFromCentre, List<PixelSelectorDelegate> algos)
		{
			// get the diffs for each neighbour separately
			var diffs = new List<float>(8);

			foreach (var algo in algos)
			{
				algo(buf, xy, c, paintParams, avgDistanceFromCentre, ref diffs);
			}

			// average or minimum selection
			return paintParams.NearestColourSelector switch
			{
				NearestColourSelector.Min => (float)diffs.Min(),
				NearestColourSelector.Max => (float)diffs.Max(),
				NearestColourSelector.Sum => (float)diffs.Sum(),
				NearestColourSelector.Average => (float)diffs.Average(),
				_ => throw new NotImplementedException(),
			};
		}
	}
}
