using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class Round
    {
        public int numberOfPlayers { get; set; }
        public int playersTurn { get; set; }
        public bool meeplesPlaced { get; set; }
        public int totalRounds { get; set; }
        public Round() //Default game is two players
        {
            numberOfPlayers = 2;
            playersTurn = 1;
            meeplesPlaced = false;
            totalRounds = 0;
        }
        public Round(int numPlayers)
        {
            numberOfPlayers = numPlayers;
            playersTurn = 1;
            meeplesPlaced = false;
            totalRounds = 0;
        }
    }
}
