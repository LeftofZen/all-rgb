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
		public static HashSet<Colour> GenerateColours(int pixelCount)
		{
			Console.WriteLine("Generating colours");

			if (pixelCount == 0)
			{
				Console.WriteLine("no pixels");
				return new HashSet<Colour>();
			}

			var setOfAllColours = new HashSet<Colour>(pixelCount);

			var stepsPerChannel = (int)Math.Pow(pixelCount, 1f / 3f);
			var stepSize = 1f / stepsPerChannel;
			var rSteps = stepsPerChannel;
			var gSteps = stepsPerChannel;
			var bSteps = stepsPerChannel;

			var minVal = 0.1f;
			var maxVal = 0.9f;

			for (var r = 0; r < rSteps; ++r)
			{
				for (var g = 0; g < gSteps; ++g)
				{
					for (var b = 0; b < bSteps; ++b)
					{
						var rr = stepSize * r;
						var gg = stepSize * g;
						var bb = stepSize * b;

						//rr = RescaleFloat(rr, minVal, maxVal);
						//gg = RescaleFloat(gg, minVal, maxVal);
						//bb = RescaleFloat(bb, minVal, maxVal);

						var c = Colour.FromRGB(rr, gg, bb);
						//var c = Colour.FromHSB(rr, gg, bb);
						//const bool Pastel = true;

						//if (Pastel)
						//{
						//	// need to replace System.Drawing.Colour with our own colour struct
						//}

						if (setOfAllColours.Add(c))
						{
							Trace.Assert(false, "duplicate colour detected", c.ToString());
						}
					}
				}
			}

			//sw.Stop();

			var rnd = new Random(1);
			// leftover
			while (setOfAllColours.Count < pixelCount)
			{
				Trace.Assert(setOfAllColours.Add(Colour.FromRGB(
					(float)rnd.NextDouble(),
					(float)rnd.NextDouble(),
					(float)rnd.NextDouble()
					)));
			}

			Trace.Assert(setOfAllColours.Count >= pixelCount);

			return setOfAllColours;
		}
	}
}
