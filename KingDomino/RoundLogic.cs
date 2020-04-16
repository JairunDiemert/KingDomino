using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    class RoundLogic
    {
        private Player[] players { get; set; }
        private Player currentPlayerTurn { get; set; }

        public RoundLogic()
        {
            players = null;
            currentPlayerTurn = null;
        }

        //TODO: Pick domino function w/ meeples
        //TODO: Place domino function on specific board
    }
}
