using System.Collections.Generic;
using Zenith.Colour;
using Zenith.Drawing;
using Zenith.Maths;

namespace all_rgb
{
	public static class ColourAlgorithms
	{
		public static void RGBandHSB(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.RgbWeight <= 0 && paintParams.HsbWeight <= 0)
			{
				return;
			}

			foreach (var nxy in buf.GetNeighbourPoints(xy))
			{
				if (!buf.IsEmpty(nxy))
				{
					PerNeighbourPixelWeighting2(buf, xy, colour, paintParams, avgDistanceFromCentre, diffs, nxy);
				}
			}
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

		//
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
	}
}
