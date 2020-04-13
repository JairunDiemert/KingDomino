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
    public class DominoTests
    {
        [TestMethod()]
        public void DominoTest()
        {
            Tile Tile1 = new Tile();
            Tile Tile2 = new Tile();
            Domino atTest = new Domino(Tile1, Tile2);
            Tile actual = atTest.tile1;
            Assert.AreEqual(Tile1, actual);
        }
    }
}