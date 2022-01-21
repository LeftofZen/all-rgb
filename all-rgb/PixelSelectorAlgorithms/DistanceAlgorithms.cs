using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb.PixelSelectorAlgorithms
{
	public static class DistanceAlgorithms
	{
		public static void DistanceFromCenter(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, ref List<float> diffs)
		{
			// distance modifier
			//var distance = (1f - MathsHelpers.DistanceEuclidean(xy, buf.Middle)) / buf.Radius * (1f / nearestColourParam.DistanceWeight);
			////var distanceDiff = buf.Radius distance  * nearestColourParam.DistanceWeight;
			//diffs.Add(1f - distance);
		}
	}
}
