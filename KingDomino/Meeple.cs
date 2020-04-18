using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class Meeple
    {
        public bool placed { get; set; }
        public int positionAdder { get; set; }
        public int positionMultiplier { get; set; }
        public int playerNumber { get; set; }
        public int meepleNumber { get; set; }
        public String meepleIcon { get; set; }

        public Meeple(int add, int multi, int player, int meepNumber)
        {
            placed = false;
            positionAdder = add;
            positionMultiplier = multi;
            playerNumber = player;
            meepleNumber = meepNumber;
            meepleIcon = "";
        }
    }
}
