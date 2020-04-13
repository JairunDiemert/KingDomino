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
        public int tileSize { get; set; }
        public int grid { get; set; }
        public BoardControler()
        {
            tileSize = 70;
            grid = 9;
        }
        public Boolean DefaultChecker(EnvironmentTypes type)
        {
            if (type.Equals(EnvironmentTypes.Default))
            {
                return true;
            }
            return false;
        }
    }
}