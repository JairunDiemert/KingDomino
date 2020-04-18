using Microsoft.Xna.Framework.Input;
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
        public int playerAtTurn { get; set; }
        public int dominoesPlaced { get; set; }
        public int meepleNum { get; set;  }

        public RoundLogic(int playerNum)
        {
            meepleNum = 1;
            dominoesPlaced = 0;
            currentRound = new Round(playerNum);
            playerAtTurn = currentRound.playersTurn;
        }

        public RoundLogic(Player[] player, int playerNum)
        {
            meepleNum = 1;
            dominoesPlaced = 0;
            currentRound = new Round(playerNum);
            players = player;
            playerAtTurn = currentRound.playersTurn;
        }

        //TODO: Pick domino function w/ meeples

        public void resetMeeple(ref Meeple meeple)
        {
            if (dominoesPlaced == 4)
            {
                meeple.placed = false;
                meeple.positionAdder = 0;
                meeple.positionMultiplier = meeple.meepleNumber - 1;
                dominoesPlaced = 0;
                meepleNum = 1;
            }
        }
        
        public void addDominoes(bool placed)
        {
            if (placed)
            {
                dominoesPlaced++;
            }
        }
        public void meeplePlacement(KeyboardState newState, KeyboardState oldState, ref Meeple meeple)
        {
            if (meeple.meepleNumber == meepleNum && !meeple.placed)
            {
                if (oldState.IsKeyUp(Keys.D1) && newState.IsKeyDown(Keys.D1))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 0;
                    meeple.placed = true;
                    meepleNum++;
                }
                else if (oldState.IsKeyUp(Keys.D2) && newState.IsKeyDown(Keys.D2))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 1;
                    meeple.placed = true;
                    meepleNum++;
                }
                else if (oldState.IsKeyUp(Keys.D3) && newState.IsKeyDown(Keys.D3))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 2;
                    meeple.placed = true;
                    meepleNum++;
                }
                else if (oldState.IsKeyUp(Keys.D4) && newState.IsKeyDown(Keys.D4))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 3;
                    meeple.placed = true;
                    meepleNum++;
                }
            }
        }

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
