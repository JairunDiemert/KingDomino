using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace KingDomino
{
    class ViewLogic : Game
    {
        int tileSize;
        Deck gameDeck;
        Rectangle positionAnSize;
        Board gameBoard;
        public ViewLogic(int size, ref Deck deck, ref Rectangle positionSize, ref Board board)
        {
            tileSize = size;
            gameDeck = deck;
            positionAnSize = positionSize;
            gameBoard = board;
        }

        public void PositionAndSizeOfPlacementUpdate(ref Rectangle positionAndSizeOfPLacement, ref Rectangle positionAndSizeOfPLacement2, int playerX, int playerY, int playerX2, int playerY2)
        {
            positionAndSizeOfPLacement.X = playerX * tileSize;
            positionAndSizeOfPLacement.Y = playerY * tileSize;
            positionAndSizeOfPLacement2.X = playerX2 * tileSize;
            positionAndSizeOfPLacement2.Y = playerY2 * tileSize;
        }
        
        public void UpdateDeck(ref Domino currentDomino, ref int x, ref int y, ref Rectangle positionAndSize, int positionAdder)
        {
            positionAndSize.X = (x + positionAdder) * tileSize;
            positionAndSize.Y = y * tileSize;
            currentDomino.Tile1.PositionAndSize = positionAndSize;
        }

        public String DrawMeeples(ref Rectangle positionAndSize, int positionMultiplier, int tileSize, int playerNumber)
        {
            positionAndSize.X = 19 * tileSize;
            positionAndSize.Y = positionMultiplier * tileSize;
            if (playerNumber == 1)
            {
                return "K1";
            }
            else
            {
                return "K3";
            }
        }

        public String DrawCastle(ref Rectangle positionAndSize, int positionMultiplier, int tileSize, int playerNumber)
        {
            positionAndSize.X = positionMultiplier * tileSize;
            positionAndSize.Y = 4 * tileSize;
            if(playerNumber == 1)
            {
                return "C1";
            }
            else
            {
                return "C3";
            }
        }

        public String DrawBoard(ref BoardControler boardControl, int i, int j, ref Rectangle positionAndSize, int positionAdder)
        {
            Tile currentTile;

            currentTile = gameBoard.getTileAt(i, j);
            positionAndSize.X = (i + positionAdder) * tileSize;
            positionAndSize.Y = j * tileSize;
            if (boardControl.DefaultChecker(currentTile.EnvType))
            {
                return "T1";
            }
            else
            {
                return currentTile.TileImageName;
            }
        }
    }
}
