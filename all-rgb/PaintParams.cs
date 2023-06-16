namespace all_rgb
{
	public class PaintParams
	{
		public float RgbWeight { get; init; } = 1f;
		public float HsbWeight { get; init; } = 0f;
		public float DistanceWeight { get; init; } = 0f; // basically, closer to 1 => circles

		public float NeighbourCountWeight { get; init; } = 0f;
		public int NeighbourCountThreshold { get; init; } = 0;

		public NearestColourSelector NearestColourSelector { get; init; } = NearestColourSelector.Max;

		public SeedType SeedType { get; init; } = SeedType.Centre;
		public int SeedCount { get; init; } = 1;
	}

	public enum NearestColourSelector { Min, Max, Sum, Average };

	public enum SeedType { Centre, Random };
}
