using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using procgenart_core;

namespace all_rgb
{
	public enum DenoiserColourSpace { RGB, HSB };

	public static class Denoiser
	{
		public static void Denoise(ImageBuffer buf, DenoiserParam denoiserParams, DenoiserColourSpace space)
		{
			// make noisy-pixel-detection kernel
			List<(Point point, Colour neighbourAverage)> noisyPixels = new();

			var kernel = new int[,]
			{
				{0, 0, 0},
				{0, 1, 0},
				{0, 0, 0},
			};

			HashSet<Colour> coloursInUse = new();

			// find pixels that need denoising
			for (var y = 0; y < buf.Height; ++y)
			{
				for (var x = 0; x < buf.Width; ++x)
				{
					var neighbours = Utilities.GetNeighbourPoints(buf, new Point(x, y));
					var colours = neighbours.Select(n => buf.GetPixel(n));

					var distance = 0f;
					Colour avg;

					if (space == DenoiserColourSpace.RGB)
					{
						avg = ColourHelpers.AverageRGB(colours);
						distance = MathsHelpers.DistanceSquaredEuclidean(avg.RGB, buf.GetPixel(x, y).RGB);
					}
					else
					{
						avg = ColourHelpers.AverageHSB(colours);
						distance = MathsHelpers.DistanceSquaredHSB(avg.HSB, buf.GetPixel(x, y).HSB);
					}

					if (distance > denoiserParams.DenoisePixelThreshold)
					{
						noisyPixels.Add((new Point(x, y), avg));
					}
					else
					{
						_ = coloursInUse.Add(buf.GetPixel(x, y));
					}
				}
			}

			// try to switch noisy pixels and see if it results in better image
			foreach (var pnA in noisyPixels)
			{
				foreach (var pnB in noisyPixels)
				{
					if (pnA != pnB)
					{
						var pA = buf.GetPixel(pnA.point);
						var pB = buf.GetPixel(pnB.point);

						var distanceAA = MathsHelpers.DistanceSquaredEuclidean(pnA.neighbourAverage.RGB, pA.RGB);
						var distanceBB = MathsHelpers.DistanceSquaredEuclidean(pnB.neighbourAverage.RGB, pB.RGB);
						var distanceAB = MathsHelpers.DistanceSquaredEuclidean(pnA.neighbourAverage.RGB, pB.RGB);
						var distanceBA = MathsHelpers.DistanceSquaredEuclidean(pnB.neighbourAverage.RGB, pA.RGB);

						if (distanceAB + distanceBA < distanceAA + distanceBB)
						{
							// switch
							buf.SetPixel(pnA.point, pB);
							buf.SetPixel(pnB.point, pA);
						}
					}
				}
			}

			// find colours that aren't in use
			//var remainingColours = ColourGenerator
			//	.GenerateColours_RGB_All()
			//	.Except(coloursInUse)
			//	.ToHashSet();

			// find best colour for noisy pixels and set them
			//foreach (var pn in noisyPixels)
			//{
			//	var closestColour = FindClosestColour(ref remainingColours, buf.GetPixel(pn.point));
			//	_ = remainingColours.Remove(closestColour);
			//	buf.SetPixel(pn.point, closestColour);
			//}

			return;
		}

		public static Colour FindClosestColour(ref HashSet<Colour> colours, Colour colour)
		{
			var minColour = colour;
			var minDistance = float.MaxValue;
			foreach (var c in colours)
			{
				var distance = MathsHelpers.DistanceSquaredEuclidean(c.RGB, colour.RGB);
				if (distance < minDistance)
				{
					minDistance = distance;
					minColour = c;
				}
			}

			return minColour;
		}
	}
}
