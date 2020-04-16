using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace KingDomino
{
    public class Game1 : Game
    {
        RoundLogic roundLogic;
        ViewLogic viewLogic;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
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
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            roundLogic = new RoundLogic(2);
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
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
            UpdateDeck(deckButton5, deckPositionX1 + 3, deckPositionY1);
            UpdateDeck(deckButton6, deckPositionX1 + 3, deckPositionY2);
            UpdateDeck(deckButton7, deckPositionX1 + 3, deckPositionY3);
            UpdateDeck(deckButton8, deckPositionX1 + 3, deckPositionY4);

            String meeple = viewLogic.DrawMeeples(ref positionAndSize, 0, tileSize, 1);
            tileTexture = Content.Load<Texture2D>(meeple);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            meeple = viewLogic.DrawMeeples(ref positionAndSize, 1, tileSize, 1);
            tileTexture = Content.Load<Texture2D>(meeple);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            meeple = viewLogic.DrawMeeples(ref positionAndSize, 2, tileSize, 2);
            tileTexture = Content.Load<Texture2D>(meeple);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            meeple = viewLogic.DrawMeeples(ref positionAndSize, 3, tileSize, 2);
            tileTexture = Content.Load<Texture2D>(meeple);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            spriteBatch.Draw(square, positionAndSizeOfPLacement, Color.Red);
            spriteBatch.Draw(square2, positionAndSizeOfPLacement2, Color.Red);

            spriteBatch.Draw(square, positionAndSizeOfPLacement, Color.Red);
            spriteBatch.Draw(square2, positionAndSizeOfPLacement2, Color.Red);

            KeyboardState newState = Keyboard.GetState();  // get the newest state
            //DeckButtonInput(newState);
            PlayerInput(newState, deckButton1);
            oldState = newState;

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void PlayerInput(KeyboardState state, int playerDomino) {
            movement.KeyboardMovement(ref oldState,ref state,ref playerX,ref playerY,ref playerX2,ref playerY2);
            movement.Rotation(ref oldState,ref state,ref playerX,ref playerY,ref playerX2,ref playerY2,ref rotateDeg);
            bool placed = movement.Placement(ref oldState,ref state,ref playerX,ref playerY,ref playerX2,ref playerY2, ref rotateDeg,ref currentDomino, ref gameDeck, ref playerDomino, ref roundLogic.currentBoardAtPlay(ref gameBoard1, ref gameBoard2), IncrementDeck);
            roundLogic.changePlayerTurn(placed);
        }
        public void UpdateDeck(int where, int x, int y)
        {
            currentDomino = (Domino)gameDeck.dominoDeck[where];
            viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 0);
            tileTexture = Content.Load<Texture2D>(currentDomino.tile1.tileName);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            tileTexture = Content.Load<Texture2D>(currentDomino.tile2.tileName);
            viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 1);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
        }
        
        public void IncrementDeck()
        {
            if (whereInDeck < (deckSize + deckBuffer))
            {
                deckButton1 += 1;
                deckButton2 += 1;
                deckButton3 += 1;
                deckButton4 += 1;
                deckButton5 += 1;
                deckButton6 += 1;
                deckButton7 += 1;
                deckButton8 += 1;
                ++whereInDeck;
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
