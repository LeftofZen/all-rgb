using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb
{
	public static class ColourGenerator
	{
		public static HashSet<Colour> GenerateColours_RGB_Uniform(int pixelCount)
		{
			Console.WriteLine("Generating colours");

			if (pixelCount == 0)
			{
				Console.WriteLine("no pixels");
				return new HashSet<Colour>();
			}

			var setOfAllColours = new HashSet<Colour>(pixelCount);

			var stepsPerChannel = (int)Math.Pow(pixelCount, 1f / 3f);
			var stepSize = 1f / (stepsPerChannel - 1); // subtract 1 because range is inclusive - 3 steps is [0, 0.5, 1]
			var rSteps = stepsPerChannel;
			var gSteps = stepsPerChannel;
			var bSteps = stepsPerChannel;

			for (var r = 0; r < rSteps; ++r)
			{
				for (var g = 0; g < gSteps; ++g)
				{
					for (var b = 0; b < bSteps; ++b)
					{
						var rr = stepSize * r;
						var gg = stepSize * g;
						var bb = stepSize * b;

						var c = Colour.FromRGB(rr, gg, bb);

						if (!setOfAllColours.Add(c))
						{
							Trace.Assert(false, "duplicate colour detected", c.ToString());
						}
					}
				}
			}

			Trace.Assert(setOfAllColours.Count == stepsPerChannel * stepsPerChannel * stepsPerChannel);

			var rnd = new Random(1);

			// leftover from non-integer cube root
			while (setOfAllColours.Count < pixelCount)
			{
				_ = setOfAllColours.Add(Colour.FromRGB(
					(float)rnd.NextDouble(),
					(float)rnd.NextDouble(),
					(float)rnd.NextDouble()
					));
			}

			Trace.Assert(setOfAllColours.Count >= pixelCount);

			return setOfAllColours;
		}

		public static HashSet<Colour> GenerateColours_HSB_Random(int pixelCount)
		{
			Console.WriteLine("Generating colours");

			if (pixelCount == 0)
			{
				Console.WriteLine("no pixels");
				return new HashSet<Colour>();
			}

			var setOfAllColours = new HashSet<Colour>(pixelCount);
			var rnd = new Random(1);

			while (setOfAllColours.Count < pixelCount)
			{
				_ = setOfAllColours.Add(Colour.FromHSB(
					(float)rnd.NextDouble(),
					(float)rnd.NextDouble(),
					(float)rnd.NextDouble()));
			}

			Trace.Assert(setOfAllColours.Count == pixelCount);

			return setOfAllColours;
		}
	}
}
