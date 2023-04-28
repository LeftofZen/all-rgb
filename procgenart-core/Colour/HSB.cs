namespace procgenart_core
{
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
}
