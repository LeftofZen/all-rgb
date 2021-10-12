using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb
{
	public static class ColourSpaceConverter
	{
		public static HSB RGBtoHSB(RGB rgb)
		{
			HSB outHsb = new();
			var r = rgb.R; // / 255.0f;
			var g = rgb.G; // / 255.0f;
			var b = rgb.B; // / 255.0f;

			var max = (float)Math.Max(Math.Max(r, g), b);
			var min = (float)Math.Min(Math.Min(r, g), b);
			var delta = max - min;

			if (delta != 0)
			{
				float hue;
				if (r == max)
				{
					hue = (g - b) / delta;
				}
				else
				{
					hue = g == max
						? 2 + (b - r) / delta
						: 4 + (r - g) / delta;
				}
				hue *= 60;

				if (hue < 0)
					hue += 360;

				outHsb.Hue = hue / 360f;
			}

			else
			{
				outHsb.Hue = 0;
			}
			outHsb.Saturation = max == 0 ? 0 : (max - min) / max;
			outHsb.Brightness = max;

			return outHsb;
		}

		public static RGB HSBtoRGB(HSB hsb)
		{
			double red = 0, green = 0, blue = 0;

			double h = hsb.Hue;
			var s = (double)hsb.Saturation; /// 100;
			var b = (double)hsb.Brightness; /// 100;

			if (Math.Abs(s - 0) < double.Epsilon)
			{
				red = b;
				green = b;
				blue = b;
			}
			else
			{
				// the color wheel has six sectors.

				var sectorPosition = h * 6; // / 60;
				var sectorNumber = (int)Math.Floor(sectorPosition);
				var fractionalSector = sectorPosition - sectorNumber;

				var p = b * (1 - s);
				var q = b * (1 - s * fractionalSector);
				var t = b * (1 - s * (1 - fractionalSector));

				// Assign the fractional colors to r, g, and b
				// based on the sector the angle is in.
				switch (sectorNumber)
				{
					case 0:
						red = b;
						green = t;
						blue = p;
						break;

					case 1:
						red = q;
						green = b;
						blue = p;
						break;

					case 2:
						red = p;
						green = b;
						blue = t;
						break;

					case 3:
						red = p;
						green = q;
						blue = b;
						break;

					case 4:
						red = t;
						green = p;
						blue = b;
						break;

					case 5:
						red = b;
						green = p;
						blue = q;
						break;
				}
			}

			//var nRed = Convert.ToInt32(red );
			//var nGreen = Convert.ToInt32(green );
			//var nBlue = Convert.ToInt32(blue);

			return new RGB { R = (float)red, G = (float)green, B = (float)blue };
		}
	}
}
