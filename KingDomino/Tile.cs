using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KingDomino
{
	public class Tile
	{
		public EnvironmentTypes envType { get; set; }
		public int numCrowns { get; set; }
		public bool filledSpace { get; set; }
		public string tileName { get; set; }
		public int tileNumber { get; set; }
		public Rectangle positionAndSize { get; set; }

		public Tile() 
		{
			envType = EnvironmentTypes.Default;
			numCrowns = -1;
			filledSpace = false;
			tileName = "T1";
			positionAndSize = new Rectangle();
		}
		public Tile(string tileImgName)
		{
			envType = EnvironmentTypes.Blank;
			numCrowns = -1;
			filledSpace = false;
			tileName = tileImgName;
			positionAndSize = new Rectangle();
		}
		public Tile(EnvironmentTypes evType, int numberCrowns, bool fSpace, string tileImgName, int x, int y, int width, int height, int tileNum)
		{
			envType = evType;
			numCrowns = numberCrowns;
			filledSpace = fSpace;
			tileName = tileImgName;
			tileNumber = tileNum;
			positionAndSize = new Rectangle(x, y, width, height);
		}
	}
}