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
            //Set Up
            int expected = 24;

            //Act
            Deck atTest = new Deck(24);
            int actual = atTest.DeckSize;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeckReturnTest()
        {

            //Act
            Deck atTest = new Deck(24);
            ArrayList actual = atTest.DominoDeck;

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}