﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_rgb
{
	public class SortedFrontier
	{
		SortedList<float, HashSet<RGB>> rKey = new();
		SortedList<float, HashSet<RGB>> gKey = new();
		SortedList<float, HashSet<RGB>> bKey = new();

		public void Add(Colour c)
		{
			if (!rKey.ContainsKey(c.R))
			{
				rKey.Add(c.R, new HashSet<RGB>());
				//rKey[c.R].Add(c);

			}
		}
	}
}