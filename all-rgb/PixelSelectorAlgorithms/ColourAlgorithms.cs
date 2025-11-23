using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Zenith.Colour;
using Zenith.Drawing;
using Zenith.Maths;

namespace all_rgb
{
	public static class ColourAlgorithms
	{
		static ConcurrentDictionary<Point2, IEnumerable<Point2>> cachedNeighbours = [];


		public static void RGBandHSB(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.RgbWeight <= 0 && paintParams.HsbWeight <= 0)
			{
				return;
			}

			if (!cachedNeighbours.TryGetValue(xy, out IEnumerable<Point2> neighbours))
			{
				neighbours = GetNeighbourPoints(buf, xy)
					.Where(pxy => pxy.X >= 0 && pxy.Y >= 0 && pxy.X < buf.Width && pxy.Y < buf.Height);

				_ = cachedNeighbours.TryAdd(xy, neighbours);
			}

			foreach (var nxy in neighbours)
			{
				if (!buf.IsEmpty(nxy))
				{
					PerNeighbourPixelWeighting2(buf, xy, colour, paintParams, avgDistanceFromCentre, diffs, nxy);
				}
			}
		}

		public static IEnumerable<Point2> GetNeighbourPoints(ImageBuffer buf, Point2 p)
		{
			yield return new Point2(p.X - 1, p.Y - 1);
			yield return new Point2(p.X - 1, p.Y);
			yield return new Point2(p.X - 1, p.Y + 1);

			yield return new Point2(p.X + 1, p.Y - 1);
			yield return new Point2(p.X + 1, p.Y);
			yield return new Point2(p.X + 1, p.Y + 1);

			yield return new Point2(p.X, p.Y - 1);
			yield return new Point2(p.X, p.Y);
			yield return new Point2(p.X, p.Y + 1);


		}

		// diamond shaped
		private static void PerNeighbourPixelWeighting1(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point2 nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.Distance.Euclidean(pixel, colour);
			var dHSB = MathsHelpers.Distance.Euclidean(pixel, colour);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			var hsb = (1f - dHSB) * paintParams.HsbWeight;
			var weight = (rgb + hsb) / 2f;

			weight -= MathsHelpers.Distance.Manhattan(xy, buf.Middle) / buf.Radius / 2f;

			diffs.Add((float)weight);
		}

		// kind of vanilla-like
		private static void PerNeighbourPixelWeighting2(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point2 nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.Distance.Euclidean(pixel, colour);
			var dHSB = MathsHelpers.Distance.Euclidean(pixel, colour);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			var hsb = (1f - dHSB) * paintParams.HsbWeight;
			var weight = (rgb + hsb) / 2f;

			//weight -= MathsHelpers.Distance.Euclidean(xy, buf.Middle) / 100000000f;

			diffs.Add((float)weight);
		}

		// crystals-like with hyperbolic expansion
		private static void PerNeighbourPixelWeighting3(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point2 nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.Distance.Euclidean(pixel, colour);
			var dHSB = MathsHelpers.Distance.Euclidean(pixel, colour);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			var hsb = (1f - dHSB) * paintParams.HsbWeight;
			var weight = (rgb + hsb) / 2f;

			weight += MathsHelpers.Distance.Euclidean(xy, buf.Middle) / (buf.Radius * 100f);

			diffs.Add((float)weight);
		}

		// kind of vanilla-like
		private static void PerNeighbourPixelWeighting4(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point2 nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.Distance.Manhattan(pixel, colour);
			//var dHSB = MathsHelpers.Distance.Euclidean(pixel, colour);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			//var hsb = (1f - dHSB) * paintParams.HsbWeight;
			//var weight = (rgb + hsb) / 2f;
			var weight = rgb;

			//weight -= MathsHelpers.Distance.Euclidean(xy, buf.Middle) / 100000000f;

			diffs.Add((float)weight);
		}
	}
}
