using System;
using System.Collections.Generic;

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

		public static Colour FromRGB(RGB _rgb)
			=> new() { A = 1f, _rgb = _rgb };

		public static Colour FromHSB(float h, float s, float b)
			=> new() { hsb = new HSB { Hue = h, Saturation = s, Brightness = b } };

		public static Colour FromHSB(HSB _hsb)
			=> new() { hsb = _hsb };

		public bool Equals(Colour other)
			=> rgb.Equals(other._rgb) && hsb.Equals(other._hsb);

		public override bool Equals(object obj)
			=> obj is Colour && Equals((Colour)obj);

		public override int GetHashCode()
			=> HashCode.Combine(_rgb.R, _rgb.G, _rgb.B);
	}

	public class RGBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.rgb.R + a.rgb.B + a.rgb.G).CompareTo(b.rgb.R + b.rgb.B + b.rgb.G);
	}

	public class HSBSumColorComparer : IComparer<Colour>
	{
		public int Compare(Colour a, Colour b)
			=> (a.hsb.Hue + a.hsb.Saturation + a.hsb.Brightness).CompareTo(b.hsb.Hue + b.hsb.Saturation + b.hsb.Brightness);
	}
}
