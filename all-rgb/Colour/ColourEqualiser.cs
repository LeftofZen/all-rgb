using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb
{
	public static class ColourEqualiser
	{
		public static HashSet<Colour> Equalise(HashSet<Colour> colours)
		{
			var minR = float.MaxValue;
			var maxR = float.MinValue;

			var minG = float.MaxValue;
			var maxG = float.MinValue;

			var minB = float.MaxValue;
			var maxB = float.MinValue;

			foreach (var c in colours)
			{
				minR = Math.Min(minR, c.R);
				minG = Math.Min(minG, c.G);
				minB = Math.Min(minB, c.B);

				maxR = Math.Max(maxR, c.R);
				maxG = Math.Max(maxG, c.G);
				maxB = Math.Max(maxB, c.B);
			}

			var output = new HashSet<Colour>();

			var diffR = 1f / (maxR - minR);
			var diffG = 1f / (maxG - minG);
			var diffB = 1f / (maxB - minB);

			foreach (var c in colours)
			{
				var r = (c.R - minR) * diffR;
				var g = (c.G - minG) * diffG;
				var b = (c.B - minB) * diffB;
				_ = output.Add(Colour.FromRGB(r, g, b));
			}

			return output;
		}

		public static List<Colour> Equalise(List<Colour> colours)
		{
			var minR = float.MaxValue;
			var maxR = float.MinValue;

			var minG = float.MaxValue;
			var maxG = float.MinValue;

			var minB = float.MaxValue;
			var maxB = float.MinValue;

			foreach (var c in colours)
			{
				minR = Math.Min(minR, c.R);
				minG = Math.Min(minG, c.G);
				minB = Math.Min(minB, c.B);

				maxR = Math.Max(maxR, c.R);
				maxG = Math.Max(maxG, c.G);
				maxB = Math.Max(maxB, c.B);
			}

			var output = new List<Colour>();

			var diffR = 1f / (maxR - minR);
			var diffG = 1f / (maxG - minG);
			var diffB = 1f / (maxB - minB);

			foreach (var c in colours)
			{
				var r = (c.R - minR) * diffR;
				var g = (c.G - minG) * diffG;
				var b = (c.B - minB) * diffB;
				output.Add(Colour.FromRGB(r, g, b));
			}

			return output;
		}
	}
}
