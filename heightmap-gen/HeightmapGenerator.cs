using Zenith.Colour;
using Zenith.Core;
using Zenith.Drawing;

namespace heightmap_gen
{
	public interface IGenerator
	{
		void Generate<T>(T generateParams, int width, int height);
		ImageBuffer CurrentBuffer { get; }
		// event GenerationComplete
	}

	public record HeightmapParams(double scale, double xOffset, double yOffset, long? seed = null);

	public class HeightmapGenerator : IGenerator
	{
		public ImageBuffer CurrentBuffer { get; private set; }

		public HeightmapGenerator()
			=> CurrentBuffer = new ImageBuffer(1, 1);

		OpenSimplexNoise osn = new(1);

		public void Generate<T>(T param, int width, int height)
		{
			if (param is not HeightmapParams hmp)
			{
				throw new ArgumentException($"Inut generate parameter was not of required type HeightmapParams. Actual={typeof(T)}", nameof(param));
			}

			osn = hmp.seed == null ? new() : new(hmp.seed.Value);
			CurrentBuffer = new ImageBuffer(width, height);
			for (var y = 0; y < CurrentBuffer.Height; ++y)
			{
				for (var x = 0; x < CurrentBuffer.Width; ++x)
				{
					var noise = (float)((osn.Evaluate(x * hmp.scale, y * hmp.scale) + 1) / 2.0);
					var col = new ColourRGB(noise, noise, noise);
					CurrentBuffer.SetPixel(x, y, col);
				}
			}
		}
	}

	public record DiamondSquareParams(double roughness, int? seed, double? initialValue = null);

	public class DiamondSquareGenerator : IGenerator
	{
		public ImageBuffer CurrentBuffer { get; private set; }

		public DiamondSquareGenerator()
			=> CurrentBuffer = new ImageBuffer(1, 1);

		Random rnd = new();

		public void Generate<T>(T param, int width, int height)
		{
			if (param is not DiamondSquareParams dsp)
			{
				throw new ArgumentException($"Inut generate parameter was not of required type DiamondSquareParams. Actual={typeof(T)}", nameof(param));
			}

			var initialValue = dsp.initialValue is null or 0 ? rnd.NextDouble() : dsp.initialValue.Value;
			if (dsp.seed != null)
			{
				rnd = new Random(dsp.seed.Value);
			}

			var maxPoints = Math.Max(width, height);
			Verify.Positive(maxPoints);
			// diamond-square requires power-of-2 input sizes;
			// calculate the next highest power of 2 above the max of width and height
			var points = Math.Pow(2, Math.Ceiling(Math.Log2(maxPoints)));

			CurrentBuffer = new ImageBuffer(width, height);
			Console.WriteLine(initialValue);
			var ds = new DiamondSquare((int)points, dsp.roughness, initialValue, rnd);
			var data = ds.GetData();

			var max = double.MinValue;
			var min = double.MaxValue;

			for (var y = 0; y < CurrentBuffer.Height; ++y)
			{
				for (var x = 0; x < CurrentBuffer.Width; ++x)
				{
					max = Math.Max(max, data[x, y]);
					min = Math.Min(min, data[x, y]);
				}
			}

			var range = max - min;

			for (var y = 0; y < CurrentBuffer.Height; ++y)
			{
				for (var x = 0; x < CurrentBuffer.Width; ++x)
				{
					var noise = (float)((data[x, y] - min) / range);
					var col = new ColourRGB(noise, noise, noise);
					CurrentBuffer.SetPixel(x, y, col);
				}
			}
		}
	}
}