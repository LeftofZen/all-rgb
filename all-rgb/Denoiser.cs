using System.Collections.Generic;
using System.Linq;
using Zenith.Colour;
using Zenith.Drawing;
using Zenith.Maths;

namespace all_rgb
{
	public static class Denoiser
	{
		public static void Denoise(ImageBuffer buf, DenoiserParam denoiserParams)
		{
			// make noisy-pixel-detection kernel
			List<(Point2 point, ColourRGB neighbourAverage)> noisyPixels = new();

			var kernel = new int[,]
			{
				{0, 0, 0},
				{0, 1, 0},
				{0, 0, 0},
			};

			HashSet<ColourRGB> coloursInUse = new();

			// find pixels that need denoising
			for (var y = 0; y < buf.Height; ++y)
			{
				for (var x = 0; x < buf.Width; ++x)
				{
					var neighbours = buf.GetNeighbourPoints(new Point2(x, y));
					var colours = neighbours.Select(n => buf.GetPixel(n));
					var avg = ColourHelpers.AverageRGB(colours);
					var distance = MathsHelpers.Distance.EuclideanSquared(avg, buf.GetPixel(x, y));

					if (distance > denoiserParams.DenoisePixelThreshold)
					{
						noisyPixels.Add((new Point2(x, y), avg));
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

						var distanceAA = MathsHelpers.Distance.EuclideanSquared(pnA.neighbourAverage, pA);
						var distanceBB = MathsHelpers.Distance.EuclideanSquared(pnB.neighbourAverage, pB);
						var distanceAB = MathsHelpers.Distance.EuclideanSquared(pnA.neighbourAverage, pB);
						var distanceBA = MathsHelpers.Distance.EuclideanSquared(pnB.neighbourAverage, pA);

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

		public static ColourRGB FindClosestColour(ref HashSet<ColourRGB> colours, ColourRGB colour)
		{
			var minColour = colour;
			var minDistance = float.MaxValue;
			foreach (var c in colours)
			{
				var distance = MathsHelpers.Distance.EuclideanSquared(c, colour);
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
