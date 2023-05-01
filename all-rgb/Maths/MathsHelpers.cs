using System;

namespace all_rgb
{
	public static class MathsHelpers
	{
		public static float DistanceSquaredEuclidean(IVector3Float a, IVector3Float b)
			=> ((a.X - b.X) * (a.X - b.X))
			 + ((a.Y - b.Y) * (a.Y - b.Y))
			 + ((a.Z - b.Z) * (a.Z - b.Z));

		// unbelievable you can't do this in c#, this is basic stuff in c++
		//public static float DistanceSquaredEuclidean<T>(Colour a, Colour b) where T : IEquatable<RGB>
		//	=> DistanceSquaredEuclidean(a.rgb, b.rgb);
		//public static float DistanceSquaredEuclidean<T>(Colour a, Colour b) where T : IEquatable<HSB>
		//	=> DistanceSquaredEuclidean(a.rgb, b.rgb);

		public static float DistanceEuclidean(IVector3Float a, IVector3Float b)
			=> (float)Math.Sqrt(DistanceSquaredEuclidean(a, b));

		public static float DistanceManhattan(IVector3Float a, IVector3Float b)
			=> Math.Abs(a.X - b.X)
			 + Math.Abs(a.Y - b.Y)
			 + Math.Abs(a.Z - b.Z);

		public static float DistanceSquaredEuclidean(System.Drawing.Point a, System.Drawing.Point b)
			=> ((a.X - b.X) * (a.X - b.X))
			 + ((a.Y - b.Y) * (a.Y - b.Y));

		public static float DistanceEuclidean(System.Drawing.Point a, System.Drawing.Point b)
			=> (float)Math.Sqrt(DistanceSquaredEuclidean(a, b));
	}
}
