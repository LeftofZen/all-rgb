using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace all_rgb
{
	public static class IListExtensions
	{
		static Random rnd = new Random(1);
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

	public static class IEnumerableExtensions
	{
		public static IEnumerable<(T First, T Second)> Permute<T>(this IEnumerable<T> ts, IEnumerable<T> other)
		{
			foreach (var v in ts)
			{
				foreach (var w in other)
				{
					yield return (v, w);
				}
			}
		}
	}
	public static class BitmapDataExtensions
	{
		//static unsafe bool IsPixelSet(Color[,] d, Point p) => IsPixelSet(d, (p.X, p.Y));

		//static unsafe bool IsPixelSet(Color[,] d, (int X, int Y) p)
		//{
		//	if (p.X < 0 || p.Y < 0 || p.X >= d.Width || p.Y >= d.Height)
		//	{
		//		return false;
		//	}

		//	var ptr = (byte*)d.Scan0;
		//	var offset = (p.X + (p.Y * d.Height)) * 4;
		//	ptr += offset;
		//	return ptr[3] != 0; // alpha == 0 means unset
		//}

		//static unsafe Color GetPixel(Color[,] d, Point p)
		//{
		//	var ptr = (byte*)d.Scan0;
		//	var offset = (p.X + (p.Y * d.Height)) * 4;
		//	ptr += offset;
		//	return Color.FromArgb(ptr[3], ptr[0], ptr[1], ptr[2]);
		//}

		public static unsafe void SetPixel(this BitmapData d, Point p, Color c)
		{
			SetPixel(d, p.X, p.Y, c);
		}

		public static unsafe void SetPixel(this BitmapData d, int X, int Y, Color c)
		{
			var ptr = (byte*)d.Scan0;
			var offset = (X + (Y * d.Height)) * 4;
			ptr += offset;
			SetPixelCore(ptr, c);
		}

		static unsafe void SetPixelCore(byte* ptr, Color c)
		{
			ptr[0] = c.B; // Blue
			ptr[1] = c.G; // Green
			ptr[2] = c.R; // Red
			ptr[3] = 255; // Alpha
		}
	}
}
