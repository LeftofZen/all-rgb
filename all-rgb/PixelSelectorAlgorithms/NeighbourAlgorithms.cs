using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using procgenart_core;

namespace all_rgb
{
	// count empty neighbours and adjust weighting based on how many
	// more neighbours = higher weighting
	public static class NeighbourAlgorithms
	{
		public static void AddMaxAgain(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.NeighbourCountWeight != 0 && diffs.Count >= paintParams.NeighbourCountThreshold)
			{
				diffs.Add(paintParams.NeighbourCountWeight);
			}
		}

		public static void AddMultMaxAgain(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (paintParams.NeighbourCountWeight != 0 && diffs.Count >= paintParams.NeighbourCountThreshold)
			{
				diffs.Add(diffs.Max() * paintParams.NeighbourCountWeight);
			}
		}

		public static void Exp(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs)
		{
			//const float scalar = 0.5f;
			//var neighbourMulti = (diffs.Count / (8 - paintParams.NeighbourCountThreshold)) * paintParams.NeighbourCountWeight;
			//// neighbourMulti = (float)((scalar / Math.Sqrt(diffs.Count)) + (1.0 - scalar)) * paintParams.NeighbourCountWeight * scalar;
			//neighbourMulti = (diffs.Count > paintParams.NeighbourCountThreshold ? 0.05f * diffs.Count : 0f) * paintParams.NeighbourCountWeight;
			//diffs.Add(neighbourMulti);
		}
	}
}
