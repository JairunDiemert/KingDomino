using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class Domino
    {
        public Tile tile1 { get; set; }
        public Tile tile2 { get; set; }
        public Domino()
        {
            tile1 = new Tile("Blank");
            tile2 = new Tile("Blank");
        }
        public Domino(Tile t1, Tile t2)
        {
            tile1 = t1;
            tile2 = t2;
        }
    }
}
