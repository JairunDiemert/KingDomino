using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KingDomino
{
    public class DeckButton
    {
        private int buttonX;
        private int buttonY;
        private Texture2D leftSide;
        private Texture2D rightSide;
        private MouseState mouseState;
        private int dominoWidth;
        private int dominoHeight;

        public DeckButton(Texture2D left, Texture2D right, int buttonX, int buttonY)
        {
            this.leftSide = left;
            this.rightSide = right;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            dominoWidth = leftSide.Width + rightSide.Width;
            dominoHeight = leftSide.Height;
        }

        public bool hoverOverButton()
        {
            if (mouseState.X < buttonX + dominoWidth && mouseState.X > buttonX && mouseState.Y < buttonY + dominoHeight && mouseState.Y > buttonY)
            {
                return true;
            }
            return false;
        }


        public int ButtonX
        {
            get{ return buttonX; }
        }

        public int ButtonY
        {
            get { return buttonY; }
        }
    }
}
