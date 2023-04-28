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
}
