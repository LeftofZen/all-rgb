using System.Numerics;

namespace poisson_disk_sampling
{
	internal class PoissonDiskSampler
	{
	}

	static class Extension
	{
		public static float Range(this Random random, float max)
			=> random.Range(0f, max);

		public static float Range(this Random random, float min, float max)
			=> min + (float)random.NextDouble() * (max - min);

		public static int Range(this Random random, int max)
			=> random.Range(0, max);

		public static int Range(this Random random, int min, int max)
			=> (int)Math.Floor(min + (float)random.NextDouble() * (max - min));

		public static Vector2 InsideUnitCircle(this Random random)
		{
			var angle = (float)random.NextDouble() * 2f * Math.PI;
			var r = (float)random.NextDouble();
			return new Vector2(
				r * (float)Math.Cos(angle),
				r * (float)Math.Sin(angle));
		}

		public static Vector2 Normalised(this Vector2 vector2)
		{
			var length = vector2.LengthSquared();
			return
				length > kEpsilon
				? vector2 / length
				: Vector2.Zero;
		}

		public const float kEpsilon = 0.00001f;
	}

	/// <summary>
	/// @see https://www.cs.ubc.ca/~rbridson/docs/bridson-siggraph07-poissondisk.pdf
	/// @param r The minimum distance r between samples
	/// @param k The limit of samples to choose before rejection in the algorithm (typically k = 30)
	/// </summary>
	public static class Algorithm
	{
		public static List<Vector2> Sample2D(float width, float height, float r, int k = 30)
			=> Sample2D((int)DateTime.Now.Ticks, width, height, r, k);

		//https://www.cs.ubc.ca/~rbridson/docs/bridson-siggraph07-poissondisk.pdf
		public static List<Vector2> Sample2D(int seed, float width, float height, float r, int k = 30)
		{
			// STEP 0

			const int n = 2;
			var cellSize = r / Math.Sqrt(n);

			var cols = (int)Math.Ceiling(width / cellSize);
			var rows = (int)Math.Ceiling(height / cellSize);

			var cells = new List<Vector2>();

			var grids = new int[rows, cols];
			for (var i = 0; i < rows; ++i)
			{
				for (var j = 0; j < cols; ++j)
				{
					grids[i, j] = -1;
				}
			}

			// STEP 1
			var random = new Random(seed);

			var x0 = new Vector2(random.Range(width), random.Range(height));
			var col = (int)Math.Floor(x0.X / cellSize);
			var row = (int)Math.Floor(x0.Y / cellSize);

			var x0_idx = cells.Count;
			cells.Add(x0);
			grids[row, col] = x0_idx;

			var active_list = new List<int>
			{
				x0_idx
			};

			// STEP 2
			while (active_list.Count > 0)
			{
				var xi_idx = active_list[random.Range(active_list.Count)];
				var xi = cells[xi_idx];
				var found = false;

				for (var i = 0; i < k; ++i)
				{
					var dir = random.InsideUnitCircle();
					var norm = dir.Normalised();
					var xk = xi + (norm * r + dir * r); // [r,2r)
					if (xk.X < 0 || xk.X >= width || xk.Y < 0 || xk.Y >= height)
					{
						continue;
					}

					col = (int)Math.Floor(xk.X / cellSize);
					row = (int)Math.Floor(xk.Y / cellSize);

					if (grids[row, col] != -1)
					{
						continue;
					}

					var ok = true;
					var min_r = (int)Math.Floor((xk.Y - r) / cellSize);
					var max_r = (int)Math.Floor((xk.Y + r) / cellSize);
					var min_c = (int)Math.Floor((xk.X - r) / cellSize);
					var max_c = (int)Math.Floor((xk.X + r) / cellSize);
					for (var or = min_r; or <= max_r; ++or)
					{
						if (or < 0 || or >= rows)
						{
							continue;
						}

						for (var oc = min_c; oc <= max_c; ++oc)
						{
							if (oc < 0 || oc >= cols)
							{
								continue;
							}

							var xj_idx = grids[or, oc];
							if (xj_idx != -1)
							{
								var xj = cells[xj_idx];
								var dist = (xj - xk).LengthSquared();
								if (dist < r)
								{
									ok = false;
									goto end_of_distance_check;
								}
							}
						}
					}

				end_of_distance_check:
					if (ok)
					{
						var xk_idx = cells.Count;
						cells.Add(xk);

						grids[row, col] = xk_idx;
						active_list.Add(xk_idx);

						found = true;
						break;
					}
				}

				if (!found)
				{
					_ = active_list.Remove(xi_idx);
				}
			}

			return cells;
		}
	}
}
