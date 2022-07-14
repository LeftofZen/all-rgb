using System.Drawing;
using System.Drawing.Imaging;

namespace procgenart_core
{
	public static class IListExtensions
	{
		static readonly Random rnd = new(1);

		public static void Shuffle<T>(this IList<T> ts, float percentToDeviate = 1f, int skip = 1)
		{
			var count = ts.Count;
			var last = count - 1;
			for (var i = 0; i < last; i += skip)
			{
				var r = rnd.Next(i, (int)(((count - i) * percentToDeviate) + i));
				(ts[r], ts[i]) = (ts[i], ts[r]);
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

		//public static unsafe Color GetPixel(this BitmapData d, Point p)
		//	=> GetPixel(d, p.X, p.Y);

		public static unsafe Colour GetPixel(this BitmapData d, int X, int Y)
		{
			var ptr = GetPtrToFirstPixel(d, X, Y);
			return Colour.FromRGB(ptr[2] / 255f, ptr[1] / 255f, ptr[0] / 255f); // alpha is ptr[3]);
		}

		public static unsafe void SetPixel(this BitmapData d, Point p, Colour c)
			=> SetPixel(d, p.X, p.Y, c);

		public static unsafe void SetPixel(this BitmapData d, int X, int Y, Colour c)
			=> SetPixel(GetPtrToFirstPixel(d, X, Y), c);

		private static unsafe byte* GetPtrToFirstPixel(this BitmapData d, int X, int Y)
			=> (byte*)d.Scan0.ToPointer() + (Y * d.Stride) + (X * (Image.GetPixelFormatSize(d.PixelFormat) / 8));

		private static unsafe void SetPixel(byte* ptr, Color c)
		{
			ptr[0] = c.B; // Blue
			ptr[1] = c.G; // Green
			ptr[2] = c.R; // Red
			ptr[3] = c.A; // Alpha
		}

		private static unsafe void SetPixel(byte* ptr, Colour c)
		{
			ptr[0] = (byte)(c.B * 255); // Blue
			ptr[1] = (byte)(c.G * 255); // Green
			ptr[2] = (byte)(c.R * 255); // Red
			ptr[3] = (byte)(c.A * 255); // Alpha
		}
	}
}
