using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class Board
    {
        public Tile[,] Gameboard { get; set; }     // 8X8
        public Board(){        
            Gameboard = new Tile[9,9];    
            for(int i = 0;i < 9; ++i){
                for (int j = 0; j < 9; ++j){       
                    Gameboard[i,j] = new Tile();
                }
            }
        }
        public Tile getTileAt(int row, int col){
            return Gameboard[row, col];
        }
        public void FillTile(int row, int col)
        {
            if (Gameboard[row, col].filledSpace != true)
            {
                try
                {
                    Gameboard[row, col].filledSpace = (true);
                }
                catch(System.IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
        }
        public void setTileAt(int row, int col, Tile currentTile){
            int tileSize = new BoardControler().tileSize;
            if (currentTile.tileName != "Blank")
            {
                currentTile.positionAndSize = new Rectangle(row * tileSize, col * tileSize, tileSize, tileSize);
                Gameboard[row, col] = currentTile;
                try
                {
                    FillTile(row, col);
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
        }
    }
}
