using System.Collections.Generic;
using System.Drawing;
using procgenart_core;

namespace all_rgb
{
	delegate void PixelSelectorDelegate(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, float avgDistanceFromCentre, ref List<float> diffs);
}
