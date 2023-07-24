using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KdTree;
using KdTree.Math;
using Zenith.Colour;
using Zenith.Core;
using Zenith.Drawing;
using Zenith.Linq;
using Zenith.Maths;
using Zenith.Maths.Points;
using System.Collections.Concurrent;

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

	// instead, subclass TaskScheduler?
	/*
	public class ThreadManager : TaskScheduler
	{
		public ThreadManager(int threadCount = 8)
		{
			Queue = new ConcurrentQueue<Task>();
			CompletedWork = new ConcurrentQueue<Task>();

			Threads = new List<Thread>(threadCount);
			for (var i = 0; i < threadCount; ++i)
			{
				Threads.Add(new Thread(ThreadDoWork));
				Threads[i].Start();
			}
		}

		void ThreadDoWork()
		{
			ThreadLocal<Task> ThreadCurrentTask = null;

			while (true)
			{
				if (ThreadCurrentTask == null)
				{
					if (Queue.TryDequeue(out var result))
					{
						result.ContinueWith()
						//ThreadCurrentTask = new ThreadLocal<Task>(() => result);
						//result.RunSynchronously();
					}
				}
				else
				{
					if (ThreadCurrentTask.Value.IsCompleted)
					{
						CompletedWork.Enqueue(ThreadCurrentTask.Value);
						ThreadCurrentTask = null;
					}
				}

				// no work to do - spin
				_ = Thread.Yield();
			}
		}

		void OnComplete()
		{

		}

		List<Thread> Threads;
		ConcurrentQueue<Task> Queue;
		ConcurrentQueue<Task> CompletedWork;

		#region TaskScheduler

		protected override IEnumerable<Task> GetScheduledTasks()
			=> Queue;

		protected override void QueueTask(Task task)
			=> Queue.Enqueue(task);

		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
			=> Thread.CurrentThread.IsAlive && !taskWasPreviouslyQueued ? TryExecuteTask(task) : false;

		#endregion
	}
	*/

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

		public HashSet<ColourRGB> Colours = new();
		public bool UseMin;
		//public ThreadManager ThreadManager { get; set; } = new();

		public static ImageBuffer GetImageFromColours(HashSet<ColourRGB> colourSet, int width, int height)
		{
			var colours = colourSet.ToList();
			var palette = new ImageBuffer(width, height);
			var coloursPerPixel = (float)colours.Count / (width * height);
			var i = 0;
			var colourCounter = 0f;

			while (i < width * height && colourCounter < colours.Count)
			{
				palette.SetPixel(
					i % width,
					i / width,
					colours[(int)colourCounter]);

				colourCounter += coloursPerPixel;
				++i;
			}

			return palette;
		}

		private static List<ColourRGB> SortColoursRGB(List<ColourRGB> colours, RGBComparerComponents rgbComponents)
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

		private static List<ColourHSB> SortColoursHSB(List<ColourHSB> colours, HSBComparerComponents hsbComponents)
		{
			//IComparer<ColourRGB> comparer = hsbComponents != HSBComparerComponents.Empty
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

		private static List<ColourRGB> SortColoursNNKDTree(List<ColourRGB> colours)
		{
			var tree = new KdTree<float, ColourRGB>(3, new FloatMath());
			List<ColourRGB> result = new();
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

		public void BufferFromImage(ImageBuffer imageBuffer)
		{
			Frontier.Clear();
			CurrentBuffer = imageBuffer;
		}

		public void SetTemplate(ImageBuffer templateImage)
		{
			Frontier.Clear();
			CreateBuffer(templateImage.Width, templateImage.Height);

			for (var y = 0; y < templateImage.Height; ++y)
			{
				for (var x = 0; x < templateImage.Width; ++x)
				{
					if (templateImage.GetPixel(x, y) == ColourRGB.Black)
					{
						_ = Frontier.Add(new Point2(x, y));
					}
				}
			}
		}

		public void SetPalette(ImageBuffer imgBuf)
		{
			Frontier.Clear();
			var colours = new HashSet<ColourRGB>();

			for (var y = 0; y < imgBuf.Height; ++y)
			{
				for (var x = 0; x < imgBuf.Width; ++x)
				{
					_ = colours.Add(imgBuf.GetPixel(x, y));
				}
			}

			Colours = colours;
		}

		public void CreateBuffer(int width = 128, int height = 128)
			=> CurrentBuffer = new ImageBuffer(width, height);

		#region PaletteSelection

		public static List<ColourRGB> ReverseColours(List<ColourRGB> colours)
		{
			colours.Reverse();
			return colours;
		}

		public static List<ColourRGB> ShuffleColours(List<ColourRGB> colours, float percentToDeviate = 1f, int skip = 1)
		{
			colours.Shuffle(percentToDeviate, skip);
			return colours;
		}

		public enum SortType { RGB, HSB, NN };

		public static HashSet<ColourRGB> SortColours(HashSet<ColourRGB> colourSet, SortType sortType, RGBComparerComponents? rgbComparerComponents = null, HSBComparerComponents? hsbComparerComponents = null)
		{
			var colours = colourSet.ToList();
			return sortType switch
			{
				SortType.RGB => SortColoursRGB(colours, rgbComparerComponents.Value).ToHashSet(),
				SortType.HSB => SortColoursHSB(colours.ConvertAll(c => c.AsHSB()), hsbComparerComponents.Value).ConvertAll(c => c.AsRGB()).ToHashSet(), // ugly AF, find a way to make this nicer/less conversion
				SortType.NN => SortColoursNNKDTree(colours).ToHashSet(),
				_ => throw new NotImplementedException(),
			};
		}

		#endregion

		public ImageBuffer CurrentBuffer { get; set; }

		public Task<ImageBuffer> Paint(PaintParams paintParams)
		{
			var progress = new Progress<ProgressReport>(value => ProgressCallback(value));

			PaintTask = Task.Factory.StartNew(() => Paint(progress, Colours, paintParams));

			//PaintTask = Task.Factory.StartNew(
			//	() => Paint(progress, Colours, paintParams),
			//	CancellationToken.None,
			//	TaskCreationOptions.None,
			//	ThreadManager);

			return PaintTask;
		}

		public Task<ImageBuffer> PaintTask;

		public Action<ProgressReport> ProgressCallback = new((_) => { });

		public bool Pause { get; set; }

		public bool Abort { get; private set; }

		public void AbortPaint() => Abort = true;

		readonly HashSet<Point2> Frontier = new();

		static readonly ProgressReport BaseRecord = new(0f, "Forever", null, "Unknown", 0f);

		public void Clear()
		{
			CurrentBuffer.Clear();
			Frontier.Clear();
		}

		ImageBuffer Paint(IProgress<ProgressReport> progress, HashSet<ColourRGB> colourSet, PaintParams paintParams)
		{
			var cols = colourSet.ToList();
			var size = (int)Math.Sqrt(cols.Count);
			CurrentBuffer = CurrentBuffer == null
				? new ImageBuffer(size, size)
				: new ImageBuffer(CurrentBuffer.Width, CurrentBuffer.Height);

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
					var randomPoint = new Point2(rnd.Next(CurrentBuffer.Width), rnd.Next(CurrentBuffer.Height));
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

			Verify.NotEmpty(Frontier);

			cols = cols.Skip(1).ToList();

			using (var consoleProgressBar = new ConsoleProgressBar())
			{
				Point2 bestXY;

				foreach (var col in cols)
				{
					#region Abort

					if (Abort)
					{
						var abortStr = $"Aborted at {swTotal.Elapsed:g}";
						progress.Report(BaseRecord with { Percent = 1f, ETAText = abortStr, ProgressReportImageBuffer = CurrentBuffer });
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

					var avgDistance = Frontier.Sum((p) => MathsHelpers.Distance.Euclidean(new Point2(p.X, p.Y), CurrentBuffer.Middle));
					avgDistance /= CurrentBuffer.Radius * Frontier.Count; // scale to 0-1 range

					bestXY = Frontier
						//.AsParallel()
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
							ProgressReportImageBuffer = counter % refreshRate == 0 ? CurrentBuffer : null,
							BatchInfo = $"BatchSize={refreshRate} BatchTime={swBatch.ElapsedMilliseconds}ms FrontierSize={Frontier.Count}",
							CurrentAverageRadius = avgDistance * CurrentBuffer.Radius, // put from 0-1 to 0-radius
						});

						swBatch.Restart();
					}
				}

				swTotal.Stop();
				var doneStr = $"Done in {swTotal.Elapsed:g}";
				consoleProgressBar.Report(1, doneStr);
				progress.Report(BaseRecord with { Percent = 1f, ETAText = doneStr, ProgressReportImageBuffer = CurrentBuffer });
			}

			swTotal.Reset();
			Frontier.Clear();

			//var img = GetCurrentImage();
			//if (!Abort)
			//{
			//	Save(GenSaveOptions.Image); // autosave a completed image
			//}

			//return img;

			return CurrentBuffer;

			void UpdateFrontier(Point2 newPixel)
			{
				foreach (var nxy in CurrentBuffer.GetEmptyNeighbourPoints(newPixel))
				{
					_ = Frontier.Add(nxy);
				}
			}
		}

		readonly List<PixelSelectorDelegate> pixelSelectorDelegates = new();

		static float GetNearestColourFromAlgos(ImageBuffer buf, Point2 xy, ColourRGB c, PaintParams paintParams, float avgDistanceFromCentre, List<PixelSelectorDelegate> algos)
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
