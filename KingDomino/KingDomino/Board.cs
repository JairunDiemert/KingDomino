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
            
            Gameboard = new Tile[8,8];

            for(int i = 0;i <= 7; i++){
                
                for (int j = 0; i <= 7; i++){
                
                    Gameboard[i,j] = new Tile();
                }
            }

        }

        public Tile getTileAt(int row, int col){
            return Gameboard[row, col];
        }
    }
}
