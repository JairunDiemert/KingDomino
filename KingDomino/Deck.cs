using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace KingDomino
{
    public class Deck
    {
        public ArrayList dominoDeck { get; set; }
        public int deckSize { get; set; }
        public ArrayList envNamesWheatField { get; set; } = CreateArrayListFromFile("envNamesWheatField.txt");
        public ArrayList envNamesLakes { get; set; } = CreateArrayListFromFile("envNamesLakes.txt");
        public ArrayList envNamesMountains { get; set; } = CreateArrayListFromFile("envNamesMountains.txt");
        public ArrayList envNamesForests { get; set; } = CreateArrayListFromFile("envNamesForests.txt");
        public ArrayList envNamesVillages { get; set; } = CreateArrayListFromFile("envNamesVillages.txt");
        public ArrayList envNamesGardens { get; set; } = CreateArrayListFromFile("envNamesGardens.txt");
        public ArrayList singleCrown { get; set; } = CreateArrayListFromFile("envNamesSingleCrown.txt");
        public ArrayList doubleCrown { get; set; } = CreateArrayListFromFile("envNamesDoubleCrown.txt");
        public ArrayList tripleCrown { get; set; } = CreateArrayListFromFile("envNamesTripleCrown.txt");
        public Deck()
        {
            dominoDeck = new ArrayList();
            deckSize = 24;
            for (int i = 0; i < deckSize; i++)
            {
                dominoDeck.Add(new Domino(new Tile("Blank"), new Tile("Blank")));
            }
        }
        public Deck(int dckSize)
        {
            deckSize = dckSize;
            ArrayList maxDeck = new ArrayList();
            MaxDeck(maxDeck);
            RandomOrder(maxDeck);
            for (int j = 0; j < 50; j++)
               maxDeck.Add(new Domino());
            SortBy4s(maxDeck);
            dominoDeck = new ArrayList();
            dominoDeck = maxDeck.GetRange(0, deckSize);
            for (int j = 0; j < 9; j++)
                dominoDeck.Add(new Domino());
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
                if (envNamesWheatField.Contains(tileImageName1)) envType1 = EnvironmentTypes.WheatFeild;
                if (envNamesWheatField.Contains(tileImageName2)) envType2 = EnvironmentTypes.WheatFeild;
                if (envNamesLakes.Contains(tileImageName1)) envType1 = EnvironmentTypes.Lakes;
                if (envNamesLakes.Contains(tileImageName2)) envType2 = EnvironmentTypes.Lakes;
                if (envNamesMountains.Contains(tileImageName1)) envType1 = EnvironmentTypes.Mountains;
                if (envNamesMountains.Contains(tileImageName2)) envType2 = EnvironmentTypes.Mountains;
                if (envNamesForests.Contains(tileImageName1)) envType1 = EnvironmentTypes.Forests;
                if (envNamesForests.Contains(tileImageName2)) envType2 = EnvironmentTypes.Forests;
                if (envNamesVillages.Contains(tileImageName1)) envType1 = EnvironmentTypes.Villages;
                if (envNamesVillages.Contains(tileImageName2)) envType2 = EnvironmentTypes.Villages;
                if (envNamesGardens.Contains(tileImageName1)) envType1 = EnvironmentTypes.Gardens;
                if (envNamesGardens.Contains(tileImageName2)) envType2 = EnvironmentTypes.Gardens;
                if (singleCrown.Contains(tileImageName1)) numCrowns1 = 1;
                if (singleCrown.Contains(tileImageName2)) numCrowns2 = 1;
                if (doubleCrown.Contains(tileImageName1)) numCrowns1 = 2;
                if (doubleCrown.Contains(tileImageName2)) numCrowns2 = 2;
                if (tripleCrown.Contains(tileImageName1)) numCrowns1 = 3;
                if (tripleCrown.Contains(tileImageName2)) numCrowns2 = 3;
                maxDeck.Add(new Domino(new Tile(envType1, numCrowns1, filledSpace1, tileImageName1, x1, y1, width1, height1, nameIndex1),
                    new Tile(envType2, numCrowns2, filledSpace2, tileImageName2, x2, y2, width2, height2, nameIndex2)));
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
        public void SortBy4s(ArrayList arrList)
        {
            for (int i = 0; i < 48; )
            {
                arrList.Sort(i, (i + 3), new MyComparer());
                i += 4;
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
    }
}
