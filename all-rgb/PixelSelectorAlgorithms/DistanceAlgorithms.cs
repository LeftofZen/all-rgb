﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb.PixelSelectorAlgorithms
{
	public static class DistanceAlgorithms
	{
		public static void DistanceFromCenter(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, float avgDistanceFromCentre, ref List<float> diffs)
		{
			// distance [0-1] for pixel
			var d = MathsHelpers.DistanceEuclidean(xy, buf.Middle) / buf.Radius;
			var a = avgDistanceFromCentre;
			if (a - d > 0)
			{
				diffs.Add((a - d) * nearestColourParam.DistanceWeight * 20);
			}
			// if d < avg, add weight.
			// if d > avg, subtract weight


			//var distance = (1f -  /  * (1f - nearestColourParam.DistanceWeight);
			//var distanceDiff = buf.Radius distance  * nearestColourParam.DistanceWeight;
		}
	}
}