using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class Board
    {
        Tile[, ] Gameboard;     // 8X8

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

        public void setTileAt(int row, int col, Tile currentTile){
            Gameboard[row, col].EnvType = (currentTile.EnvType);
            Gameboard[row, col].NumCrowns = (currentTile.NumCrowns);
            Gameboard[row, col].TileImageName = (currentTile.TileImageName);
            Gameboard[row, col].PositionAndSize = (currentTile.PositionAndSize);
        }

        public void FillTile(int row, int col){
            if(Gameboard[row, col].FilledSpace != true){
                Gameboard[row, col].FilledSpace = (true);
            } 
        }
    }
}
