using System.Collections.Generic;
using Zenith.Colour;
using Zenith.System.Drawing;
using Zenith.Maths;
using Zenith.Maths.Points;

namespace all_rgb
{
	public static class DistanceAlgorithms
	{
		public static void DistanceFromCenter(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.DistanceWeight <= 0)
			{
				return;
			}

			// distance [0-1] for pixel
			var d = MathsHelpers.Distance.Euclidean(xy, buf.Middle) / buf.Radius;
			var a = avgDistanceFromCentre;
			//if (a - d > 0)
			{
				diffs.Add((a - d) * paintParams.DistanceWeight);
			}
			// if d < avg, add weight.
			// if d > avg, subtract weight

			//var distance = (1f -  /  * (1f - paintParams.DistanceWeight);
			//var distanceDiff = buf.Radius distance  * paintParams.DistanceWeight;
		}
	}
}
