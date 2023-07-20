using System.Collections.Generic;
using Zenith.Colour;
using Zenith.System.Drawing;
using Zenith.Maths.Points;

namespace all_rgb
{
	delegate void PixelSelectorDelegate(ImageBuffer buf, Point2 xy, ColourRGB colour, PaintParams paintParams, float avgDistanceFromCentre, ref List<float> diffs);
}
