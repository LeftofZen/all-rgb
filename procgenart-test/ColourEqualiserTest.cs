using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using procgenart_core;

namespace all_rgb_test
{
	class ColourEqualiserTest
	{
		[Test]
		public void TestEqualise()
		{
			var colours = new HashSet<Colour>();
			_ = colours.Add(Colour.FromRGB(0.2f, 0.3f, 0.4f));
			_ = colours.Add(Colour.FromRGB(1.0f, 0.1f, 0.3f));
			_ = colours.Add(Colour.FromRGB(0.1f, 0.6f, 0.9f));
			_ = colours.Add(Colour.FromRGB(0.0f, 0.9f, 0.1f));

			var result = ColourEqualiser.Equalise(colours);

			Assert.AreEqual(0f, result.Min(c => c.R));
			Assert.AreEqual(0f, result.Min(c => c.G));
			Assert.AreEqual(0f, result.Min(c => c.B));

			Assert.AreEqual(1f, result.Max(c => c.R));
			Assert.AreEqual(1f, result.Max(c => c.G));
			Assert.AreEqual(1f, result.Max(c => c.B));
		}
	}
}
