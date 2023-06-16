using System.Drawing;

namespace procgenart_core
{
	public static class Utilities
	{
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

		public static IEnumerable<Colour> GetNonEmptyNeighbourColours(ImageBuffer buf, Point p)
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

		public static IEnumerable<Point> GetNonEmptyNeighbourPoints(ImageBuffer buf, Point p)
		{
			for (var x = -1; x < 2; ++x)
			{
				for (var y = -1; y < 2; ++y)
				{
					if (p.X + x >= 0 && p.X + x < buf.Width && p.Y + y >= 0 && p.Y + y < buf.Height)
					{
						if (buf.IsEmpty(p.X + x, p.Y + y))
						{
							yield return new Point(p.X + x, p.Y + y);
						}
					}
				}
			}
		}
	}
}