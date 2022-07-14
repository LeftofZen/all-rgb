using NUnit.Framework;
using procgenart_core;

namespace all_rgb_test
{
	public class ColourSpaceConverterTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestRGBtoHSB()
		{
			//Assert.Multiple(() =>
			//{
			var aquamarine = ColourSpaceConverter.RGBtoHSB(new RGB { R = 0.5f, G = 1f, B = 1f });
			Assert.AreEqual(new HSB { Hue = 0.5f, Saturation = 0.5f, Brightness = 1f }, aquamarine);

			var white = ColourSpaceConverter.RGBtoHSB(new RGB { R = 1f, G = 1f, B = 1f });
			Assert.AreEqual(new HSB { Hue = 0f, Saturation = 0f, Brightness = 1f }, white);

			var black = ColourSpaceConverter.RGBtoHSB(new RGB { R = 0f, G = 0f, B = 0f });
			Assert.AreEqual(new HSB { Hue = 0f, Saturation = 0f, Brightness = 0f }, black);

			// H and S can be anything in grayscale, only B affects RGB
			var greyish = ColourSpaceConverter.RGBtoHSB(new RGB { R = 123 / 255f, G = 123 / 255f, B = 123 / 255f });
			Assert.AreEqual(0.48235294f, greyish.Brightness);

			var darkMagenta = ColourSpaceConverter.RGBtoHSB(new RGB { R = 138 / 255f, G = 21 / 255f, B = 170 / 255f });
			Assert.AreEqual(new HSB { Hue = 0.7975392f, Saturation = 0.87647057f, Brightness = 0.6666667f }, darkMagenta);
			//});
		}

		[Test]
		public void TestHSBToRGB()
		{
			//Assert.Multiple(() =>
			//{
			var aquamarine = ColourSpaceConverter.HSBtoRGB(new HSB { Hue = 0.5f, Saturation = 0.5f, Brightness = 1f });
			Assert.AreEqual(new RGB { R = 0.5f, G = 1f, B = 1f }, aquamarine);

			var white = ColourSpaceConverter.HSBtoRGB(new HSB { Hue = 0f, Saturation = 0f, Brightness = 1f });
			Assert.AreEqual(new RGB { R = 1f, G = 1f, B = 1f }, white);

			var black = ColourSpaceConverter.HSBtoRGB(new HSB { Hue = 0f, Saturation = 0f, Brightness = 0f });
			Assert.AreEqual(new RGB { R = 0f, G = 0f, B = 0f }, black);

			var greyish = ColourSpaceConverter.HSBtoRGB(new HSB { Hue = 0f, Saturation = 0f, Brightness = 0.48235294f });
			Assert.AreEqual(new RGB { R = 123 / 255f, G = 123 / 255f, B = 123 / 255f }, greyish);
			//});
		}

		[Test]
		public void TestIdempotenceRGB()
		{
			var rgb = new RGB { R = 0.12f, G = 0.87f, B = 0.48f };
			var rgb2 = ColourSpaceConverter.HSBtoRGB(ColourSpaceConverter.RGBtoHSB(rgb));
			Assert.That(rgb.R, Is.EqualTo(rgb2.R).Within(0.0001f));
			Assert.That(rgb.G, Is.EqualTo(rgb2.G).Within(0.0001f));
			Assert.That(rgb.B, Is.EqualTo(rgb2.B).Within(0.0001f));
		}

		[Test]
		public void TestIdempotenceHSB()
		{
			var hsb = new HSB { Hue = 0.12f, Saturation = 0.87f, Brightness = 0.48f };
			var hsb2 = ColourSpaceConverter.RGBtoHSB(ColourSpaceConverter.HSBtoRGB(hsb));
			Assert.That(hsb.Hue, Is.EqualTo(hsb2.Hue).Within(0.0001f));
			Assert.That(hsb.Saturation, Is.EqualTo(hsb2.Saturation).Within(0.0001f));
			Assert.That(hsb.Brightness, Is.EqualTo(hsb2.Brightness).Within(0.0001f));
		}
	}
}