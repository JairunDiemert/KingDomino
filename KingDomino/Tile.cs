using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
	public class Tile
	{
		private EnvironmentTypes envType;
		private int numCrowns;
		private bool filledSpace;
		private string tileImageName;
		private int xCoordinate;
		private int yCoordinate;

		public Tile() 
		{
			EnvType = EnvironmentTypes.Default;
			NumCrowns = -1;
			FilledSpace = false;
			TileImageName = "T1";
			XCoordinate = -1;
			YCoordinate = -1;

		}
		public Tile(EnvironmentTypes envType, int numCrowns, bool filledSpace, string tileImageName, int xCoordinate, int yCoordinate)
		{
			EnvType = envType;
			NumCrowns = numCrowns;
			FilledSpace = filledSpace;
			TileImageName = tileImageName;
			XCoordinate = xCoordinate;
			YCoordinate = yCoordinate;
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
		public int XCoordinate
		{
			get { return xCoordinate; }
			set { xCoordinate = value; }
		}
		public int YCoordinate
		{
			get { return yCoordinate; }
			set { yCoordinate = value; }
		}
	}
}