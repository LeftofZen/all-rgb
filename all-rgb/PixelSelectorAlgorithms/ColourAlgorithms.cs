using System.Collections.Generic;
using System.Drawing;
using procgenart_core;

namespace all_rgb
{
	public static class ColourAlgorithms
	{
		public static void RGBandHSB(ImageBuffer buf, Point xy, Colour colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			foreach (var nxy in Utilities.GetNeighbourPoints(buf, xy))
			{
				if (!buf.IsEmpty(nxy))
				{
					PerNeighbourPixelWeighting3(buf, xy, colour, paintParams, avgDistanceFromCentre, diffs, nxy);
				}
			}
		}

		// diamond shaped
		private static void PerNeighbourPixelWeighting1(ImageBuffer buf, Point xy, Colour colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.DistanceEuclidean(pixel.RGB, colour.RGB);
			var dHSB = MathsHelpers.DistanceEuclidean(pixel.HSB, colour.HSB);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			var hsb = (1f - dHSB) * paintParams.HsbWeight;
			var weight = (rgb + hsb) / 2f;

			weight -= MathsHelpers.DistanceManhattan(xy, buf.Middle) / buf.Radius / 2f;

			diffs.Add(weight);
		}

		//
		private static void PerNeighbourPixelWeighting2(ImageBuffer buf, Point xy, Colour colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.DistanceEuclidean(pixel.RGB, colour.RGB);
			var dHSB = MathsHelpers.DistanceEuclidean(pixel.HSB, colour.HSB);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			var hsb = (1f - dHSB) * paintParams.HsbWeight;
			var weight = (rgb + hsb) / 2f;

			weight -= MathsHelpers.DistanceEuclidean(xy, buf.Middle) / 100000000f;

			diffs.Add(weight);
		}

		// crystals-like with hyperbolic expansion
		private static void PerNeighbourPixelWeighting3(ImageBuffer buf, Point xy, Colour colour, PaintParams paintParams, float avgDistanceFromCentre, List<float> diffs, Point nxy)
		{
			var pixel = buf.GetPixel(nxy);
			var dRGB = MathsHelpers.DistanceEuclidean(pixel.RGB, colour.RGB);
			var dHSB = MathsHelpers.DistanceEuclidean(pixel.HSB, colour.HSB);

			var rgb = (1f - dRGB) * paintParams.RgbWeight;
			var hsb = (1f - dHSB) * paintParams.HsbWeight;
			var weight = (rgb + hsb) / 2f;

			weight += MathsHelpers.DistanceEuclidean(xy, buf.Middle) / (buf.Radius * 100f);

			diffs.Add(weight);
		}
	}
}
