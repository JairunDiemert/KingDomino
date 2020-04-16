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
        public int tileSize { get; set; } 
        public Deck gameDeck { get; set; }
        public Rectangle positionAnSize { get; set; }

        public ViewLogic(int size, ref Deck deck, ref Rectangle positionSize, ref Board board)
        {
            tileSize = size;
            gameDeck = deck;
            positionAnSize = positionSize;
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
            currentDomino.tile1.positionAndSize = positionAndSize;
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
        public String DrawBoard(ref BoardControler boardControl, int i, int j, ref Rectangle positionAndSize, int positionAdder, ref Board gameBoard)
        {
            Tile currentTile;
            currentTile = gameBoard.getTileAt(i, j);
            positionAndSize.X = (i + positionAdder) * tileSize;
            positionAndSize.Y = j * tileSize;
            if (boardControl.DefaultChecker(currentTile.envType))
            {
                return "T1";
            }
            else
            {
                return currentTile.tileName;
            }
        }
    }
}
