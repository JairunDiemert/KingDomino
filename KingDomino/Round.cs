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
        public bool meeplesPlaced { get; set; }
        public bool tilesPlaced { get; set; }
        public int totalRounds { get; set; }
        public Round() //Default game is two players
        {
            numberOfPlayers = 2;
            playersTurn = 1;
            meeplesPlaced = false;
            tilesPlaced = false;
            totalRounds = 0;
        }
        public Round(int numPlayers)
        {
            numberOfPlayers = numPlayers;
            playersTurn = 1;
            meeplesPlaced = false;
            tilesPlaced = false;
            totalRounds = 0;
        }
    }
}
