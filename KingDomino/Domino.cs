using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class Domino
    {
        private Tile tile1;
        private Tile tile2;

        public Domino()
        {
            Tile1 = new Tile("Blank");
            Tile2 = new Tile("Blank");
        }
        public Domino(Tile tile1, Tile tile2)
        {
            Tile1 = tile1;
            Tile2 = tile2;
        }

        public Tile Tile1
        {
            get { return tile1; }
            set { tile1 = value; }
        }
        public Tile Tile2
        {
            get { return tile2; }
            set { tile2 = value; }
        }
    }
}
