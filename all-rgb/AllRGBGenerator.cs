using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace all_rgb
{
	public record ProgressReport(float percent, string etaText, Image prgi);

	public class AllRGBGenerator
	{
		public AllRGBGenerator()
		{ }

		public List<Colour> ColoursToUseInImage = new List<Colour>();
		public HashSet<Colour> GeneratedSetOfColours = new HashSet<Colour>();
		ImageBuffer buffer;

		public bool UseMin;

		public Image GetImageFromColours(List<Colour> colours, int width, int height)
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

		public static List<Colour> SortNN(List<Colour> colours)
		{
			List<Colour> output = new();
			if (!colours.Any())
			{
				return colours;
			}

			var curr = colours[0];

			while (colours.Count > 1)
			{
				output.Add(curr);
				_ = colours.Remove(curr);

				Colour nearest = default;
				var minDistance = float.MaxValue;
				for (var i = 1; i < colours.Count; ++i)
				{
					var distance = MathsHelpers.DistanceSquaredEuclidean(curr.rgb, colours[i].rgb);
					if (distance < minDistance)
					{
						minDistance = distance;
						nearest = colours[i];
					}
				}

				curr = nearest;
			}

			// should only be 1 colour left
			Trace.Assert(colours.Count == 1);
			output.Add(colours[0]);

			return output;
		}

		public void ConsoleRun()
		{
			CreateBuffer();

			GeneratedSetOfColours = ColourGenerator.GenerateColours_RGB_Uniform(buffer.Width * buffer.Height);

			//RefineColours(true, false);

			Paint();

			Save();
		}

		public Image GetCurrentImage()
			=> buffer.GetImage();

		public void CreateTemplate(Bitmap templateImage)
		{
			AvailableSet.Clear();
			CreateBuffer(templateImage.Width, templateImage.Height);

			for (var y = 0; y < templateImage.Height; ++y)
			{
				for (var x = 0; x < templateImage.Width; ++x)
				{
					if (Colour.FromSystemColor(templateImage.GetPixel(x, y)) == Colour.FromSystemColor(Color.Black))
					{
						_ = AvailableSet.Add(new Point(x, y));
					}
				}
			}
		}

		public void CreatePalette(Bitmap paletteImage)
		{
			AvailableSet.Clear();
			var imgBuf = new ImageBuffer(paletteImage);
			GeneratedSetOfColours.Clear();

			for (var y = 0; y < imgBuf.Height; ++y)
			{
				for (var x = 0; x < imgBuf.Width; ++x)
				{
					_ = GeneratedSetOfColours.Add(imgBuf.GetPixel(x, y));
				}
			}
		}

		public void CreateBuffer(int width = 128, int height = 128)
			=> buffer = new ImageBuffer(width, height);

		public void Save()
			=> buffer.Save();

		HashSet<Point> AvailableSet = new HashSet<Point>();

		#region PaletteSelection

		//public List<Colour> RefineColours(bool shuffle, bool reverse)
		//{
		//	Console.WriteLine("Refining");
		//	ShuffledColours = SetOfColours.ToList();

		//	//ShuffledColours = SortColoursRGB(ShuffledColours);
		//	//ShuffledColours = SortColoursHSB(ShuffledColours);
		//	//ShuffledColours = SortColoursNN(ShuffledColours);

		//	//ShuffledColours.Sort(new HSBComponentColorComparer(HSBComparerComponents.Saturation));

		//	if (reverse)
		//	{
		//		ShuffledColours.Reverse();
		//	}


		//	if (shuffle)
		//	{
		//		ShuffledColours.Shuffle();
		//	}

		//	//ShuffledColours.Sort((Colour a, Colour b)
		//	//		=>
		//	//		 a.GetHue().CompareTo(b.GetHue()) * 2
		//	//		 + a.GetSaturation().CompareTo(b.GetSaturation())
		//	//		 + b.GetBrightness().CompareTo(a.GetBrightness())
		//	//		);

		//	return ShuffledColours;
		//}

		public List<Colour> CopyColoursFromGenerated(List<Colour> colours)
		{
			return GeneratedSetOfColours.ToList();
		}

		public List<Colour> ReverseColours(List<Colour> colours)
		{
			colours.Reverse();
			return colours;
		}

		public List<Colour> ShuffleColours(List<Colour> colours)
		{
			colours.Shuffle();
			return colours;
		}

		public List<Colour> SortRGB(List<Colour> colours)
		{
			return colours.OrderBy(c => c.R).ThenBy(c => c.G).ThenBy(c => c.B).ToList();
		}

		public List<Colour> SortHSB(List<Colour> colours)
		{
			return colours.OrderBy(c => c.Hue).ThenBy(c => c.Brightness).ThenBy(c => c.Saturation).ToList();
		}

		#endregion

		public ImageBuffer CurrentBuffer => buffer;

		public Task<Image> Paint()
		{
			var progress = new Progress<ProgressReport>(value => ProgressCallback(value));
			PaintTask = Task.Run(() => Paint(ColoursToUseInImage ?? GeneratedSetOfColours.ToList(), progress), paintTokenSource.Token);
			return PaintTask;
		}

		public Task<Image> PaintTask;
		CancellationTokenSource paintTokenSource = new CancellationTokenSource();
		//CancellationToken paintToken;

		public Action<ProgressReport> ProgressCallback = new((_) => { });

		float PointOrderFunc(ImageBuffer buf, Point xy, Colour col, bool UseMin)
		{
			var c = GetNearestColour(buf, xy, col, UseMin);
			var d = MathsHelpers.DistanceEuclidean(xy, buf.Middle) / 4000000f;

			return c + d;
		}

		public bool Pause { get; set; }

		public void Abort()
		{
			paintTokenSource.Cancel();
		}

		Image Paint(List<Colour> cols, IProgress<ProgressReport> progress)
		{
			if (buffer == null)
			{
				var size = (int)Math.Sqrt(cols.Count);
				buffer = new ImageBuffer(size, size);
			}
			else
			{
				buffer.Clear();
			}

			Console.WriteLine("Painting");

			var counter = 0;

			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var baseRecord = new ProgressReport(0f, "Forever", null);

			using (var consoleProgressBar = new ConsoleProgressBar())
			{
				Point bestXY;

				foreach (var col in cols)
				{
					#region Pause

					while (Pause)
					{
						stopwatch.Stop();
						Thread.Yield();
					}

					if (!stopwatch.IsRunning)
					{
						stopwatch.Start();
					}

					#endregion

					#region Abort
					if (paintTokenSource.IsCancellationRequested)
					{
						var abortStr = $"Aborted at {stopwatch.Elapsed:g}";
						progress.Report(baseRecord with { percent = 1f, etaText = abortStr, prgi = GetCurrentImage() });
						break;
					}
					#endregion

					if (AvailableSet.Count == 0)
					{
						bestXY = buffer.Middle;
					}
					else
					{
						bestXY = AvailableSet
							.AsParallel()
							.OrderBy(xy => PointOrderFunc(buffer, xy, col, UseMin))
							.First();
					}

					buffer.SetPixel(bestXY, col);
					AvailableSet.Remove(bestXY);

					// add neighbours
					foreach (var nxy in GetNeighbours(buffer, bestXY))
					{
						if (buffer.IsEmpty(nxy))
						{
							_ = AvailableSet.Add(nxy);
						}
					}

					counter++;

					const int refreshRate = 256;

					var percentDone = (float)counter / cols.Count;
					if (counter % refreshRate == 0)
					{
						var timeElapsed = stopwatch.ElapsedMilliseconds;
						var eta = (1f / percentDone * timeElapsed) - timeElapsed;
						var ts = new TimeSpan(0, 0, 0, 0, (int)eta);
						var timeStr = $"Elapsed={stopwatch.Elapsed:g}s ETA={ts:g}s Progress={percentDone:P}";

						consoleProgressBar.Report(percentDone, timeStr);
						progress.Report(baseRecord with { percent = percentDone, etaText = timeStr, prgi = counter % refreshRate == 0 ? GetCurrentImage() : null });
					}
				}

				stopwatch.Stop();
				var doneStr = $"Done in {stopwatch.Elapsed:g}";
				consoleProgressBar.Report(1, doneStr);
				progress.Report(baseRecord with { percent = 1f, etaText = doneStr, prgi = GetCurrentImage() });
			}

			stopwatch.Reset();
			AvailableSet.Clear();

			// debug rect
			//buf.FillRect(0, 0, 40, 40, Colour.FromSystemColor(Color.White));

			return GetCurrentImage();
		}

		static float GetNearestColour(ImageBuffer buf, Point xy, Colour c, bool UseMin)
		{
			const float rgbWeight = 1f;
			const float hsbWeight = 0f;

			// get the diffs for each neighbor separately
			var diffs = new List<float>(8);
			foreach (var nxy in GetNeighbours(buf, xy))
			{
				// count empty neighbours and adjust weighting based on how many
				// more neighbours = higher weighting
				if (!buf.IsEmpty(nxy))
				{
					var pixel = buf.GetPixel(nxy);
					var rgb = MathsHelpers.DistanceSquaredEuclidean(pixel.rgb, c.rgb) * rgbWeight;
					var hsb = MathsHelpers.DistanceSquaredEuclidean(pixel.hsb, c.hsb) * hsbWeight;
					diffs.Add(rgb); // + hsb);
				}
			}

			if (!diffs.Any())
				diffs.Add(0);

			// average or minimum selection
			return UseMin
				? (float)diffs.Average()
				: (float)(diffs.Min());// / diffs.Count);
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
	}
}
