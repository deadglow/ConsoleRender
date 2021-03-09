using System;
using System.IO;
using System.Diagnostics;


namespace ConsoleRender
{
	class Program
	{
		static readonly short height = 144;
		static readonly short width = 160;
		static Vec2 startPos;
		static Vec2 curPos;
		static ConsoleKeyInfo input;
		static string directoryOffset = Path.Combine(Environment.CurrentDirectory, @"..\..\..\spr");
		static Sprite sprite = new Sprite("monke", @"monke.spr");
		static Sprite banan = new Sprite("banana", @"banana.spr");
		static int flip = 1;

		static void Main(string[] args)
		{


			sprite.LoadSpriteFromFile(directoryOffset);
			banan.LoadSpriteFromFile(directoryOffset);

			Console.ReadKey();


			bool quit = false;

			new System.Threading.Thread(() =>
			{
				System.Threading.Thread.CurrentThread.IsBackground = true;
				input = Console.ReadKey();
				while (input.Key != ConsoleKey.Q)
				{
					input = Console.ReadKey();

				}
				quit = true;
			}).Start();


			if (Renderer.InitialiseRenderer(width, height, 2, "Consolas", 8))
			{
				Stopwatch stopWatch = new Stopwatch();
				while (!quit)
				{
					stopWatch.Restart();

					Update();
					Console.SetCursorPosition(2, 4);

					Renderer.Render();

					stopWatch.Stop();
					Console.Write((1f / (stopWatch.ElapsedMilliseconds / 1000f)).ToString("F2"));

					//System.Threading.Thread.Sleep(1000 / 60);
				}
			}
		}


		static void Update()
		{
			switch (input.Key)
			{
				case ConsoleKey.UpArrow:
					curPos.y--;
					break;

				case ConsoleKey.DownArrow:
					curPos.y++;
					break;

				case ConsoleKey.LeftArrow:
					curPos.x--;
					break;

				case ConsoleKey.RightArrow:
					curPos.x++;
					break;

				case ConsoleKey.R:
					startPos = curPos;
					break;

				case ConsoleKey.F:
					flip = -flip;
					break;

				default:
					break;
			}
			input = new ConsoleKeyInfo('o', ConsoleKey.O, false, false, false);

			//Renderer.DrawLine((int)startPos.x, (int)startPos.y, (int)curPos.x, (int)curPos.y, ' ', ConsoleColor.Red, ConsoleColor.White);
			sprite.DrawSprite((int)curPos.x, (int)curPos.y, flip, flip);
			banan.DrawSprite((int)startPos.x, (int)startPos.y, flip, flip);
		}

		public struct Vec2
		{
			public float x;
			public float y;

			public Vec2(float x, float y)
			{
				this.x = x;
				this.y = y;
			}

			public static Vec2 operator +(Vec2 a, Vec2 b)
			{
				return new Vec2(a.x + b.x, a.y + b.y);
			}
			public static Vec2 operator -(Vec2 a, Vec2 b)
			{
				return new Vec2(a.x - b.x, a.y - b.y);
			}
		}

	}
}
