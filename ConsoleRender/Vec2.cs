using System;

namespace ConsoleRender
{
	public struct Vec2
	{
		public static Vec2 Zero
		{
			get
			{
				return new Vec2(0, 0);
			}
		}
		public static Vec2 One
		{
			get
			{
				return new Vec2(1, 1);
			}
		}

		public float x;
		public float y;

		public Vec2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//		Operators
		//____________________________________________________

		public static Vec2 operator +(Vec2 a, Vec2 b)
		{
			return new Vec2(a.x + b.x, a.y + b.y);
		}
		public static Vec2 operator -(Vec2 a, Vec2 b)
		{
			return new Vec2(a.x - b.x, a.y - b.y);
		}
		public static Vec2 operator *(Vec2 a, float scalar)
		{
			return new Vec2(a.x * scalar, a.y * scalar);
		}
		public static Vec2 operator *(Vec2 a, double scalar)
		{
			return new Vec2(a.x * (float)scalar, a.y * (float)scalar);
		}
		public static Vec2 operator /(Vec2 a, float scalar)
		{
			if (scalar == 0)
				return Zero;

			return new Vec2(a.x / scalar, a.y / scalar);
		}
		public static Vec2 operator %(Vec2 a, float scalar)
		{
			return new Vec2(a.x % scalar, a.y % scalar);
		}
		public static Vec2 operator -(Vec2 a)
		{
			return new Vec2(-a.x, -a.y);
		}

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//			Methods
		//______________________________________________________

		public static float Dot (Vec2 a, Vec2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		public static Vec2 Lerp(Vec2 origin, Vec2 destination, float t)
		{
			return origin + (destination - origin) * t;
		}

		public float Magnitude()
		{
			return (float)Math.Sqrt(x * x + y * y);
		}

		public Vec2 Normalised()
		{
			return this / Magnitude();
		}
	}
}
