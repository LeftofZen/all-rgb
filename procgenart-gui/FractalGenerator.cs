using poisson_disk_sampling;
using System;
using System.Collections.Generic;
using System.Text;
using Zenith.Colour;
using Zenith.Drawing;

namespace all_rgb_gui
{
	public record FractalGeneratorParams(int Width) // width must equal height and iterations is also determined by width/size
		: ParamsBase(Width, Width);

	public class FractalGenerator
	{
		static ColourRGB getColour(int x, int y, ImageBuffer? existingBuffer)
		{
			if (existingBuffer == null)
				return ColourRGB.Black;
			else
				return existingBuffer.GetPixel(x, y);
		}

		public ImageBuffer Generate(FractalGeneratorParams args, ImageBuffer? existingBuffer = null)
		{
			var buffer = new ImageBuffer((int)(args.Width / 4f * 3), (int)(args.Width / 4f * 3));

			for (int y = 0; y < buffer.Height; ++y)
			{
				for (int x = 0; x < buffer.Width; ++x)
				{
					buffer.SetPixel(x, y, ColourRGB.Black);
				}
			}

			//var points = PoissonDiscAlgorithm.Sample2D(args.Width, args.Height, args.R, args.K);
			//foreach (var point in points)
			//{
			//	buffer.SetPixel((int)point.X, (int)point.Y, Zenith.Colour.ColourRGB.Black);
			//}

			var iterations = ((int)Math.Log2(args.Width)) - 3;
			//var iterations = 4;
			var hil = "a"; // initial value
			List<string> levels = [hil];
			for (int i = 0; i < iterations; ++i)
			{
				hil = HilbertReplace(hil);
				levels.Add(hil);
			}

			//var grey = new ColourRGB(0.5f, 0.5f, 0.5f);
			//var grey

			// now walk the buffer and paint
			var currX = 1;
			var currY = buffer.Width - 2;
			// each character paints buffer 36 pixels at a time (a 2x2 grid of 3x3 pixels)
			foreach (var c in hil)
			{
				if (c == 'a')
				{
					buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer)); // bottom-left

					currY = WalkAndPaintUp(buffer, currX, currY, existingBuffer); // top-left
					currX = WalkAndPaintRight(buffer, currX, currY, existingBuffer); // top-right
					currY = WalkAndPaintDown(buffer, currX, currY, existingBuffer); // bottom-right
				}
				if (c == 'b')
				{
					buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer)); // top-right

					currX = WalkAndPaintLeft(buffer, currX, currY, existingBuffer); // top-left
					currY = WalkAndPaintDown(buffer, currX, currY, existingBuffer); // bottom-left
					currX = WalkAndPaintRight(buffer, currX, currY, existingBuffer); // bottom-right
				}
				if (c == 'c')
				{
					buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer)); // top-right

					currY = WalkAndPaintDown(buffer, currX, currY, existingBuffer); // bottom-right
					currX = WalkAndPaintLeft(buffer, currX, currY, existingBuffer); // bottom-left
					currY = WalkAndPaintUp(buffer, currX, currY, existingBuffer); // top-left
				}
				if (c == 'd')
				{
					buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer)); // bottom-left

					currX = WalkAndPaintRight(buffer, currX, currY, existingBuffer); // bottom-right
					currY = WalkAndPaintUp(buffer, currX, currY, existingBuffer); // top-right
					currX = WalkAndPaintLeft(buffer, currX, currY, existingBuffer); // top-left
				}

				if (c == '←')
				{
					currX = WalkAndPaintLeft(buffer, currX, currY, existingBuffer);
				}
				if (c == '→')
				{
					currX = WalkAndPaintRight(buffer, currX, currY, existingBuffer);
				}
				if (c == '↑')
				{
					currY = WalkAndPaintUp(buffer, currX, currY, existingBuffer);
				}
				if (c == '↓')
				{
					currY = WalkAndPaintDown(buffer, currX, currY, existingBuffer);
				}
			}

			return buffer;
		}

		private static int WalkAndPaintLeft(ImageBuffer buffer, int currX, int currY, ImageBuffer? existingBuffer)
		{
			currX--;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currX--;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currX--;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			return currX;
		}
		private static int WalkAndPaintRight(ImageBuffer buffer, int currX, int currY, ImageBuffer? existingBuffer)
		{
			currX++;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currX++;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currX++;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			return currX;
		}
		private static int WalkAndPaintUp(ImageBuffer buffer, int currX, int currY, ImageBuffer? existingBuffer)
		{
			currY--;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currY--;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currY--;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			return currY;
		}
		private static int WalkAndPaintDown(ImageBuffer buffer, int currX, int currY, ImageBuffer? existingBuffer)
		{
			currY++;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currY++;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			currY++;
			buffer.SetPixel(currX, currY, getColour(currX, currY, existingBuffer));
			return currY;
		}

		static string HilbertReplace(string curve)
		{
			var sb = new StringBuilder();
			foreach (var c in curve)
			{
				sb.Append(HilbertReplaceC(c));
			}
			return sb.ToString();
		}

		static string HilbertReplaceC(char c)
		{
			if (c == 'a')
			{
				return "d↑a→a↓b";
			}
			if (c == 'b')
			{
				return "c←b↓b→a";
			}
			if (c == 'c')
			{
				return "b↓c←c↑d";
			}
			if (c == 'd')
			{
				return "a→d↑d←c";
			}
			else
			{
				return $"{c}"; // should be an arrow
			}
		}
	}
}
