using System;

namespace all_rgb
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var a = new AllRGBGenerator();
			a.ConsoleRun();

			Console.WriteLine("Goodbye World!");
			Console.ReadLine();
		}
	}
}
