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
        public void TileTest()
        {
            //Set Up
            string expected = "T1";

            //Act
            Tile atTest = new Tile();
            string actual = atTest.TileImageName;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }

}