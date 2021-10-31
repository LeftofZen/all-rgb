using System;
using System.Collections.Generic;

namespace all_rgb
{
	public class RGBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.RGB.R + a.RGB.B + a.RGB.G).CompareTo(b.RGB.R + b.RGB.B + b.RGB.G);
	}

	public class RGBComponentColorComparer : IComparer<Colour>
	{
		readonly int rMult;
		readonly int gMult;
		readonly int bMult;

		public RGBComponentColorComparer(RGBComparerComponents rgbCompoents)
		{
			if (rgbCompoents == RGBComparerComponents.Empty)
			{
				throw new ArgumentException("RGBComparerComponents cannot be empty");
			}

			rMult = (int)(rgbCompoents & RGBComparerComponents.Red) >> (int)(RGBComparerComponents.Red - 1);
			gMult = (int)(rgbCompoents & RGBComparerComponents.Green) >> (int)(RGBComparerComponents.Green - 1);
			bMult = (int)(rgbCompoents & RGBComparerComponents.Blue) >> (int)(RGBComparerComponents.Blue - 1);
		}

		public int Compare(Colour a, Colour b)
			=> (rMult * a.RGB.R.CompareTo(b.RGB.R))
			+ (gMult * a.RGB.G.CompareTo(b.RGB.G))
			+ (bMult * a.RGB.B.CompareTo(b.RGB.B));
	}

	public class HSBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.HSB.Hue + a.HSB.Saturation + a.HSB.Brightness).CompareTo(b.HSB.Hue + b.HSB.Saturation + b.HSB.Brightness);
	}
	public class HSBComponentColorComparer : IComparer<Colour>
	{
		readonly int hMult;
		readonly int sMult;
		readonly int bMult;

		public HSBComponentColorComparer(HSBComparerComponents hsbCompoents)
		{
			if (hsbCompoents == HSBComparerComponents.Empty)
			{
				throw new ArgumentException("HSBComparerComponents cannot be empty");
			}

			hMult = (int)(hsbCompoents & HSBComparerComponents.Hue) >> (int)(HSBComparerComponents.Hue - 1);
			sMult = (int)(hsbCompoents & HSBComparerComponents.Saturation) >> (int)(HSBComparerComponents.Saturation - 1);
			bMult = (int)(hsbCompoents & HSBComparerComponents.Brightness) >> (int)(HSBComparerComponents.Brightness - 1);
		}

		public int Compare(Colour a, Colour b)
			=> (hMult * a.HSB.Hue.CompareTo(b.HSB.Hue))
			+ (sMult * a.HSB.Saturation.CompareTo(b.HSB.Saturation))
			+ (bMult * a.HSB.Brightness.CompareTo(b.HSB.Brightness));
	}

	[Flags]
	public enum HSBComparerComponents { Empty = 0, Hue = 1, Saturation = 2, Brightness = 4 };

	[Flags]
	public enum RGBComparerComponents { Empty = 0, Red = 1, Green = 2, Blue = 4 };

}
