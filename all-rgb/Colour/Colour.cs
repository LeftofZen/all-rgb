using System;
using System.Collections.Generic;
using System.Linq;

namespace all_rgb
{
	public struct RGB : IVector3Float, IEquatable<RGB>
	{
		public float R { get; set; }
		public float G { get; set; }
		public float B { get; set; }

		// IVector4

		//public float W { get => A; set => A = value; }
		public float X { get => R; set => R = value; }
		public float Y { get => G; set => G = value; }
		public float Z { get => B; set => B = value; }

		public bool Equals(RGB other)
			=> R == other.R
			&& G == other.G
			&& B == other.B;

		public override string ToString()
			=> $"RGB=[{R},{G},{B}]";
	}

	public struct HSB : IVector3Float, IEquatable<HSB>
	{
		public float Hue { get; set; }
		public float Saturation { get; set; }
		public float Brightness { get; set; }

		// IVector4
		//public float W { get => Alpha; set => Alpha = value; }
		public float X { get => Hue; set => Hue = value; }
		public float Y { get => Saturation; set => Saturation = value; }
		public float Z { get => Brightness; set => Brightness = value; }

		public bool Equals(HSB other)
			=> Hue == other.Hue
			&& Saturation == other.Saturation
			&& Brightness == other.Brightness;
		public override string ToString()
			=> $"HSB=[{Hue},{Saturation},{Brightness}]";
	}

	public struct Colour : IEquatable<Colour>
	{
		public float A { get; set; }

		public float R { get => _rgb.R; set { _rgb.R = value; _hsb = ColourSpaceConverter.RGBtoHSB(rgb); } }
		public float G { get => _rgb.G; set { _rgb.G = value; _hsb = ColourSpaceConverter.RGBtoHSB(rgb); } }
		public float B { get => _rgb.B; set { _rgb.B = value; _hsb = ColourSpaceConverter.RGBtoHSB(rgb); } }

		public float Hue { get => _hsb.Hue; set { _hsb.Hue = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		public float Saturation { get => _hsb.Saturation; set { _hsb.Saturation = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		public float Brightness { get => _hsb.Brightness; set { _hsb.Brightness = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }

		public RGB rgb { get => _rgb; private set { _rgb = value; _hsb = ColourSpaceConverter.RGBtoHSB(rgb); } }
		RGB _rgb;

		public HSB hsb { get => _hsb; private set { _hsb = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		HSB _hsb;

		public static bool operator ==(Colour a, Colour b)
			=> a.Equals(b);

		public static bool operator !=(Colour a, Colour b)
			=> !(a == b);

		public System.Drawing.Color ToSystemColor()
			=> System.Drawing.Color.FromArgb((int)(A * 255), (int)(R * 255), (int)(G * 255), (int)(B * 255));

		public static Colour FromSystemColor(System.Drawing.Color c)
			=> new() { A = c.A / 255f, rgb = new RGB { R = c.R / 255f, G = c.G / 255f, B = c.B / 255f } };

		public static Colour FromRGB(float r, float g, float b)
			=> new() { A = 1f, rgb = new RGB { R = r, G = g, B = b } };

		public static Colour FromRGB(RGB rgb_)
			=> new() { A = 1f, rgb = rgb_ };

		public static Colour FromHSB(float h, float s, float b)
			=> new() { A = 1f, hsb = new HSB { Hue = h, Saturation = s, Brightness = b } };

		public static Colour FromHSB(HSB hsb_)
			=> new() { A = 1f, hsb = hsb_ };

		public bool Equals(Colour other)
			=> rgb.Equals(other._rgb) && hsb.Equals(other._hsb);

		public override bool Equals(object obj)
			=> obj is Colour && Equals((Colour)obj);

		public override int GetHashCode()
			=> HashCode.Combine(_rgb.R, _rgb.G, _rgb.B);
		public override string ToString()
			=> $"{_rgb} {_hsb}";
	}

	public static class ColourHelpers
	{
		public static Colour Average(IEnumerable<Colour> colours)
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

	public class RGBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.rgb.R + a.rgb.B + a.rgb.G).CompareTo(b.rgb.R + b.rgb.B + b.rgb.G);
	}

	public class RGBComponentColorComparer : IComparer<Colour>
	{
		int rMult;
		int gMult;
		int bMult;

		public RGBComponentColorComparer(RGBComparerComponents rgbCompoents)
		{
			if (rgbCompoents == RGBComparerComponents.Empty)
				throw new ArgumentException("RGBComparerComponents cannot be empty");

			rMult = (int)(rgbCompoents & RGBComparerComponents.Red) >> (int)(RGBComparerComponents.Red - 1);
			gMult = (int)(rgbCompoents & RGBComparerComponents.Green) >> (int)(RGBComparerComponents.Green - 1);
			bMult = (int)(rgbCompoents & RGBComparerComponents.Blue) >> (int)(RGBComparerComponents.Blue - 1);
		}

		public int Compare(Colour a, Colour b)
			=> (rMult * a.rgb.R.CompareTo(b.rgb.R))
			+ (gMult * a.rgb.G.CompareTo(b.rgb.G))
			+ (bMult * a.rgb.B.CompareTo(b.rgb.B));
	}

	public class HSBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.hsb.Hue + a.hsb.Saturation + a.hsb.Brightness).CompareTo(b.hsb.Hue + b.hsb.Saturation + b.hsb.Brightness);
	}
	public class HSBComponentColorComparer : IComparer<Colour>
	{
		int hMult;
		int sMult;
		int bMult;

		public HSBComponentColorComparer(HSBComparerComponents hsbCompoents)
		{
			if (hsbCompoents == HSBComparerComponents.Empty)
				throw new ArgumentException("HSBComparerComponents cannot be empty");

			hMult = (int)(hsbCompoents & HSBComparerComponents.Hue) >> (int)(HSBComparerComponents.Hue-1);
			sMult = (int)(hsbCompoents & HSBComparerComponents.Saturation) >> (int)(HSBComparerComponents.Saturation - 1);
			bMult = (int)(hsbCompoents & HSBComparerComponents.Brightness) >> (int)(HSBComparerComponents.Brightness - 1);
		}

		public int Compare(Colour a, Colour b)
			=> (hMult * a.hsb.Hue.CompareTo(b.hsb.Hue))
			+ (sMult * a.hsb.Saturation.CompareTo(b.hsb.Saturation))
			+ (bMult * a.hsb.Brightness.CompareTo(b.hsb.Brightness));
	}

	[Flags]
	public enum HSBComparerComponents { Empty = 0, Hue = 1, Saturation = 2, Brightness = 4 };

	[Flags]
	public enum RGBComparerComponents { Empty = 0, Red = 1, Green = 2, Blue = 4 };

}
