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
		private EnvironmentTypes envType;
		private int numCrowns;
		private bool filledSpace;
		private string tileImageName;
		private Rectangle positionAndSize;

		public Tile() 
		{
			EnvType = EnvironmentTypes.Default;
			NumCrowns = -1;
			FilledSpace = false;
			TileImageName = "T1";
			positionAndSize = new Rectangle();
		}
		public Tile(EnvironmentTypes envType, int numCrowns, bool filledSpace, string tileImageName, int x, int y, int width, int height)
		{
			EnvType = envType;
			NumCrowns = numCrowns;
			FilledSpace = filledSpace;
			TileImageName = tileImageName;
			positionAndSize = new Rectangle(x, y, width, height);

		}

		public EnvironmentTypes EnvType
		{
			get { return envType; }
			set { envType = value; }
		}
		public int NumCrowns
		{
			get { return numCrowns; }
			set { numCrowns = value; }
		}
		public bool FilledSpace
		{
			get { return filledSpace; }
			set { filledSpace = value; }
		}
		public string TileImageName
		{
			get { return tileImageName; }
			set { tileImageName = value; }
		}
		public Rectangle PositionAndSize
		{
			get { return positionAndSize; }
			set { positionAndSize = value; }
		}
	}
}