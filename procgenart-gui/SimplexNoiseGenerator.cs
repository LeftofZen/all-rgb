using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Zenith.Algorithms;
using Zenith.Drawing;
using Zenith.Maths;
using Zenith.ProceduralGeneration;

namespace all_rgb_gui
{
	public static class SimplexNoiseGenerator
	{
		public static (double[,] data, Vector3[,] normals) Generate(SimplexNoiseParams snp)
		{
			var noise = new OpenSimplexNoise(snp.Seed == 0 ? new Random().NextInt64() : snp.Seed);
			var data = new double[snp.Width, snp.Height];

			double ridgenoise(double x, double y, double frequency) => 2 * (0.5 - Math.Abs(0.5 - noise.Evaluate(x * frequency, y * frequency)));

			for (var y = 0; y < data.GetLength(1); y++)
			{
				for (var x = 0; x < data.GetLength(0); x++)
				{
					var amplitude = (double)snp.InitialAmplitude;
					var frequency = (double)snp.InitialFrequency;
					var totalAmplitude = 0.0;
					var total = 0.0;

					for (var o = 0; o < snp.Octaves; o++)
					{
						//// ridgenoise
						//var e0 = 1 * ridgenoise(1 * xEval, 1 * yEval, frequency);
						//var e1 = 0.5 * ridgenoise(2 * xEval, 2 * yEval, frequency) * e0;
						//var e2 = 0.25 * ridgenoise(4 * xEval, 4 * yEval, frequency) * (e0 + e1);
						//var e = (e0 + e1 + e2) / (1 + 0.5 + 0.25);
						//var exp = 2;
						//var noisev = Math.Pow(e, exp);

						// normal
						var xEval = (x + snp.XOffset) * frequency;
						var yEval = (y + snp.YOffset) * frequency;
						var noisev = noise.Evaluate(xEval, yEval);

						// [[-1, 1] -> [0, 1]
						//noisev = (noisev + 1) / 2;
						noisev *= amplitude;
						total += noisev;

						totalAmplitude += amplitude;
						amplitude *= snp.Persistence;
						frequency *= snp.Lacunarity;
					}

					total = Math.Pow(total, snp.Redistribution);

					// normalise
					total /= totalAmplitude;

					data[x, y] = total;
				}
			}

			data.Normalise();

			if (snp.TerraceCount > 1)
			{
				data.Terrace(snp.TerraceCount);
			}

			var normals = GetNormals(data);
			//var flowmap = FlowMap(data);
			//Erode(data, normals);

			return (data, normals);
		}

		public static Vector2[,] FlowMap(double[,] data)
		{
			var width = data.GetLength(0);
			var height = data.GetLength(1);
			var flows = new Vector2[width, height];

			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					var min = GetNeighbourPoints(data, new Point2(x, y)).MinBy(p => data[p.X, p.Y]);
					if (data[min.X, min.Y] < data[x, y])
					{
						flows[x, y] = new Vector2(min.X - x, min.Y - y);
					}
					else
					{
						flows[x, y] = new Vector2(x, y);
					}
				}
			}

			return flows;
		}

		public static IEnumerable<Point2> GetNeighbourPoints(double[,] data, Point2 p)
		{
			var width = data.GetLength(0);
			var height = data.GetLength(1);

			for (var x = -1; x < 2; ++x)
			{
				for (var y = -1; y < 2; ++y)
				{
					if (x != 0 || y != 0)
					{
						if (p.X + x >= 0 && p.X + x < width && p.Y + y >= 0 && p.Y + y < height)
						{
							yield return new Point2(p.X + x, p.Y + y);
						}
					}
				}
			}
		}

		public static IEnumerable<Point2> GetNeighbourPoints(this ImageBuffer buf, Point2 p)
		{
			for (var x = -1; x < 2; ++x)
			{
				for (var y = -1; y < 2; ++y)
				{
					if (x != 0 || y != 0)
					{
						if (p.X + x >= 0 && p.X + x < buf.Width && p.Y + y >= 0 && p.Y + y < buf.Height)
						{
							yield return new Point2(p.X + x, p.Y + y);
						}
					}
				}
			}
		}

		static Vector3 CalculateNormal(double[,] heightmap, int x, int y, int width, int height)
		{
			var left = heightmap[x > 0 ? x - 1 : x, y];
			var right = heightmap[x < width - 1 ? x + 1 : x, y];
			var up = heightmap[x, y > 0 ? y - 1 : y];
			var down = heightmap[x, y < height - 1 ? y + 1 : y];

			//Vector n1 = Vector3.Normalize(Vector3.Cross(new Vector3()


			var normal = new Vector3((float)(left - right), 0.0f, (float)(up - down));
			return Vector3.Normalize(normal);
		}

		static Vector3[,] GetNormals(double[,] data)
		{
			var width = data.GetLength(0);
			var height = data.GetLength(1);
			var normals = new Vector3[width, height];

			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					normals[x, y] = CalculateNormal(data, x, y, width, height);
				}
			}

			return normals;
		}

		public static void Erode(double[,] data, Vector3[,] normals)
		{
			var raindrops = 100000;
			raindrops = data.GetLength(0) * data.GetLength(1);
			var rnd = new Random();

			//for (var i = 0; i < 10; ++i)
			{
				Parallel.For(0, raindrops, (i) => ErodeCore(data, normals, rnd, i));
			}
		}

		static void ErodeCore(double[,] data, Vector3[,] normals, Random rnd, int i)
		{
			const float minVol = 0.01f;
			const float density = 1f;
			const float friction = 0.1f;
			const float depositionRate = 0.1f;
			const float evapRate = 0.001f;

			var width = data.GetLength(0);
			var height = data.GetLength(1);

			// spawn particle
			//var ix = rnd.Next(0, width);
			//var iy = rnd.Next(0, height);
			var ix = i % width;
			var iy = i / height;

			var speed = Vector2.Zero;

			var volume = 10f; // total particle volume
			var sediment = 0f; // fraction of volume that is sediment

			while (volume > minVol)
			{
				var x = (float)ix;
				var y = (float)iy;

				var normal = normals[(int)x, (int)y];

				// accelerate particle
				speed += new Vector2(normal.X, normal.Z) / (volume * density); //F = ma, so a = F/m
				x += speed.X;
				y += speed.Y;
				speed *= new Vector2(1f - friction); // Friction Factor

				// check particle still in bounds
				if (x < 0 || x >= width || y < 0 || y >= height)
				{
					break;
				}

				// sediment capacity difference
				var maxsediment = volume * speed.Length() * (float)(data[ix, iy] - data[(int)x, (int)y]);
				if (maxsediment < 0f)
					maxsediment = 0f;

				var sdiff = maxsediment - sediment;

				// Act on the Heightmap and Droplet!
				sediment += depositionRate * sdiff;
				data[ix, iy] -= volume * depositionRate * sdiff;

				// Evaporate the Droplet (Note: Proportional to Volume! Better: Use shape factor to make proportional to the area instead.)
				volume *= 1f - evapRate;
			}
		}
	}
}
