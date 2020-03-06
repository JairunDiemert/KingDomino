using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace KingDomino
{
    public class Deck
    {
        private Domino[] dominoDeck;
        int deckSize = 24;

        public Deck()
        {
            deckLoader();
        }

        public void deckLoader()
        {
            dominoDeck = new Domino[deckSize];
            for (int i = 0; i < deckSize; i++)
            {
                dominoDeck[i] = new Domino();
            }
        }
    }
}
