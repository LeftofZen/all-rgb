namespace procgenart_core
{
	public class RGBComponentColorComparer : IComparer<Colour>
	{
		readonly int rMult;
		readonly int gMult;
		readonly int bMult;

		public RGBComponentColorComparer(RGBComparerComponents rgbComponents)
		{
			if (rgbComponents == RGBComparerComponents.Empty)
			{
				throw new ArgumentException("RGBComparerComponents cannot be empty");
			}

			rMult = (int)(rgbComponents & RGBComparerComponents.Red) >> 0;
			gMult = (int)(rgbComponents & RGBComparerComponents.Green) >> 1;
			bMult = (int)(rgbComponents & RGBComparerComponents.Blue) >> 2;
		}

		public int Compare(Colour a, Colour b)
			=> rMult * a.RGB.R.CompareTo(b.RGB.R)
			+ gMult * a.RGB.G.CompareTo(b.RGB.G)
			+ bMult * a.RGB.B.CompareTo(b.RGB.B);
	}

}
