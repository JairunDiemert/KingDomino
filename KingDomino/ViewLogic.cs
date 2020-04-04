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
        SpriteBatch spriteBatch;
        int tileSize;
        Deck gameDeck;
        Rectangle positionAnSize;
        Board gameBoard;
        public ViewLogic(ref SpriteBatch sprite, int size, ref Deck deck, ref Rectangle positionSize, ref Board board)
        {
            this.spriteBatch = sprite;
            tileSize = size;
            gameDeck = deck;
            positionAnSize = positionSize;
            gameBoard = board;


        }
        /*
        public void UpdateDeck(int where, int x, int y)
        {
            Domino currentDomino = (Domino)gameDeck.DominoDeck[where];

            Texture2D tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
            positionAndSize.X = x * tileSize;
            positionAndSize.Y = y * tileSize;
            currentDomino.Tile1.PositionAndSize = positionAndSize;
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
            positionAndSize.X = (x + 1) * tileSize;
            positionAndSize.Y = y * tileSize;
            currentDomino.Tile2.PositionAndSize = positionAndSize;
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
        }*/

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
