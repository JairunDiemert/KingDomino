using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    class Round
    {
        public int numberOfPlayers { get; set; }
        public int playersTurn { get; set; }
        public bool kingsPlaced { get; set; }
        public bool tilesPlaced { get; set; }
        public int totalRounds { get; set; }

        public Round(int numPlayers)
        {
            numberOfPlayers = numPlayers;
            playersTurn = 1;
            kingsPlaced = false;
            tilesPlaced = false;
            totalRounds = 0;
        }
    }
}
