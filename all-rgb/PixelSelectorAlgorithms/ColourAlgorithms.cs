using System;
using System.Collections.Generic;
using System.Drawing;

namespace all_rgb.PixelSelectorAlgorithms
{
	public static class ColourAlgorithms
	{
		public static void RGBandHSB(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, float avgDistanceFromCentre, ref List<float> diffs)
		{
			foreach (var nxy in AllRGBGenerator.GetNeighbourPoints(buf, xy))
			{
				if (!buf.IsEmpty(nxy))
				{
					var pixel = buf.GetPixel(nxy);
					var dRGB = MathsHelpers.DistanceEuclidean(pixel.RGB, colour.RGB);
					var dHSB = MathsHelpers.DistanceEuclidean(pixel.HSB, colour.HSB);
					var rgb = (1f - dRGB) * nearestColourParam.RgbWeight;
					var hsb = (1f - dHSB) * nearestColourParam.HsbWeight;
					diffs.Add((rgb + hsb) / 2f);
				}
			}
		}
	}
}
