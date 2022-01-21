using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb
{
	public class NearestColourParam
	{
		public float RgbWeight { get; init; } = 1f;
		public float HsbWeight { get; init; } = 0f;
		public float DistanceWeight { get; init; } = 0f; // basically, closer to 1 => circles

		public float NeighbourCountWeight { get; init; } = 0f;
		public int NeighbourCountThreshold { get; init; } = 0;

		public bool UseMax { get; init; } = true;
	}
}
