using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KingDomino
{
    public class Deck
    {
        private ArrayList dominoDeck;
        private int deckSize;

        public Deck()
        {
            DominoDeck = new ArrayList();
            DeckSize = 24;
            for (int i = 0; i < DeckSize; i++)
            {
                DominoDeck.Add(new Domino(new Tile(), new Tile()));
                Console.WriteLine("Count: " + DominoDeck.Count);
            }

        }

        public ArrayList DominoDeck
        {
            get { return dominoDeck; }
            set { dominoDeck = value; }
        }
        public int DeckSize
        {
            get { return deckSize; }
            set { deckSize = value; }
        }
    }
}
