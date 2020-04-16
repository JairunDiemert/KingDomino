using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    class RoundLogic
    {
        private Round currentRound;
        private Player[] players { get; set; }
        private Player currentPlayerTurn { get; set; }

        public RoundLogic(Player[] player, int playerNum)
        {
            currentRound = new Round(playerNum);
            players = player;
            currentPlayerTurn = players[currentRound.playersTurn];
        }

        //TODO: Pick domino function w/ meeples

        //TODO: Place domino function on specific board
        public void placeDomino()
        {
            
        }
    }
}
