using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace KingDomino
{
    public class Deck
    {

        private ArrayList dominoDeck;
        private int deckSize;
        private ArrayList envNamesWheatField = CreateArrayListFromFile("envNamesWheatField.txt");
        private ArrayList envNamesLakes = CreateArrayListFromFile("envNamesLakes.txt");
        private ArrayList envNamesMountains = CreateArrayListFromFile("envNamesMountains.txt");
        private ArrayList envNamesForests = CreateArrayListFromFile("envNamesForests.txt");
        private ArrayList envNamesVillages = CreateArrayListFromFile("envNamesVillages.txt");
        private ArrayList envNamesGardens = CreateArrayListFromFile("envNamesGardens.txt");
        private ArrayList singleCrown = CreateArrayListFromFile("envNamesSingleCrown.txt");
        private ArrayList doubleCrown = CreateArrayListFromFile("envNamesDoubleCrown.txt");
        private ArrayList tripleCrown = CreateArrayListFromFile("envNamesTripleCrown.txt");
        public Deck()
        {
            DominoDeck = new ArrayList();
            DeckSize = 24;
            for (int i = 0; i < DeckSize; i++)
            {
                DominoDeck.Add(new Domino(new Tile("Blank"), new Tile("Blank")));
            }
        }

        public Deck(int deckSize)
        {
            ArrayList maxDeck = new ArrayList();
            MaxDeck(maxDeck);
            RandomOrder(maxDeck);
            DominoDeck = new ArrayList();
            DeckSize = deckSize;
            DominoDeck = maxDeck.GetRange(0, DeckSize);
            for (int j = 0; j < 9; j++)
            DominoDeck.Add(new Domino());
        }

        public void MaxDeck(ArrayList maxDeck)
        {
            int deckSize = 48;


            int nameIndex1 = 2;
            int nameIndex2 = 3;

            for (int i = 0; i < deckSize; i++)
            {

                EnvironmentTypes envType1 = EnvironmentTypes.Default;
                int numCrowns1 = 0;
                bool filledSpace1 = false;
                string tileImageName1 = "Blank";
                int x1 = -1;
                int y1 = -1;
                int width1 = -1;
                int height1 = -1;


                EnvironmentTypes envType2 = EnvironmentTypes.Default;
                int numCrowns2 = 0;
                bool filledSpace2 = false;
                string tileImageName2 = "Blank";
                int x2 = -1;
                int y2 = -1;
                int width2 = -1;
                int height2 = -1;


                tileImageName1 = "T" + (nameIndex1);
                tileImageName2 = "T" + (nameIndex2);

                if (EnvNamesWheatField.Contains(tileImageName1)) envType1 = EnvironmentTypes.WheatFeild;
                if (EnvNamesWheatField.Contains(tileImageName2)) envType2 = EnvironmentTypes.WheatFeild;
                if (EnvNamesLakes.Contains(tileImageName1)) envType1 = EnvironmentTypes.Lakes;
                if (EnvNamesLakes.Contains(tileImageName2)) envType2 = EnvironmentTypes.Lakes;
                if (EnvNamesMountains.Contains(tileImageName1)) envType1 = EnvironmentTypes.Mountains;
                if (EnvNamesMountains.Contains(tileImageName2)) envType2 = EnvironmentTypes.Mountains;
                if (EnvNamesForests.Contains(tileImageName1)) envType1 = EnvironmentTypes.Forests;
                if (EnvNamesForests.Contains(tileImageName2)) envType2 = EnvironmentTypes.Forests;
                if (EnvNamesVillages.Contains(tileImageName1)) envType1 = EnvironmentTypes.Villages;
                if (EnvNamesVillages.Contains(tileImageName2)) envType2 = EnvironmentTypes.Villages;
                if (EnvNamesGardens.Contains(tileImageName1)) envType1 = EnvironmentTypes.Gardens;
                if (EnvNamesGardens.Contains(tileImageName2)) envType2 = EnvironmentTypes.Gardens;

                if (SingleCrown.Contains(tileImageName1)) numCrowns1 = 1;
                if (SingleCrown.Contains(tileImageName2)) numCrowns2 = 1;
                if (DoubleCrown.Contains(tileImageName1)) numCrowns1 = 2;
                if (DoubleCrown.Contains(tileImageName2)) numCrowns2 = 2;
                if (TripleCrown.Contains(tileImageName1)) numCrowns1 = 3;
                if (TripleCrown.Contains(tileImageName2)) numCrowns2 = 3;

                maxDeck.Add(new Domino(new Tile(envType1, numCrowns1, filledSpace1, tileImageName1, x1, y1, width1, height1),
                    new Tile(envType2, numCrowns2, filledSpace2, tileImageName2, x2, y2, width2, height2)));
                nameIndex1 += 2;
                nameIndex2 += 2;
            }
        }
        public void RandomOrder(ArrayList arrList)
        {
            Random r = new Random();
            for (int cnt = 0; cnt < arrList.Count; cnt++)
            {
                object tmp = arrList[cnt];
                int idx = r.Next(arrList.Count - cnt) + cnt;
                arrList[cnt] = arrList[idx];
                arrList[idx] = tmp;
            }

        }
        public static ArrayList CreateArrayListFromFile(string file)
        {
            ArrayList list = new ArrayList();
            TextReader tr;
            tr = File.OpenText(file);

            string EnvironmentName;
            EnvironmentName = tr.ReadLine();
            while (EnvironmentName != null)
            {
                list.Add(EnvironmentName);
                EnvironmentName = tr.ReadLine();
            }
            return list;

        }

        public ArrayList DominoDeck
        {
            get { return dominoDeck; }
            set { dominoDeck = value; }
        }
        public int DeckSize
        {
            get { return deckSize; }
            set { deckSize = value; }
        }
        public ArrayList EnvNamesWheatField
        {
            get { return envNamesWheatField; }
        }
        public ArrayList EnvNamesLakes
        {
            get { return envNamesLakes; }
        }
        public ArrayList EnvNamesMountains
        {
            get { return envNamesMountains; }
        }
        public ArrayList EnvNamesForests
        {
            get { return envNamesForests; }
        }
        public ArrayList EnvNamesVillages
        {
            get { return envNamesVillages; }
        }
        public ArrayList EnvNamesGardens
        {
            get { return envNamesGardens; }
        }
        public ArrayList SingleCrown
        {
            get { return singleCrown; }
        }
        public ArrayList DoubleCrown
        {
            get { return doubleCrown; }
        }
        public ArrayList TripleCrown
        {
            get { return tripleCrown; }
        }
    }
}
