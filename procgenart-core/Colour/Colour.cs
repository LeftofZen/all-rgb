using System.Drawing;

namespace procgenart_core
{
	public struct Colour : IEquatable<Colour>
	{
		public float A { get; set; }

		public float R { get => _rgb.R; set { _rgb.R = value; _hsb = ColourSpaceConverter.RGBtoHSB(_rgb); } }
		public float G { get => _rgb.G; set { _rgb.G = value; _hsb = ColourSpaceConverter.RGBtoHSB(_rgb); } }
		public float B { get => _rgb.B; set { _rgb.B = value; _hsb = ColourSpaceConverter.RGBtoHSB(_rgb); } }

		public float Hue { get => _hsb.Hue; set { _hsb.Hue = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		public float Saturation { get => _hsb.Saturation; set { _hsb.Saturation = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		public float Brightness { get => _hsb.Brightness; set { _hsb.Brightness = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }

		public RGB RGB { get => _rgb; private set { _rgb = value; _hsb = ColourSpaceConverter.RGBtoHSB(_rgb); } }
		RGB _rgb;

		public HSB HSB { get => _hsb; private set { _hsb = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		HSB _hsb;

		public static bool operator ==(Colour a, Colour b)
			=> a.Equals(b);

		public static bool operator !=(Colour a, Colour b)
			=> !(a == b);

		public static Colour FromSystemColor(Color c)
			=> new() { A = c.A / 255f, RGB = new RGB { R = c.R / 255f, G = c.G / 255f, B = c.B / 255f } };

		public Color ToSystemColor()
			=> Color.FromArgb((int)(A * 255), (int)(R * 255), (int)(G * 255), (int)(B * 255));

		public static Colour FromRGB(float r, float g, float b)
			=> new() { A = 1f, RGB = new RGB { R = r, G = g, B = b } };

		public static Colour FromRGB(RGB rgb_)
			=> new() { A = 1f, RGB = rgb_ };

		public static Colour FromHSB(float h, float s, float b)
			=> new() { A = 1f, HSB = new HSB { Hue = h, Saturation = s, Brightness = b } };

		public static Colour FromHSB(HSB hsb_)
			=> new() { A = 1f, HSB = hsb_ };

		public bool Equals(Colour other)
			=> _rgb.Equals(other._rgb) && _hsb.Equals(other._hsb);

		public override bool Equals(object obj)
			=> obj is Colour colour && Equals(colour);

		public override int GetHashCode()
			=> HashCode.Combine(_rgb.R, _rgb.G, _rgb.B);
		public override string ToString()
			=> $"{_rgb} {_hsb}";
	}
}
