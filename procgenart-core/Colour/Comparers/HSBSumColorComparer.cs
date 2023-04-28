namespace procgenart_core
{
	public class HSBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.HSB.Hue + a.HSB.Saturation + a.HSB.Brightness).CompareTo(b.HSB.Hue + b.HSB.Saturation + b.HSB.Brightness);
	}

}
