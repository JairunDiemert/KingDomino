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
            meepleNum = 0;
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

        public void resetMeeple(ref Meeple[] meeples)
        {
            if (dominoesPlaced == 4)
            {
                for(int i = 0; i < meeples.Length; i++)
                {
                    meeples[i].placed = false;
                    meeples[i].positionAdder = 0;
                    meeples[i].positionMultiplier = meeples[i].meepleNumber - 1;
                }
                dominoesPlaced = 0;
                meepleNum = 0;
            }
        }
        
        public void addDominoes(bool placed)
        {
            if (placed)
            {
                dominoesPlaced++;
            }
        }
        public void incrementMeepleNum(bool placed)
        {
            if (placed)
            {
                meepleNum++;
            }
        }

        public ref Meeple currentMeeple( ref Meeple[] meeples)
        {
            return ref meeples[meepleNum];
        }
        public bool meeplePlacement(KeyboardState newState, KeyboardState oldState, ref Meeple[] meeples)
        {
            if (meepleNum == 4)
                meepleNum = 0;

            Meeple meeple = currentMeeple(ref meeples);
            if (!meeple.placed)
            {
                if (oldState.IsKeyUp(Keys.D1) && newState.IsKeyDown(Keys.D1))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 0;
                    meeple.placed = true;
                    return true;
                }
                else if (oldState.IsKeyUp(Keys.D2) && newState.IsKeyDown(Keys.D2))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 1;
                    meeple.placed = true;
                    return true;
                }
                else if (oldState.IsKeyUp(Keys.D3) && newState.IsKeyDown(Keys.D3))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 2;
                    meeple.placed = true;
                    return true;
                }
                else if (oldState.IsKeyUp(Keys.D4) && newState.IsKeyDown(Keys.D4))
                {
                    meeple.positionAdder = 2;
                    meeple.positionMultiplier = 3;
                    meeple.placed = true;
                    return true;
                }
            }
            return false;
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
