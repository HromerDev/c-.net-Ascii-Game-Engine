using consoleAsciiRenderingEngine;
using System;
using System.Text;

namespace ConsoleAsciiRenderingEngine
{
	static class WindowRendering
	{
		//game tile values
		public static char[,] objectPosition;
		public static int gameTileMapSizeX;
		public static int gameTileMapSizeY;
		//window values
		static string title;
		static int width;
		static int height;
		
		//framerate values
		public static uint framerate;
		public static uint frameCount = 1;
		public static void WindowInnit(string _title, int _width, int _height, uint _framerate) 
		{
			
			title = _title;
			width = _width - 2;
			height = _height - 2;			
			framerate = _framerate;
			
			gameTileMapSizeX = width - 1;
			gameTileMapSizeY = height - 1;
			objectPosition = new char[WindowRendering.gameTileMapSizeX, WindowRendering.gameTileMapSizeY];
			Console.SetWindowSize(width + 1, height + 1);
			Console.SetBufferSize(Math.Max(60, width + 1), Math.Max(60, height));
			//Console.Title = title;
		}
		//currently here for debugging, final build may be running as while(true) and user will be expected to shut down the program themself
		public static bool isRunning() 
		{
			return true;
		}
		//dynamic title changing dependant on framerate
		public static void changeTitle(double frame)
		{
			Console.Title = title + " " + Math.Round(frame, 3) + " fps";
		}
		public static void ClearPosition(int x, int y)
		{
			objectPosition[x, y] = (char)32; // Set position to space character
		}

		public static void SetPosition(int x, int y, char character)
		{
			objectPosition[x, y] = character;
		}


		//the source of my depression. Most of my time spent on this project is within this function
		public static void RenderWindow()
		{	
			Console.SetCursorPosition(0, 0);
			char[,] renderBuffer = new char[width, height];

			// Populate renderBuffer with characters
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (i == 0 || i == height - 1 || j == 0 || j == width - 1)					
						renderBuffer[j, i] = 'x';					
					else
					{
						renderBuffer[j, i] = (char)32;

						int clampedJ = Math.Min(Math.Max(j, 1), gameTileMapSizeX - 1);
						int clampedI = Math.Min(Math.Max(i, 1), gameTileMapSizeY - 1);

						if (objectPosition[clampedJ, clampedI] == 'S')
						{
							renderBuffer[j, i] = objectPosition[clampedJ, clampedI];
						}

					}
				}
			}
			// Print the entire buffer to the console at once
			Console.CursorVisible = false;
			Console.SetCursorPosition(0, 0);

			StringBuilder output = new StringBuilder();
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					output.Append(renderBuffer[j, i]);
				}
				output.AppendLine();
			}
			Console.Clear();
			Console.Write(output.ToString());
		}
	}
}