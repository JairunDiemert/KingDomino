using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingDomino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void deckLoaderTest()
        {
            Deck testDeck = new Deck();
            Assert.IsTrue(true);//if it makes it to this then the constructor should have worked
        }
    }
}