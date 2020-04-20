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
    public class TileTests
    {
        [TestMethod()]
        public void TileCreationTest()
        {
            string expected = "T1";
            Tile atTest = new Tile();
            string actual = atTest.tileName;
            Assert.AreEqual(expected, actual);
        }
    }
}