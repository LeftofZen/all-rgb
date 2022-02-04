﻿using System;
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
			double delta, min;
			double h = 0, s, b;

			min = Math.Min(Math.Min(rgb.R, rgb.G), rgb.B);
			b = Math.Max(Math.Max(rgb.R, rgb.G), rgb.B);
			delta = b - min;

			if (b == 0.0)
				s = 0;
			else
				s = delta / b;

			if (s == 0)
				h = 0.0;

			else
			{
				if (rgb.R == b)
					h = (rgb.G - rgb.B) / delta;
				else if (rgb.G == b)
					h = 2 + (rgb.B - rgb.R) / delta;
				else if (rgb.B == b)
					h = 4 + (rgb.R - rgb.G) / delta;

				h *= 60;

				if (h < 0.0)
					h = h + 360;
			}

			return new HSB { Hue = (float)h / 360f, Saturation = (float)s, Brightness = (float)b };
		}

		public static RGB HSBtoRGB(HSB hsb)
		{
			double r = 0, g = 0, b = 0;

			if (hsb.Saturation == 0)
			{
				r = hsb.Brightness;
				g = hsb.Brightness;
				b = hsb.Brightness;
			}
			else
			{
				int i;
				double f, p, q, t;

				hsb.Hue = (360 * hsb.Hue);

				if ((int)hsb.Hue == 360)
					hsb.Hue = 0;
				else
					hsb.Hue = hsb.Hue / 60;

				i = (int)Math.Truncate(hsb.Hue);
				f = hsb.Hue - i;

				p = hsb.Brightness * (1.0 - hsb.Saturation);
				q = hsb.Brightness * (1.0 - (hsb.Saturation * f));
				t = hsb.Brightness * (1.0 - (hsb.Saturation * (1.0 - f)));

				switch (i)
				{
					case 0:
						r = hsb.Brightness;
						g = t;
						b = p;
						break;

					case 1:
						r = q;
						g = hsb.Brightness;
						b = p;
						break;

					case 2:
						r = p;
						g = hsb.Brightness;
						b = t;
						break;

					case 3:
						r = p;
						g = q;
						b = hsb.Brightness;
						break;

					case 4:
						r = t;
						g = p;
						b = hsb.Brightness;
						break;

					default:
						r = hsb.Brightness;
						g = p;
						b = q;
						break;
				}
			}

			return new RGB { R = (float)r, G = (float)g, B = (float)b };
		}
	}
}
