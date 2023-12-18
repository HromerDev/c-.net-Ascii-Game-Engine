using ConsoleAsciiRenderingEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace consoleAsciiRenderingEngine
{
	internal class GameObject
	{
		char body;

		public int xPosition;
		public int yPosition;

		//int xSize;
		//int ySize;
		/*
		public GameObject(char _body, int _xPosition, int _yPosition, int _xSize, int _ySize) 
		{
			body = _body;
			xPosition = _xPosition;
			yPosition = _yPosition;
			xSize = _xSize;
			ySize = _ySize;

			WindowRendering.SetPosition(xPosition, yPosition, body);

		}
		*/
		public GameObject(char _body, int _xPosition, int _yPosition) 
		{
			body = _body;
			xPosition = _xPosition;
			yPosition = _yPosition;

			//WindowRendering.SetPosition(xPosition, yPosition, body);
		}
		public void Move(int whereToMoveX, int whereToMoveY) 
		{
			if ((whereToMoveX == 0 && whereToMoveY != 0) || (whereToMoveX != 0 && whereToMoveY == 0))
			{
				WindowRendering.objectPosition[xPosition, yPosition] = (char)32;

				// Calculate the new position
				int newX = xPosition + whereToMoveX;
				int newY = yPosition + whereToMoveY;

				// Check boundaries to prevent going out of bounds
				if (newX >= 1 && newX < WindowRendering.gameTileMapSizeX)
					xPosition = newX;

				if (newY >= 1 && newY < WindowRendering.gameTileMapSizeY)
					yPosition = newY;

				WindowRendering.objectPosition[xPosition, yPosition] = body;
			}
		}
	}
}
