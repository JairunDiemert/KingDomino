using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KingDomino
{
    public class BoardControler
    {
        private int tileSize;
        private int grid;

        public BoardControler()
        {
            TileSize = 80;
            Grid = 8;
        }
        public int TileSize
        {
            get { return tileSize; }
            set { tileSize = value; }
        }
        public int Grid
        {
            get { return grid; }
            set { grid = value; }
        }
        public String TypeChecker(EnvironmentTypes type)
        {
            if (type.Equals(EnvironmentTypes.Default))
            {
                return "T1";
            }
            else if(type.Equals(EnvironmentTypes.WheatFeild)){
                
            }
            return "";
        }



    }
}