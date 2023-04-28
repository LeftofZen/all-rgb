namespace procgenart_core
{
	public class RGBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.RGB.R + a.RGB.B + a.RGB.G).CompareTo(b.RGB.R + b.RGB.B + b.RGB.G);
	}

}
