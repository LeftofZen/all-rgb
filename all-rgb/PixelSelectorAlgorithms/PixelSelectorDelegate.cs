using System.Collections.Generic;
using System.Drawing;
using procgenart_core;

namespace all_rgb
{
	delegate void PixelSelectorDelegate(ImageBuffer buf, Point xy, Colour colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs);
}
