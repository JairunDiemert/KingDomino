using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace KingDomino
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        ViewLogic viewLogic;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tileTexture;
        Texture2D square;
        Texture2D square2;
        Board gameBoard;
        BoardControler boardControl;
        Deck gameDeck;
        int deckSize;
        int deckBuffer;
        int tileSize;
        int grid;
        Tile currentTile;
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

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameBoard = new Board();
            boardControl = new BoardControler();
            gameDeck = new Deck(deckSize);
            tileSize = boardControl.TileSize;
            grid = boardControl.Grid;
            positionAndSize = new Rectangle(0, 0, tileSize, tileSize);
            positionAndSizeOfPLacement = new Rectangle(playerX, playerY, tileSize, tileSize);
            positionAndSizeOfPLacement2 = new Rectangle(playerX + 1, playerY, tileSize, tileSize);


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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            viewLogic = new ViewLogic(ref spriteBatch, tileSize, ref gameDeck, ref positionAndSize, ref gameBoard);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            viewLogic.PositionAndSizeOfPlacementUpdate(ref positionAndSizeOfPLacement, ref positionAndSizeOfPLacement2, playerX, playerY, playerX2, playerY2);
           /* positionAndSizeOfPLacement.X = playerX * tileSize;
            positionAndSizeOfPLacement.Y = playerY * tileSize;
            positionAndSizeOfPLacement2.X = playerX2 * tileSize;
            positionAndSizeOfPLacement2.Y = playerY2 * tileSize;*/


            //Draws boards
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    String texture = viewLogic.DrawBoard(ref boardControl, i, j, ref positionAndSize, 0);
                    tileTexture = Content.Load<Texture2D>(texture);
                    spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
                }
            }
            
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    String texture = viewLogic.DrawBoard(ref boardControl, i, j, ref positionAndSize, 10);
                    tileTexture = Content.Load<Texture2D>(texture);
                    spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
                }
            }

            positionAndSize.X = 4 * tileSize;
            positionAndSize.Y = 4 * tileSize;
            tileTexture = Content.Load<Texture2D>("C1");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            positionAndSize.X = 14 * tileSize;
            positionAndSize.Y = 4 * tileSize;
            tileTexture = Content.Load<Texture2D>("C3");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);



            UpdateDeck(deckButton1, deckPositionX1, deckPositionY1);
            UpdateDeck(deckButton2, deckPositionX1, deckPositionY2);
            UpdateDeck(deckButton3, deckPositionX1, deckPositionY3);
            UpdateDeck(deckButton4, deckPositionX1, deckPositionY4);
            UpdateDeck(deckButton5, deckPositionX1 + 3, deckPositionY1);
            UpdateDeck(deckButton6, deckPositionX1 + 3, deckPositionY2);
            UpdateDeck(deckButton7, deckPositionX1 + 3, deckPositionY3);
            UpdateDeck(deckButton8, deckPositionX1 + 3, deckPositionY4);

            positionAndSize.X = 19 * tileSize;
            positionAndSize.Y = 0 * tileSize;
            tileTexture = Content.Load<Texture2D>("K1");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            positionAndSize.X = 19 * tileSize;
            positionAndSize.Y = 1 * tileSize;
            tileTexture = Content.Load<Texture2D>("K1");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            positionAndSize.X = 19 * tileSize;
            positionAndSize.Y = 2 * tileSize;
            tileTexture = Content.Load<Texture2D>("K3");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            positionAndSize.X = 19 * tileSize;
            positionAndSize.Y = 3 * tileSize;
            tileTexture = Content.Load<Texture2D>("K3");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            spriteBatch.Draw(square, positionAndSizeOfPLacement, Color.Red);
            spriteBatch.Draw(square2, positionAndSizeOfPLacement2, Color.Red);

            KeyboardState newState = Keyboard.GetState();  // get the newest state
            //DeckButtonInput(newState);
            PlayerInput(newState, deckButton1);
            oldState = newState;

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //TODO: add more keys A left D right etc this is just a baseline
        public void PlayerInput(KeyboardState state, int playerDomino) {

            MovementLogic movement = new MovementLogic();


            movement.KeyboardMovement(ref oldState,ref state,ref playerX,ref playerY,ref playerX2,ref playerY2);
            movement.Rotation(ref oldState,ref state,ref playerX,ref playerY,ref playerX2,ref playerY2,ref rotateDeg);
            //movement.Placement(ref oldState,ref state,ref playerX,ref playerY,ref playerX2,ref playerY2, ref rotateDeg);
            
            if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 0) // below does normal 0
            {
                int nextTile = playerX + 1;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.DominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.Tile1);
                gameBoard.setTileAt(nextTile, playerY, currentDomino.Tile2);
            }
            else if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 90) // does 90 
            {
                int nextTile = playerX;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.DominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.Tile1);
                gameBoard.setTileAt(nextTile, playerY - 1, currentDomino.Tile2);
            }
            else if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 180) // below does 180
            {
                int nextTile = playerX - 1;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.DominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.Tile1);
                gameBoard.setTileAt(nextTile, playerY, currentDomino.Tile2);
            }
            else if (oldState.IsKeyUp(Keys.Enter) && state.IsKeyDown(Keys.Enter) && rotateDeg == 270) // below does 270
            {
                int nextTile = playerX;
                IncrementDeck();
                currentDomino = (Domino)gameDeck.DominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.Tile1);
                gameBoard.setTileAt(nextTile, playerY + 1, currentDomino.Tile2);
            }
        }

        
        public void UpdateDeck(int where, int x, int y)
        {

            currentDomino = (Domino)gameDeck.DominoDeck[where];
            viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 0);
            tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
            viewLogic.UpdateDeck(ref currentDomino, ref x, ref y, ref positionAndSize, 1);
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
            /*
            currentDomino = (Domino)gameDeck.DominoDeck[where];

            tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
            positionAndSize.X = x * tileSize;
            positionAndSize.Y = y * tileSize;
            currentDomino.Tile1.PositionAndSize = positionAndSize;
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
            positionAndSize.X = (x + 1) * tileSize;
            positionAndSize.Y = y * tileSize;
            currentDomino.Tile2.PositionAndSize = positionAndSize;
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);*/
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
    }
}
