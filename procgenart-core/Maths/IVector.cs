namespace procgenart_core
{
	public interface IVector3<T>
	{
		T X { get; set; }
		T Y { get; set; }
		T Z { get; set; }
	}

	//public interface IVector4<T>
	//{
	//	T W { get; set; }
	//	T X { get; set; }
	//	T Y { get; set; }
	//	T Z { get; set; }
	//}

	// perhaps in .NET 7 with https://github.com/dotnet/designs/pull/205
	// we can FINALLY use something like INumeric and avoid this bullshit
	public interface IVector3Float : IVector3<float>
	{ }
}
