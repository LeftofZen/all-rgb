using System.Collections.Generic;
using System.Linq;
using Zenith.Colour;
using Zenith.Drawing;
using Zenith.Maths;

namespace all_rgb
{
	// count empty neighbours and adjust weighting based on how many
	// more neighbours = higher weighting
	public static class NeighbourAlgorithms
	{
		public static void AddMaxAgain(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.NeighbourCountWeight > 0 && diffs.Count >= paintParams.NeighbourCountThreshold)
			{
				diffs.Add(paintParams.NeighbourCountWeight);
			}
		}

		public static void AddMultMaxAgain(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.NeighbourCountWeight > 0 && diffs.Count >= paintParams.NeighbourCountThreshold)
			{
				diffs.Add(diffs.Max() * paintParams.NeighbourCountWeight);
			}
		}

		//public static void Exp(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		//{
		//	//const float scalar = 0.5f;
		//	//var neighbourMulti = (diffs.Count / (8 - paintParams.NeighbourCountThreshold)) * paintParams.NeighbourCountWeight;
		//	//// neighbourMulti = (float)((scalar / Math.Sqrt(diffs.Count)) + (1.0 - scalar)) * paintParams.NeighbourCountWeight * scalar;
		//	//neighbourMulti = (diffs.Count > paintParams.NeighbourCountThreshold ? 0.05f * diffs.Count : 0f) * paintParams.NeighbourCountWeight;
		//	//diffs.Add(neighbourMulti);
		//}
	}
}
