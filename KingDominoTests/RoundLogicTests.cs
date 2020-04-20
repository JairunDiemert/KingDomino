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
    public class RoundLogicTests
    {
        [TestMethod()]
        public void RoundLogicChangeFromPlayer1to2TurnTest()
        {
            RoundLogic atTest = new RoundLogic(2);
            int expected = 2;

            atTest.changePlayerTurn(true);

            int actual = atTest.playerAtTurn;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPlayerCurrentlyInTurnShouldBe1Test()
        {
            RoundLogic atTest = new RoundLogic(2);
            int expected = 1;

            atTest.changePlayerTurn(true);
            atTest.changePlayerTurn(true);

            int actual = atTest.playerAtTurn;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPlayer1DominoeNumberInHandTest()
        {
            RoundLogic atTest = new RoundLogic(2);
            Player[] players = new Player[2];
            players[0] = new Player();
            players[1] = new Player();
            atTest.dominoesPlaced = 0;

            players[0].playerHand[0] = 1;
            int expected = 1;
            int actual = 0;
            atTest.getProperDomino(ref players, ref actual);
            Assert.AreEqual(expected, actual);
        }

        public void GetCurrentBoardAtPlayTest()
        {
            RoundLogic atTest = new RoundLogic(2);
            Board expected = new Board();
            Board b2 = new Board();

            Board actual = atTest.currentBoardAtPlay(ref expected, ref b2);
            Assert.AreEqual(expected, actual);
        }

        public void GetSecondBoardAtPlayTest()
        {
            RoundLogic atTest = new RoundLogic(2);
            Board b1 = new Board();
            Board expected = new Board();

            Board actual = atTest.currentBoardAtPlay(ref b1, ref expected);
            Assert.AreEqual(expected, actual);
        }

        public void GetSecondPlayerWhenPlayer1IsInTurnTest()
        {
            RoundLogic atTest = new RoundLogic(2);
            int expected = 2;
            int actual = atTest.secondPlayer();

            Assert.AreEqual(expected, actual);
        }
    }
}