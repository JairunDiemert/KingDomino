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
    public class BoardControlerTests
    {
        [TestMethod()]
        public void BoardControlerTest()
        {
            //Set Up
            BoardControler atTest = new BoardControler();
            int expected = 9;

            //Act
            int actual = atTest.Grid;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}