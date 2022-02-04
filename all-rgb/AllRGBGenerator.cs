using all_rgb.PixelSelectorAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace all_rgb
{
	public record ProgressReport(float Percent, string ETAText, Image ProgressReportImage, string BatchInfo, float CurrentAverageRadius);

	public class AllRGBGenerator
	{
		public AllRGBGenerator()
		{
			// todo: read this list from UI
			// save/reload this list as config
			pixelSelectorDelegates.Add(ColourAlgorithms.RGBandHSB);
			pixelSelectorDelegates.Add(DistanceAlgorithms.DistanceFromCenter);
			pixelSelectorDelegates.Add(NeighbourAlgorithms.AddMaxAgain);
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
				colours = colours.OrderBy(c => c.R).ThenBy(c => c.G).ThenBy(c => c.B).ToList();
			}

			return colours;
		}

		private static List<Colour> SortColoursHSB(List<Colour> colours, HSBComparerComponents hsbComponents)
		{
			if (hsbComponents != HSBComparerComponents.Empty)
			{
				colours.Sort(new HSBComponentColorComparer(hsbComponents));
			}
			else
			{
				colours.Sort(new HSBSumColorComparer());
			}

			return colours;
		}

		private static List<Colour> SortColoursNN(List<Colour> colours)
		{
			List<Colour> output = new();

			var curr = colours[0];

			while (colours.Count > 1)
			{
				output.Add(curr);
				_ = colours.Remove(curr);

				Colour nearest = default;
				var minDistance = float.MaxValue;
				for (var i = 1; i < colours.Count; ++i)
				{
					var distance = MathsHelpers.DistanceSquaredEuclidean(curr.RGB, colours[i].RGB);
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

			Colours = ColourGenerator.GenerateColours_RGB_Uniform(CurrentBuffer.Width * CurrentBuffer.Height).ToList();

			//RefineColours(true, false);
			var nearestColourParam = new NearestColourParam();
			_ = Paint(nearestColourParam);

			Save(GenSaveOptions.Image);
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
			var imgDim = (int)Math.Sqrt(Colours.Count) + 1;
			var paletteBuffer = new ImageBuffer(CurrentBuffer.Width, CurrentBuffer.Height);
			int count = 0;
			foreach (var c in Colours)
			{
				paletteBuffer.SetPixel(count % CurrentBuffer.Width, count / CurrentBuffer.Width, c);
			}
			paletteBuffer.Save();
		}

		#region PaletteSelection

		public static List<Colour> ReverseColours(List<Colour> colours)
		{
			colours.Reverse();
			return colours;
		}

		/// <summary>
		///  
		/// </summary>
		/// <param name="colours"></param>
		/// <param name="percentToDeviate">0 = no shuffle, 1 = full shuffle, values inbetween mean an item can only move a % distance to a new spot.
		/// eg 0.5 means an item can move at most 50% away from it's initial position</param>
		/// <returns></returns>
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
				SortType.NN => SortColoursNN(colours),
				_ => throw new NotImplementedException(),
			};

		#endregion

		public ImageBuffer CurrentBuffer { get; private set; }

		public Task<Image> Paint(NearestColourParam nearestColourParam)
		{
			var progress = new Progress<ProgressReport>(value => ProgressCallback(value));
			PaintTask = Task.Run(() => Paint(Colours, progress, nearestColourParam));
			return PaintTask;
		}

		public Task<Image> PaintTask;

		public Action<ProgressReport> ProgressCallback = new((_) => { });

		public bool Pause { get; set; }

		bool Abort { get; set; }

		public void AbortPaint() => Abort = true;

		readonly HashSet<Point> Frontier = new();

		Image Paint(List<Colour> cols, IProgress<ProgressReport> progress, NearestColourParam nearestColourParam)
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

			var baseRecord = new ProgressReport(0f, "Forever", null, "Unknown", 0f);

			using (var consoleProgressBar = new ConsoleProgressBar())
			{
				Point bestXY;

				foreach (var col in cols)
				{
					#region Abort

					if (Abort)
					{
						var abortStr = $"Aborted at {swTotal.Elapsed:g}";
						progress.Report(baseRecord with { Percent = 1f, ETAText = abortStr, ProgressReportImage = GetCurrentImage() });
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

					var avgDistance = 0f;
					if (Frontier.Count == 0)
					{
						bestXY = CurrentBuffer.Middle;
					}
					else
					{
						avgDistance = Frontier.Sum((p) => MathsHelpers.DistanceEuclidean(p, CurrentBuffer.Middle));
						avgDistance /= CurrentBuffer.Radius;
						avgDistance /= Frontier.Count; // scale to 0-1 range

						bestXY = Frontier
							.AsParallel()
							.OrderByDescending(xy => GetNearestColourFromAlgos(CurrentBuffer, xy, col, nearestColourParam, avgDistance, pixelSelectorDelegates))
							.First();
					}

					CurrentBuffer.SetPixel(bestXY, col);
					_ = Frontier.Remove(bestXY);

					// add neighbours
					foreach (var nxy in GetNeighbourPoints(CurrentBuffer, bestXY))
					{
						if (CurrentBuffer.IsEmpty(nxy))
						{
							_ = Frontier.Add(nxy);
						}
					}

					counter++;

					var percentDone = (float)counter / cols.Count;
					if (counter % refreshRate == 0)
					{
						var timeElapsed = swTotal.ElapsedMilliseconds;
						var eta = (1f / percentDone * timeElapsed) - timeElapsed;
						var ts = new TimeSpan(0, 0, 0, 0, (int)eta);
						var timeStr = $"Elapsed={swTotal.Elapsed:g} ETA={ts:g} Progress={percentDone:P}";

						consoleProgressBar.Report(percentDone, timeStr);
						progress.Report(baseRecord with
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
				progress.Report(baseRecord with { Percent = 1f, ETAText = doneStr, ProgressReportImage = GetCurrentImage() });
			}

			swTotal.Reset();
			Frontier.Clear();

			return GetCurrentImage();
		}

		List<PixelSelectorDelegate> pixelSelectorDelegates = new List<PixelSelectorDelegate>();

		static float GetNearestColourFromAlgos(ImageBuffer buf, Point xy, Colour c, NearestColourParam nearestColourParam, float avgDistanceFromCentre, List<PixelSelectorDelegate> algos)
		{
			// get the diffs for each neighbour separately
			var diffs = new List<float>(8);

			foreach (var algo in algos)
			{
				algo(ref buf, ref xy, ref c, ref nearestColourParam, avgDistanceFromCentre, ref diffs);
			}

			// average or minimum selection
			var selectedDiff = 0f;
			return nearestColourParam.NearestColourSelector switch
			{
				NearestColourSelector.Min => (float)diffs.Min(),
				NearestColourSelector.Max => (float)diffs.Max(),
				NearestColourSelector.Sum => (float)diffs.Sum(),
				NearestColourSelector.Average => (float)diffs.Average(),
				_ => selectedDiff,
			};
		}

		//// this method is not threadsafe
		//static float GetNearestColour(ImageBuffer buf, Point xy, Colour c, NearestColourParam nearestColourParam, float avgDistanceFromCentre)
		//{
		//	// get the diffs for each neighbour separately
		//	var diffs = new List<float>(8);

		//	// Colour algorithms
		//	ColourAlgorithms.RGBandHSB(ref buf, ref xy, ref nearestColourParam, ref diffs);

		//	// Distance algorithms
		//	DistanceAlgorithms.DistanceFromCenter(ref nearestColourParam, ref diffs);

		//	// Neighbour algorithms
		//	NeighbourAlgorithms.AddMaxAgain(ref nearestColourParam, ref diffs);

		//	// average or minimum selection
		//	var selectedDiff = nearestColourParam.UseMax
		//		? (float)diffs.Max()
		//		: (float)diffs.Average();

		//	return selectedDiff;
		//}

		public static IEnumerable<Point> GetNeighbourPoints(ImageBuffer buf, Point p)
		{
			for (var x = -1; x < 2; ++x)
			{
				for (var y = -1; y < 2; ++y)
				{
					if (x != 0 || y != 0)
					{
						if (p.X + x >= 0 && p.X + x < buf.Width && p.Y + y >= 0 && p.Y + y < buf.Height)
						{
							yield return new Point(p.X + x, p.Y + y);
						}
					}
				}
			}
		}

		static IEnumerable<Colour> GetNonEmptyNeighbourColours(ImageBuffer buf, Point p)
		{
			for (var x = -1; x < 2; ++x)
			{
				for (var y = -1; y < 2; ++y)
				{
					if (p.X + x >= 0 && p.X + x < buf.Width && p.Y + y >= 0 && p.Y + y < buf.Height)
					{
						if (buf.IsEmpty(p.X + x, p.Y + y))
						{
							yield return buf.GetPixel(p.X + x, p.Y + y);
						}
					}
				}
			}
		}
	}
}
