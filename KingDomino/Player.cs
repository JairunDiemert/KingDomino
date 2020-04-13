using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KingDomino
{
	public class Player
	{
		public Domino[] playerHand { get; set; } //Array of Dominos available to place
		public int score { get; set; } //Track score per player
		public bool playerStatus { get; set; } //Determines if player won or lost
		public Player()
		{
			playerHand = null;
			score = 0;
			playerStatus = false;
		}
		public Player(int scr) 
		{
			playerHand = null;
			score = scr;
			playerStatus = false;
		}
	}
}