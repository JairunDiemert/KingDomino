using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KingDomino
{
    public class Deck
    {

        private ArrayList dominoDeck;
        private int deckSize;
        private ArrayList envNamesWheatField = new ArrayList
            {
                "T2",
                "T3",
                "T4",
                "T5",
                "T26",
                "T28",
                "T30",
                "T32",
                "T38",
                "T40",
                "T42",
                "T44",
                "T46",
                "T49",
                "T51",
                "T53",
                "T55",
                "T61",
                "T63",
                "T72",
                "T76",
                "T81",
                "T82",
                "T86",
                "T91",
                "T96"
            };
        private ArrayList envNamesLakes = new ArrayList
            {
                "T14",
                "T15",
                "T16",
                "T17",
                "T18",
                "T19",
                "T29",
                "T35",
                "T41",
                "T57",
                "T60",
                "T62",
                "T64",
                "T66",
                "T68",
                "T70",
                "T74",
                "T84"
            };
        private ArrayList envNamesMountains = new ArrayList
            {
                "T47",
                "T80",
                "T90",
                "T93",
                "T95",
                "T97"
            };
        private ArrayList envNamesForrest = new ArrayList
            {
                "T6",
                "T7",
                "T8",
                "T9",
                "T10",
                "T11",
                "T12",
                "T13",
                "T27",
                "T34",
                "T36",
                "T39",
                "T48",
                "T50",
                "T52",
                "T54",
                "T56",
                "T58",
                "T65",
                "T67",
                "T69",
                "T71"
            };
        private ArrayList envNamesVillage = new ArrayList
            {
                "T24",
                "T25",
                "T33",
                "T45",
                "T77",
                "T79",
                "T87",
                "T89",
                "T92",
                "T94"
            };
        private ArrayList envNamesGarden = new ArrayList
            {
                "T20",
                "T21",
                "T22",
                "T23",
                "T31",
                "T37",
                "T43",
                "T59",
                "T73",
                "T75",
                "T78",
                "T83",
                "T85",
                "T88"
            };
        private ArrayList singleCrown = new ArrayList
            {
                "T38",
                "T40",
                "T42",
                "T44",
                "T46",
                "T48",
                "T50",
                "T52",
                "T54",
                "T56",
                "T58",
                "T60",
                "T62",
                "T64",
                "T66",
                "T68",
                "T70",
                "T73",
                "T75",
                "T80"
            };
        private ArrayList doubleCrown = new ArrayList
            {
                "T83",
                "T85",
                "T87",
                "T89",
                "T90",
                "T93",
                "T95"
            };
        private ArrayList tripleCrown = new ArrayList
            {
                "T97"
            };

        public Deck()
        {
            DominoDeck = new ArrayList();
            DeckSize = 24;
            for (int i = 0; i < DeckSize; i++)
            {
                DominoDeck.Add(new Domino(new Tile(), new Tile()));
            }
        }

        public Deck(int deckSize)
        {
            DominoDeck = new ArrayList();
            DeckSize = deckSize;


            int nameIndex1 = 2;
            int nameIndex2 = 3;

            for (int i = 0; i < DeckSize; i++)
            {

                EnvironmentTypes envType1 = EnvironmentTypes.Default;
                int numCrowns1 = 0;
                bool filledSpace1 = false;
                string tileImageName1 = "Empty";
                int x1 = -1;
                int y1 = -1;
                int width1 = -1;
                int height1 = -1;


                EnvironmentTypes envType2 = EnvironmentTypes.Default;
                int numCrowns2 = 0;
                bool filledSpace2 = false;
                string tileImageName2 = "Empty";
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
                if (EnvNamesForrest.Contains(tileImageName1)) envType1 = EnvironmentTypes.Forrest;
                if (EnvNamesForrest.Contains(tileImageName2)) envType2 = EnvironmentTypes.Forrest;
                if (EnvNamesVillage.Contains(tileImageName1)) envType1 = EnvironmentTypes.Village;
                if (EnvNamesVillage.Contains(tileImageName2)) envType2 = EnvironmentTypes.Village;
                if (EnvNamesGarden.Contains(tileImageName1)) envType1 = EnvironmentTypes.Garden;
                if (EnvNamesGarden.Contains(tileImageName2)) envType2 = EnvironmentTypes.Garden;

                if (SingleCrown.Contains(tileImageName1)) numCrowns1 = 1;
                if (SingleCrown.Contains(tileImageName2)) numCrowns2 = 1;
                if (DoubleCrown.Contains(tileImageName1)) numCrowns1 = 2;
                if (DoubleCrown.Contains(tileImageName2)) numCrowns2 = 2;
                if (TripleCrown.Contains(tileImageName1)) numCrowns1 = 3;
                if (TripleCrown.Contains(tileImageName2)) numCrowns2 = 3;

                DominoDeck.Add(new Domino(new Tile(envType1, numCrowns1, filledSpace1, tileImageName1, x1, y1, width1, height1),
                    new Tile(envType2, numCrowns2, filledSpace2, tileImageName2, x2, y2, width1, height1)));
                nameIndex1 += 2;
                nameIndex2 += 2;
            }
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
        public ArrayList EnvNamesForrest
        {
            get { return envNamesForrest; }
        }
        public ArrayList EnvNamesVillage
        {
            get { return envNamesVillage; }
        }
        public ArrayList EnvNamesGarden
        {
            get { return envNamesGarden; }
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
