using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace KingDomino
{
	public class Tile
	{
		private EnvironmentTypes envType;
		private int numCrowns;
		bool filledSpace;

		public Tile() 
		{
			envType = EnvironmentTypes.Default;
			numCrowns = -1;
			filledSpace = false;
		}

		public EnvironmentTypes GetType(){
			return envType;
		}

	}
}