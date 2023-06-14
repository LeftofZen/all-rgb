namespace procgenart_core
{
	public static class ColourHelpers
	{
		public static Colour AverageRGB(IEnumerable<Colour> colours)
		{
			var total = new Colour();
			foreach (var c in colours)
			{
				total.R += c.R;
				total.G += c.G;
				total.B += c.B;
			}

			total.R /= colours.Count();
			total.G /= colours.Count();
			total.B /= colours.Count();
			return total;
		}

		public static Colour AverageHSB(IEnumerable<Colour> colours)
		{
			var total = new Colour();
			foreach (var c in colours)
			{
				total.Hue += c.Hue;
				total.Saturation += c.Saturation;
				total.Brightness += c.Brightness;
			}

			total.Hue /= colours.Count();
			total.Saturation /= colours.Count();
			total.Brightness /= colours.Count();
			return total;
		}
	}
}
