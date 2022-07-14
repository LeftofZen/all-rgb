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
		public static void AddMaxAgain(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (nearestColourParam.NeighbourCountWeight != 0 && diffs.Count >= nearestColourParam.NeighbourCountThreshold)
			{
				diffs.Add(nearestColourParam.NeighbourCountWeight);
			}
		}

		public static void AddMultMaxAgain(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, float avgDistanceFromCentre, ref List<float> diffs)
		{
			if (nearestColourParam.NeighbourCountWeight != 0 && diffs.Count >= nearestColourParam.NeighbourCountThreshold)
			{
				diffs.Add(diffs.Max() * nearestColourParam.NeighbourCountWeight);
			}
		}

		public static void Exp(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, float avgDistanceFromCentre, ref List<float> diffs)
		{
			//const float scalar = 0.5f;
			//var neighbourMulti = (diffs.Count / (8 - nearestColourParam.NeighbourCountThreshold)) * nearestColourParam.NeighbourCountWeight;
			//// neighbourMulti = (float)((scalar / Math.Sqrt(diffs.Count)) + (1.0 - scalar)) * nearestColourParam.NeighbourCountWeight * scalar;
			//neighbourMulti = (diffs.Count > nearestColourParam.NeighbourCountThreshold ? 0.05f * diffs.Count : 0f) * nearestColourParam.NeighbourCountWeight;
			//diffs.Add(neighbourMulti);
		}
	}
}
