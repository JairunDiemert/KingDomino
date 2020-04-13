using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingDomino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KingDomino.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void DeckTest()
        {
            int expected = 24;
            Deck atTest = new Deck(24);
            int actual = atTest.deckSize;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DeckReturnTest()
        {
            Deck atTest = new Deck(24);
            ArrayList actual = atTest.dominoDeck;
            Assert.IsNotNull(actual);
        }
    }
}