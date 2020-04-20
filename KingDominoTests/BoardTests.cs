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
    public class BoardTests
    {
        [TestMethod()]
        public void getTileInEmptyBoardTest()
        {
            Board atTest = new Board();
            Tile expected = new Tile();
            Tile actual = atTest.getTileAt(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FillTileInBoardFalseTest()
        {
            Board atTest = new Board();
            bool expected = false;
            Tile testResult = atTest.getTileAt(0, 0);
            bool actual = testResult.filledSpace;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void FillTileInBoardTrueTest()
        {
            Board atTest = new Board();
            bool expected = true;
            atTest.FillTile(0, 0);
            Tile testResult = atTest.getTileAt(0, 0);
            bool actual = testResult.filledSpace;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void setManipulatedTileInBoardTest()
        {
            Board atTest = new Board();
            Tile expected = new Tile();
            expected.tileName = "test";
            atTest.setTileAt(0, 0, expected);
            Tile actual = atTest.getTileAt(0, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}