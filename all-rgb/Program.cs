using System;

namespace all_rgb
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var a = new AllRGBGenerator();
			a.Run();

			Console.WriteLine("Goodbye World!");
			Console.ReadLine();
		}
	}
}
