﻿using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
	public class Tile
	{
		private environmentTypes envType;
		private int numCrowns;
		bool filledSpace;

		public Tile() 
		{
			environmentTypes = null;
			numCrowns = -1;
			filledSpace = false;
		}

	}
}