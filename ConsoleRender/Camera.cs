namespace ConsoleRender
{
	public class Camera
	{
		public static Camera main;
		public Vec2 Position { get; set; }
		public Vec2 Size { get; set; }
		Vec2 limits;

		public Camera(Vec2 position, Vec2 size, Vec2 canvasSize)
		{
			Position = position;
			Size = size;
			limits = canvasSize - size - Vec2.One;
		}

		public void MoveTo(Vec2 newPos)
		{
			Position = new Vec2(MathEx.Clamp(newPos.x, 0, limits.x), MathEx.Clamp(newPos.y, 0, limits.y));
		}

		public void Move(Vec2 deltaPos)
		{
			MoveTo(Position + deltaPos);
		}

	}
}
