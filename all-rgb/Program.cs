using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace all_rgb
{
	public static class IListExtensions
	{
		static Random rnd = new Random();

		/// <summary>
		/// Shuffles the element order of the specified list.
		/// </summary>
		public static void Shuffle<T>(this IList<T> ts)
		{
			var count = ts.Count;
			var last = count - 1;
			for (var i = 0; i < last; ++i)
			{
				var r = rnd.Next(i, count);
				var tmp = ts[i];
				ts[i] = ts[r];
				ts[r] = tmp;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var pixelCount = (int)Math.Pow(2, 24);
			var size = (int)Math.Sqrt(pixelCount);
			var image = new Bitmap(size, size);

			var colours = new List<Color>(pixelCount);

			Console.WriteLine("Generating colours");
			for (var i = 0; i < pixelCount; ++i)
			{
				var r = i % 256;
				var g = (i >> 8) % 256;
				var b = (i >> 16) % 256;
				var c = Color.FromArgb(0, r, g, b);
				colours.Add(c);
			}

			Console.WriteLine("Shuffling");
			colours.Shuffle();

			Paint(image, colours);
			Save(image);

			Console.WriteLine("Goodbye World!");
			Console.ReadLine();
		}

		static void Save(Image i)
		{
			Console.WriteLine("Saving");
			i.Save(@"C:\Users\Benjamin.Sutas\source\repos\all-rgb\all-rgb\content\img.png", ImageFormat.Png);
		}

		//static HashSet<Point> SeenPoints = new HashSet<Point>();

		static void Paint(Bitmap b, List<Color> c)
		{
			Console.WriteLine("Painting");

			var rect = new Rectangle(0, 0, b.Width, b.Height);
			var dstData = b.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

			var initial = c.Count;
			var counter = 1;

			var pixelQueue = new Queue<Point>();
			var nextColourQueue = new Queue<Color>();
			var middle = new Point(rect.Width / 2, rect.Height / 2);
			var colourQueueLength = 16;

			// paint middle pixel random colour
			SetPixel(dstData, middle, c[counter++]);
			EnqueueEmptyNeighbours(dstData, pixelQueue, middle);

			using (var progressBar1 = new ProgressBar())
			{
				unsafe
				{
					// random blossom
					while (pixelQueue.Count > 0)
					{
						while (nextColourQueue.Count < colourQueueLength && counter < c.Count)
						{
							nextColourQueue.Enqueue(c[counter++]);
						}

						if (nextColourQueue.Count == 0)
						{
							Console.WriteLine("no colours remaining :o");
							break;
						}

						var nextPixel = pixelQueue.Dequeue();
						var sc = GetSurroundingColours(dstData, nextPixel).Select(c => c.c);
						var averageColor = GetAverageColour(sc);
						var closestColour = RemoveClosest(ref nextColourQueue, averageColor);

						SetPixel(dstData, nextPixel, closestColour);
						progressBar1.Report((double)counter / initial);

						// add neighbours
						EnqueueEmptyNeighbours(dstData, pixelQueue, nextPixel);
					}

					// random colours for every pixel
					//byte* dstPtr = (byte*)dstData.Scan0;
					//for (var i = 0; i < rect.Height; i++)
					//{
					//	for (var j = 0; j < rect.Width; j++)
					//	{
					//		var colour = c[counter++];
					//		SetPixel(dstPtr, colour);
					//		dstPtr += 4;
					//	}
					//}
				}
			}

			b.UnlockBits(dstData);

		}

		static unsafe void EnqueueEmptyNeighbours(BitmapData dstData, Queue<Point> pixelQueue, Point nextPixel)
		{
			if (!IsPixelSet(dstData, (nextPixel.X, nextPixel.Y + 1)))
			{
				EnqueueNextPixel(dstData, pixelQueue, new Point(nextPixel.X, nextPixel.Y + 1));
			}
			if (!IsPixelSet(dstData, (nextPixel.X, nextPixel.Y - 1)))
			{
				EnqueueNextPixel(dstData, pixelQueue, new Point(nextPixel.X, nextPixel.Y - 1));
			}
			if (!IsPixelSet(dstData, (nextPixel.X + 1, nextPixel.Y)))
			{
				EnqueueNextPixel(dstData, pixelQueue, new Point(nextPixel.X + 1, nextPixel.Y));
			}
			if (!IsPixelSet(dstData, (nextPixel.X - 1, nextPixel.Y)))
			{
				EnqueueNextPixel(dstData, pixelQueue, new Point(nextPixel.X - 1, nextPixel.Y));
			}
		}

		static unsafe void EnqueueNextPixel(BitmapData dstData, Queue<Point> pixelQueue, Point nextPixel)
		{
			if (!pixelQueue.Contains(nextPixel) && nextPixel.X >= 0 && nextPixel.Y >= 0 && nextPixel.X < dstData.Width && nextPixel.Y < dstData.Height)
			{
				pixelQueue.Enqueue(nextPixel);
			}
		}

		static Color GetAverageColour(IEnumerable<Color> colours)
		{
			int r = 0, g = 0, b = 0;
			foreach (var v in colours)
			{
				r += v.R;
				g += v.G;
				b += v.B;
			}

			return Color.FromArgb(255, r / colours.Count(), g / colours.Count(), b / colours.Count());
		}

		static Color RemoveClosest(ref Queue<Color> queue, Color c)
		{
			var arr = queue.ToArray();
			var min = Distance(c, arr[0]);
			var minColor = arr[0];

			for (var i = 1; i < arr.Length; ++i)
			{
				var dist = Distance(c, arr[i]);
				if (dist < min)
				{
					min = dist;
					minColor = arr[i];
				}
			}

			queue = new Queue<Color>(arr.Where(c => c != minColor));
			return minColor;
		}

		static float Distance(Color a, Color b)
		{
			return (float)Math.Sqrt(
				Math.Pow(a.R - b.R, 2) +
				Math.Pow(a.G - b.G, 2) +
				Math.Pow(a.B - b.B, 2));
		}

		static IEnumerable<(Point p, Color c)> GetSurroundingColours(BitmapData data, Point p)
		{
			var a = new Point(p.X, p.Y + 1);
			var b = new Point(p.X, p.Y - 1);
			var c = new Point(p.X + 1, p.Y);
			var d = new Point(p.X - 1, p.Y);
			var bounds = new Rectangle(0, 0, data.Width, data.Height);

			if (bounds.Contains(a) && IsPixelSet(data, a))
				yield return (a, GetPixel(data, a));
			if (bounds.Contains(b) && IsPixelSet(data, b))
				yield return (b, GetPixel(data, b));
			if (bounds.Contains(c) && IsPixelSet(data, c))
				yield return (c, GetPixel(data, c));
			if (bounds.Contains(d) && IsPixelSet(data, d))
				yield return (d, GetPixel(data, d));

		}

		static unsafe bool IsPixelSet(BitmapData d, Point p) => IsPixelSet(d, (p.X, p.Y));

		static unsafe bool IsPixelSet(BitmapData d, (int X, int Y) p)
		{
			if (p.X < 0 || p.Y < 0 || p.X >= d.Width || p.Y >= d.Height)
			{
				return false;
			}

			var ptr = (byte*)d.Scan0;
			var offset = (p.X + (p.Y * d.Height)) * 4;
			ptr += offset;
			return ptr[3] != 0; // alpha == 0 means unset
		}

		static unsafe Color GetPixel(BitmapData d, Point p)
		{
			var ptr = (byte*)d.Scan0;
			var offset = (p.X + (p.Y * d.Height)) * 4;
			ptr += offset;
			return Color.FromArgb(ptr[3], ptr[0], ptr[1], ptr[2]);
		}

		static unsafe void SetPixel(BitmapData d, Point p, Color c)
		{
			var ptr = (byte*)d.Scan0;
			var offset = (p.X + (p.Y * d.Height)) * 4;
			ptr += offset;
			SetPixel(ptr, c);
		}

		static unsafe void SetPixel(byte* ptr, Color c)
		{
			ptr[0] = (byte)c.B; // Blue
			ptr[1] = (byte)c.G; // Green
			ptr[2] = (byte)c.R; // Red
			ptr[3] = (byte)255; // Alpha
		}
	}
}
