namespace all_rgb_gui
{
	public class RidgeNoiseParams
	{
		public RidgeNoiseParams(int width, int height, int seed, float exponent)
		{
			Width = width;
			Height = height;
			Seed = seed;
			Exponent = exponent;
		}

		public int Width { get; set; }
		public int Height { get; set; }
		public int Seed { get; set; }
		public float Exponent { get; set; }
	}
}
