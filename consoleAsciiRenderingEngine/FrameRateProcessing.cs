using consoleAsciiRenderingEngine;
using ConsoleAsciiRenderingEngine;
using System;
using System.Threading;

public static class FrameRateProcessing
{
	public static double deltaTime;

	public static void ProcessLoop()
	{
		GameLogic game = new GameLogic();
		long targetMillisecondsPerFrame = 1000 / WindowRendering.framerate;

		int frames = 0;
		DateTime lastFPSTime = DateTime.Now;
		DateTime startTime = DateTime.Now;

		while (WindowRendering.isRunning())
		{
			DateTime currentTime = DateTime.Now;
			long elapsedMilliseconds = (long)(currentTime - startTime).TotalMilliseconds;
			

			if (elapsedMilliseconds >= targetMillisecondsPerFrame)
			{
				deltaTime = elapsedMilliseconds / 1000.0;
				game.Loop();
				
				WindowRendering.frameCount++;
				frames++;
				
				if (frames >= WindowRendering.framerate)
				{
					// Display FPS every second
					double fps = frames / (DateTime.Now - lastFPSTime).TotalSeconds;
					WindowRendering.changeTitle(fps);
					frames = 0;
					lastFPSTime = DateTime.Now;
				}
				WindowRendering.RenderWindow();
				//the call for window render function


				startTime = DateTime.Now;
			}
		}
	}
}