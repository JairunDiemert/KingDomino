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
		public int[] playerHand { get; set; }
		//public Domino[] playerHand { get; set; } //Array of Dominos available to place
		public int score { get; set; } //Track score per player
		public bool playerStatus { get; set; } //Determines if player won or lost
		public int numInHand { get; set; }
		public Player()
		{
			playerHand = new int[2];
			numInHand = 0;
			score = 0;
			playerStatus = false;
		}
		public Player(int scr) 
		{
			numInHand = 0;
			playerHand = new int[2];
			score = scr;
			playerStatus = false;
		}

		public void incrementHand()
		{
			numInHand++;
			if (numInHand >= 2)
			{
				numInHand = 0;
			}
		}
	}
}