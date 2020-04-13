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
    public class CreateArrayListFromFileTests
    {
        public void CreateArrayListFromFileTest(string expected, string file, int index)
        {
            Deck atTest = new Deck();
            string actual = (string)Deck.CreateArrayListFromFile(file)[index];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Fields()
        {
            CreateArrayListFromFileTest("T96", "envNamesWheatField.txt", 25);
        }
        [TestMethod()]
        public void Lakes()
        {
            CreateArrayListFromFileTest("T84", "envNamesLakes.txt", 17);
        }
        [TestMethod()]
        public void Mountains()
        {
            CreateArrayListFromFileTest("T97", "envNamesMountains.txt", 5);
        }
        [TestMethod()]
        public void Forests()
        {
            CreateArrayListFromFileTest("T71", "envNamesForests.txt", 21);
        }
        [TestMethod()]
        public void Villages()
        {
            CreateArrayListFromFileTest("T94", "envNamesVillages.txt", 9);
        }
        [TestMethod()]
        public void Gardens()
        {
            CreateArrayListFromFileTest("T88", "envNamesGardens.txt",13);
        }
        [TestMethod()]
        public void SingleCrown()
        {
            CreateArrayListFromFileTest("T80", "envNamesSingleCrown.txt", 19);
        }
        [TestMethod()]
        public void DoubleCrown()
        {
            CreateArrayListFromFileTest("T95", "envNamesDoubleCrown.txt", 6);
        }
        [TestMethod()]
        public void TripleCrown()
        {
            CreateArrayListFromFileTest("T97", "envNamesTripleCrown.txt", 0);
        }
    }
}