using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KingDomino
{
    class GameEndLogic : Game
    {
        public bool GameOverCheck(int deckSize, int totalNumberOfTilesPlaced, ref SpriteFont testWriter, ref SpriteBatch spriteBatch)
        {
            if (totalNumberOfTilesPlaced >= deckSize)
            {
                PrintEndContent(ref testWriter, ref spriteBatch);
                return true;
            }
            return false;
        }
        public void PrintEndContent(ref SpriteFont textWriter, ref SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(textWriter, "            GAME-OVER\n " +
                "(Auto Score in development)\n " +
                "      Calculate your scores\n " +
                "             and see who \n " +
                "                 *WON*", new Vector2(1335, 300), Color.Purple);
        }
    }
}
