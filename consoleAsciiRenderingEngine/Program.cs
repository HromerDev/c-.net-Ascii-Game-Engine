using consoleAsciiRenderingEngine;
using System.Threading;
using System;

namespace ConsoleAsciiRenderingEngine
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Thread gameThread = new Thread(new ThreadStart(FrameRateProcessing.ProcessLoop));
			gameThread.SetApartmentState(ApartmentState.STA);
			gameThread.Start();

			WindowRendering.WindowInnit("Nameless Engine Project", 100, 20, 150);
			GameLogic game = new GameLogic();			
			//game.Setup();
			//confusing function, but basically takes care of framerate consistency.
			FrameRateProcessing.ProcessLoop();

			gameThread.Join();
		}
	}
}
