using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace KingDomino
{
    public class Game1 : Game
    {
        RoundLogic roundLogic;
        ViewLogic viewLogic;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont textWriter;
        Texture2D tileTexture;
        Texture2D square;
        Texture2D square2;
        Board gameBoard1;
        Board gameBoard2;
        BoardControler boardControl;
        Deck gameDeck;
        MovementLogic movement;
        int deckSize;
        int deckBuffer;
        int tileSize;
        int grid;
        Domino currentDomino;
        KeyboardState oldState;
        Meeple[] meeples;
        int whereInDeck;
        int deckButton1;
        int deckButton2;
        int deckButton3;
        int deckButton4;
        int deckButton5;
        int deckButton6;
        int deckButton7;
        int deckButton8;
        int deckButtonMover;
        Rectangle positionAndSize;
        Rectangle positionAndSizeOfPLacement;
        Rectangle positionAndSizeOfPLacement2;
        Player[] players;
        int deckPositionY1;
        int deckPositionY2;
        int deckPositionY3;
        int deckPositionY4;
        int deckPositionX1;
        int playerX;
        int playerY;
        int playerX2;
        int playerY2;
        int rotateDeg; // either 0, 90, 180, 270
        int numberOfTilesPlaced;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1760;
            graphics.PreferredBackBufferHeight = 640;

            Window.AllowUserResizing = true;
            IsMouseVisible = true;
            graphics.ApplyChanges();
            oldState = Keyboard.GetState();
            meeples = new Meeple[4];
            meeples[0] = new Meeple(0, 2, 2, 1, 2);
            meeples[1] = new Meeple(0, 0, 1, 2, 0);
            meeples[2] = new Meeple(0, 3, 2, 3, 3);
            meeples[3] = new Meeple(0, 1, 1, 4, 1);
            players = new Player[2];
            players[0] = new Player();
            players[1] = new Player();
            deckButtonMover = 0;
            whereInDeck = 8;
            deckButton1 = 0;
            deckButton2 = 1;
            deckButton3 = 2;
            deckButton4 = 3;
            deckButton5 = 4;
            deckButton6 = 5;
            deckButton7 = 6;
            deckButton8 = 7;
            deckBuffer = 8;
            deckSize = 24;
            deckPositionY1 = 0;
            deckPositionY2 = 1;
            deckPositionY3 = 2;
            deckPositionY4 = 3;
            deckPositionX1 = 20;

            square = new Texture2D(GraphicsDevice, 100, 100);
            square2 = new Texture2D(GraphicsDevice, 100, 100);
            square.CreateBorder(5, Color.Red);
            square2.CreateBorder(5, Color.Red);

            playerX = 0;
            playerY = 0;
            playerX2 = 1;
            playerY2 = 0;
            rotateDeg = 0;
            base.Initialize();
            numberOfTilesPlaced = 0;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textWriter = Content.Load<SpriteFont>("TextWriter");
            gameBoard1 = new Board();
            gameBoard2 = new Board();
            boardControl = new BoardControler();
            gameDeck = new Deck(deckSize);
            tileSize = boardControl.tileSize;
            grid = boardControl.grid;
            positionAndSize = new Rectangle(0, 0, tileSize, tileSize);
            positionAndSizeOfPLacement = new Rectangle(playerX, playerY, tileSize, tileSize);
            positionAndSizeOfPLacement2 = new Rectangle(playerX + 1, playerY, tileSize, tileSize);
            movement = new MovementLogic();
            roundLogic = new RoundLogic(ref players, 2);
            viewLogic = new ViewLogic(tileSize, ref gameDeck, ref positionAndSize);

            // TODO: use this.Content to load your game content here
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            
            viewLogic.PositionAndSizeOfPlacementUpdate(ref positionAndSizeOfPLacement, ref positionAndSizeOfPLacement2, playerX, playerY, playerX2, playerY2);

            DrawGameBoard(grid, ref boardControl, ref positionAndSize, 0, ref roundLogic.currentBoardAtPlay(ref gameBoard1, ref gameBoard2));
            DrawGameBoard(grid, ref boardControl, ref positionAndSize, 10, ref roundLogic.secondBoardAtPlay(ref gameBoard1, ref gameBoard2));

            String castle = viewLogic.DrawCastle(ref positionAndSize, 4, tileSize, roundLogic.playerAtTurn);
            tileTexture = Content.Load<Texture2D>(castle);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            castle = viewLogic.DrawCastle(ref positionAndSize, 14, tileSize, roundLogic.secondPlayer());
            tileTexture = Content.Load<Texture2D>(castle);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            UpdateDeck(deckButton1, deckPositionX1, deckPositionY1);
            UpdateDeck(deckButton2, deckPositionX1, deckPositionY2);
            UpdateDeck(deckButton3, deckPositionX1, deckPositionY3);
            UpdateDeck(deckButton4, deckPositionX1, deckPositionY4);
            UpdateDeckHidden(deckButton5, deckPositionX1 + 3, deckPositionY1);
            UpdateDeckHidden(deckButton6, deckPositionX1 + 3, deckPositionY2);
            UpdateDeckHidden(deckButton7, deckPositionX1 + 3, deckPositionY3);
            UpdateDeckHidden(deckButton8, deckPositionX1 + 3, deckPositionY4);

            DrawMeeples(meeples[0]);
            DrawMeeples(meeples[1]);
            DrawMeeples(meeples[2]);
            DrawMeeples(meeples[3]);

            spriteBatch.Draw(square, positionAndSizeOfPLacement, Color.Red);
            spriteBatch.Draw(square2, positionAndSizeOfPLacement2, Color.Red);

            spriteBatch.Draw(square, positionAndSizeOfPLacement, Color.Red);
            spriteBatch.Draw(square2, positionAndSizeOfPLacement2, Color.Red);

            KeyboardState newState = Keyboard.GetState();
            PlayerInputForMeeples(newState);
            int tileNum = 0;
            roundLogic.getProperDomino(ref players, ref tileNum);
            PlayerInputForDominos(newState, deckButton1 + tileNum, roundLogic.allPlaced);
            oldState = newState;

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public void DrawMeeples(Meeple meeple)
        {
            meeple.meepleIcon = viewLogic.DrawMeeples(ref positionAndSize, tileSize, meeple);
            tileTexture = Content.Load<Texture2D>(meeple.meepleIcon);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
        }
        public void PlayerInputForMeeples(KeyboardState newState)
        {
            bool placed = roundLogic.meeplePlacement(newState, oldState, ref meeples);
            roundLogic.incrementMeepleNum(placed);
            roundLogic.changePlayerTurn(placed);
        }
        public void PlayerInputForDominos(KeyboardState state, int playerDomino, bool meeplesPlaced) 
        {
            if (meeplesPlaced)
            {
                movement.KeyboardMovement(ref oldState, ref state, ref playerX, ref playerY, ref playerX2, ref playerY2);
                movement.Rotation(ref oldState, ref state, ref playerX, ref playerY, ref playerX2, ref playerY2, ref rotateDeg);
                bool placed = movement.Placement(ref oldState, ref state, ref playerX, ref playerY, ref playerX2, ref playerY2, ref rotateDeg, ref currentDomino, ref gameDeck, ref playerDomino, ref roundLogic.currentBoardAtPlay(ref gameBoard1, ref gameBoard2), IncrementDeck);
                roundLogic.addDominoes(placed);
                roundLogic.changePlayerTurn(placed);
                roundLogic.resetMeeple(ref meeples);
            }
        }
        public void UpdateDeck(int where, int x, int y)
        {
            if (where < deckSize)
            {
                currentDomino = (Domino)gameDeck.dominoDeck[where];
                viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 0);
                tileTexture = Content.Load<Texture2D>(currentDomino.tile1.tileName);
                spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

                tileTexture = Content.Load<Texture2D>(currentDomino.tile2.tileName);
                viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 1);
                spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
            }
        }
        public void UpdateDeckHidden(int where, int x, int y)
        {
            if (where < deckSize)
            {
                currentDomino = (Domino)gameDeck.dominoDeck[where];
                viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 0);
                tileTexture = Content.Load<Texture2D>("T0");
                if (where < deckSize)
                    spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

                tileTexture = Content.Load<Texture2D>("T0");
                viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 1);
                spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
                spriteBatch.DrawString(textWriter, "" + currentDomino.tile2.tileNumber / 2, new Vector2((x * tileSize) + 51, (y * tileSize) + 23), Color.White);
            }
        }
        public void IncrementDeck()
        {
            ++numberOfTilesPlaced;
            if (numberOfTilesPlaced % 4 == 0)
            {
                numberOfTilesPlaced = 0;
                if (whereInDeck < (deckSize + deckBuffer))
                {
                    deckButton1 += 4;
                    deckButton2 += 4;
                    deckButton3 += 4;
                    deckButton4 += 4;
                    deckButton5 += 4;
                    deckButton6 += 4;
                    deckButton7 += 4;
                    deckButton8 += 4;
                    whereInDeck += 4;
                }
            }
        }
        public void DrawGameBoard(int grid, ref BoardControler boardControl, ref Rectangle positionAndSize, int positionAdder, ref Board gameBoard)
        {
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    String texture = viewLogic.DrawBoard(ref boardControl, i, j, ref positionAndSize, positionAdder, ref gameBoard);
                    tileTexture = Content.Load<Texture2D>(texture);
                    spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
                }
            }
        }
    }
}
