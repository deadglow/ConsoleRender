using System;

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
