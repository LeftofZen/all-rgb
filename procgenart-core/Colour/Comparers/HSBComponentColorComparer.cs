namespace procgenart_core
{
	public class HSBComponentColorComparer : IComparer<Colour>
	{
		readonly int hMult;
		readonly int sMult;
		readonly int bMult;

		public HSBComponentColorComparer(HSBComparerComponents hsbComponents)
		{
			if (hsbComponents == HSBComparerComponents.Empty)
			{
				throw new ArgumentException("HSBComparerComponents cannot be empty");
			}

			hMult = (int)(hsbComponents & HSBComparerComponents.Hue) >> 0;
			sMult = (int)(hsbComponents & HSBComparerComponents.Saturation) >> 1;
			bMult = (int)(hsbComponents & HSBComparerComponents.Brightness) >> 2;
		}

		public int Compare(Colour a, Colour b)
			=> hMult * a.HSB.Hue.CompareTo(b.HSB.Hue)
			+ sMult * a.HSB.Saturation.CompareTo(b.HSB.Saturation)
			+ bMult * a.HSB.Brightness.CompareTo(b.HSB.Brightness);
	}

}
