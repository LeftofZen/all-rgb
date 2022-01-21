using System.Collections.Generic;
using System.Drawing;

namespace all_rgb.PixelSelectorAlgorithms
{
	delegate void PixelSelectorDelegate(ref ImageBuffer buf, ref Point xy, ref Colour colour, ref NearestColourParam nearestColourParam, ref List<float> diffs);
}
