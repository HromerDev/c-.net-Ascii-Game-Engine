using consoleAsciiRenderingEngine;
using ConsoleAsciiRenderingEngine;
using System.Windows.Input;
using System;

class GameLogic
{
	int i = 0; // Direction in the X-axis
	int j = 0; // Direction in the Y-axis
	double timer = 0;

	GameObject snakeHead = new GameObject('S', 20, 6);

	public void Loop()
	{
		if (Keyboard.IsKeyDown(Key.W))
		{
			i = 0;
			j = -1;
		}
		else if (Keyboard.IsKeyDown(Key.S))
		{
			i = 0;
			j = 1;
		}
		else if (Keyboard.IsKeyDown(Key.A))
		{
			i = -1;
			j = 0;
		}
		else if (Keyboard.IsKeyDown(Key.D))
		{
			i = 1;
			j = 0;
		}

		timer += FrameRateProcessing.deltaTime;

		if (timer > 1)
		{
			snakeHead.Move(i, j);
			timer = 0;
		}

		//Console.Title = snakeHead.yPosition + " " + (WindowRendering.gameTileMapSizeY - 1) + " " + timer;
	}
}