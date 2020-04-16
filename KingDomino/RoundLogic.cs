using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class RoundLogic
    {
        private Round currentRound;
        private Player[] players { get; set; }
        private Player currentPlayerTurn { get; set; }
        public int playerAtTurn { get; set; }

        public RoundLogic(int playerNum)
        {
            currentRound = new Round(playerNum);
            playerAtTurn = currentRound.playersTurn;
        }

        public RoundLogic(Player[] player, int playerNum)
        {
            currentRound = new Round(playerNum);
            players = player;
            currentPlayerTurn = players[currentRound.playersTurn];
        }

        //TODO: Pick domino function w/ meeples

        public void changePlayerTurn(bool placed)
        {
            if(placed)
            {
                if(playerAtTurn == 1)
                    currentRound.playersTurn++;
                else
                    currentRound.playersTurn--;

                playerAtTurn = currentRound.playersTurn;
            }
        }

        public ref Board currentBoardAtPlay(ref Board gameBoard1, ref Board gameBoard2)
        {
            if(playerAtTurn == 1)
            {
                return ref gameBoard1;
            }
            else //if(playerAtTurn == 2)
            {
                return ref gameBoard2;
            }
            //return null;
        }

        public ref Board secondBoardAtPlay(ref Board gameBoard1, ref Board gameBoard2)
        {
            if(playerAtTurn == 1)
            {
                return ref gameBoard2;
            }
            else //if(playerAtTurn == 2)
            {
                return ref gameBoard1;
            }
            //return null;
        }

        public int secondPlayer()
        {
            if(playerAtTurn == 1)
                return 2;
            else
                return 1;
        }

    }
}
