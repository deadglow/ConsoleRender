using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRender
{
	internal class MathEx
	{

		public static float Clamp(float val, float min, float max)
		{
			return Math.Max(min, Math.Min(val, max));
		}
	}
}
