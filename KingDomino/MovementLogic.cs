using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class MovementLogic : Game
    {
        public MovementLogic() { }
        public void KeyboardMovement(ref KeyboardState oldState,ref KeyboardState state,ref int playerX,ref int playerY,ref int playerX2,ref int playerY2)
        {
            if (oldState.IsKeyUp(Keys.A) && state.IsKeyDown(Keys.A))
            {
                if (playerX >= 1)
                {
                    --playerX;
                    --playerX2;
                }
            }
            else if (oldState.IsKeyUp(Keys.D) && state.IsKeyDown(Keys.D))
            {
                if (playerX <= 6)
                {
                    ++playerX;
                    ++playerX2;
                }
            }
            if (oldState.IsKeyUp(Keys.W) && state.IsKeyDown(Keys.W))
            {
                if (playerY >= 1)
                {
                    --playerY;
                    --playerY2;
                }
            }
            else if (oldState.IsKeyUp(Keys.S) && state.IsKeyDown(Keys.S))
            {
                if (playerY <= 7)
                {
                    ++playerY;
                    ++playerY2;
                }
            }
        }
        public void Rotation(ref KeyboardState oldState,ref KeyboardState state,ref int playerX,ref int playerY,ref int playerX2,ref int playerY2, ref int rotateDeg)
        {
            if (oldState.IsKeyUp(Keys.R) && state.IsKeyDown(Keys.R) && rotateDeg == 0)
            {
                rotateDeg = 90;
                playerY2 = playerY - 1;
                playerX2 = playerX;
            }
            else if (oldState.IsKeyUp(Keys.R) && state.IsKeyDown(Keys.R) && rotateDeg == 90) {
                rotateDeg = 180;
                playerY2 = playerY2 + 1;
                playerX2 = playerX - 1;
            }
            else if (oldState.IsKeyUp(Keys.R) && state.IsKeyDown(Keys.R) && rotateDeg == 180) {
                rotateDeg = 270;
                playerX2 = playerX;
                playerY2 = playerY2 + 1;
            }
            else if (oldState.IsKeyUp(Keys.R) && state.IsKeyDown(Keys.R) && rotateDeg == 270) {
                rotateDeg = 0;
                playerX2 = playerX + 1;
                playerY2 = playerY2 - 1;
            }
        }
        public bool Placement(ref KeyboardState oldState,ref KeyboardState state,ref int playerX,ref int playerY,ref int playerX2,ref int playerY2, ref int rotateDeg,ref Domino currentDomino,ref Deck gameDeck, ref int playerDomino,ref Board gameBoard,Action IncrementDeck)
        {
            if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 0) // below does normal 0
            {
                int nextTile = playerX + 1;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.dominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.tile1);
                gameBoard.setTileAt(nextTile, playerY, currentDomino.tile2);
                return true;
            }
            else if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 90) // does 90 
            {
                int nextTile = playerX;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.dominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.tile1);
                gameBoard.setTileAt(nextTile, playerY - 1, currentDomino.tile2);
                return true;
            }
            else if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 180) // below does 180
            {
                int nextTile = playerX - 1;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.dominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.tile1);
                gameBoard.setTileAt(nextTile, playerY, currentDomino.tile2);
                return true;
            }
            else if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 270) // below does 270
            {
                int nextTile = playerX;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.dominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.tile1);
                gameBoard.setTileAt(nextTile, playerY + 1, currentDomino.tile2);
                return true;
            }
            return false;
        }
    }
}
