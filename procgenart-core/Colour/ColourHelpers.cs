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
	}
}
