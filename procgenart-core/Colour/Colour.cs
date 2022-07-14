namespace procgenart_core
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

		public override string ToString()
			=> $"RGB=[{R},{G},{B}]";

		public bool Equals(RGB other)
			=> R == other.R
			&& G == other.G
			&& B == other.B;

		public override bool Equals(object obj)
			=> obj is RGB rgb && Equals(rgb);

		public static bool operator ==(RGB left, RGB right)
			=> left.Equals(right);

		public static bool operator !=(RGB left, RGB right)
			=> !(left == right);

		public override int GetHashCode()
			=> HashCode.Combine(R, G, B);
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

		public override string ToString()
			=> $"HSB=[{Hue},{Saturation},{Brightness}]";

		public bool Equals(HSB other)
			=> Hue == other.Hue
			&& Saturation == other.Saturation
			&& Brightness == other.Brightness;

		public override bool Equals(object obj)
			=> obj is HSB hsb && Equals(hsb);

		public static bool operator ==(HSB left, HSB right)
			=> left.Equals(right);

		public static bool operator !=(HSB left, HSB right)
			=> !(left == right);

		public override int GetHashCode()
			=> HashCode.Combine(Hue, Saturation, Brightness);
	}

	public struct Colour : IEquatable<Colour>
	{
		public float A { get; set; }

		public float R { get => _rgb.R; set { _rgb.R = value; _hsb = ColourSpaceConverter.RGBtoHSB(RGB); } }
		public float G { get => _rgb.G; set { _rgb.G = value; _hsb = ColourSpaceConverter.RGBtoHSB(RGB); } }
		public float B { get => _rgb.B; set { _rgb.B = value; _hsb = ColourSpaceConverter.RGBtoHSB(RGB); } }

		public float Hue { get => _hsb.Hue; set { _hsb.Hue = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		public float Saturation { get => _hsb.Saturation; set { _hsb.Saturation = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		public float Brightness { get => _hsb.Brightness; set { _hsb.Brightness = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }

		public RGB RGB { get => _rgb; private set { _rgb = value; _hsb = ColourSpaceConverter.RGBtoHSB(RGB); } }
		RGB _rgb;

		public HSB HSB { get => _hsb; private set { _hsb = value; _rgb = ColourSpaceConverter.HSBtoRGB(_hsb); } }
		HSB _hsb;

		public static bool operator ==(Colour a, Colour b)
			=> a.Equals(b);

		public static bool operator !=(Colour a, Colour b)
			=> !(a == b);

		public System.Drawing.Color ToSystemColor()
			=> System.Drawing.Color.FromArgb((int)(A * 255), (int)(R * 255), (int)(G * 255), (int)(B * 255));

		public static Colour FromSystemColor(System.Drawing.Color c)
			=> new() { A = c.A / 255f, RGB = new RGB { R = c.R / 255f, G = c.G / 255f, B = c.B / 255f } };

		public static Colour FromRGB(float r, float g, float b)
			=> new() { A = 1f, RGB = new RGB { R = r, G = g, B = b } };

		public static Colour FromRGB(RGB rgb_)
			=> new() { A = 1f, RGB = rgb_ };

		public static Colour FromHSB(float h, float s, float b)
			=> new() { A = 1f, HSB = new HSB { Hue = h, Saturation = s, Brightness = b } };

		public static Colour FromHSB(HSB hsb_)
			=> new() { A = 1f, HSB = hsb_ };

		public bool Equals(Colour other)
			=> RGB.Equals(other._rgb) && HSB.Equals(other._hsb);

		public override bool Equals(object obj)
			=> obj is Colour colour && Equals(colour);

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
}
