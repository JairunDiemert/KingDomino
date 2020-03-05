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
        int tileSize;
        int grid;

        public BoardControler()
        {
            tileSize = 80;
            grid = 8;
        }

        public int GetTileSize()
        {
            return tileSize;
        }

        public void SetTileSize(int size)
        {
            tileSize = size;
        }

        public int GetGridSize()
        {
            return grid;
        }

        public void SetGridSize(int gridSize)
        {
            grid = gridSize;
        }

        public String TypeChecker(EnvironmentTypes type)
        {
            if (type.Equals(EnvironmentTypes.Default))
            {
                return "default";
            }
            return "";
        }



    }
}