using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb
{
	public class DenoiserParam
	{
		// somehwere between 0.1 and 0.2 is good
		public float DenoisePixelThreshold { get; set; } = 0.2f;
	}
}
