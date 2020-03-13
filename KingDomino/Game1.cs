using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace KingDomino
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tileTexture;
        Board gameBoard;
        BoardControler boardControl;
        Deck gameDeck;
        int deckSize;
        int tileSize;
        int grid;
        Tile currentTile;
        Domino currentDomino;
        KeyboardState oldState;
        int playerDomino;
        int whereInDeck;
        int deckButton1;
        int deckButton2;
        int deckButton3;
        int deckButton4;
        int deckButton5;
        int deckButton6;
        int deckButton7;
        int deckButton8;
        Rectangle positionAndSize;
        int deckPositionY1;
        int deckPositionY2;
        int deckPositionY3;
        int deckPositionY4;
        int deckPositionX1;
        int playerX;
        int playerY;

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
            whereInDeck = 8;
            deckButton1 = 0;
            deckButton2 = 1;
            deckButton3 = 2;
            deckButton4 = 3;
            deckButton5 = 4;
            deckButton6 = 5;
            deckButton7 = 6;
            deckButton8 = 7;
            deckSize = 24;
            deckPositionY1 = 0;
            deckPositionY2 = 1;
            deckPositionY3 = 2;
            deckPositionY4 = 3;
            deckPositionX1 = 20;

            playerX = 0;
            playerY = 0;
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
            gameDeck = new Deck(24);
            tileSize = boardControl.TileSize;
            grid = boardControl.Grid;
            positionAndSize = new Rectangle(0,0,tileSize, tileSize);

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
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            
            //Draws boards
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    currentTile = gameBoard.getTileAt(i,j);
                    positionAndSize.X = i * tileSize;
                    positionAndSize.Y = j * tileSize;
                    if(boardControl.DefaultChecker(currentTile.EnvType)){
                        tileTexture = Content.Load<Texture2D>("T1");
                    }
                    else {
                        tileTexture = Content.Load<Texture2D>(currentTile.TileImageName);
                    }
                    
                    spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
                }
            }
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    currentTile = gameBoard.getTileAt(i, j);
                    positionAndSize.X = (i + 10) * tileSize;
                    positionAndSize.Y = j * tileSize;
                    if(boardControl.DefaultChecker(currentTile.EnvType)){
                        tileTexture = Content.Load<Texture2D>("T1");
                    }
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

            KeyboardState newState = Keyboard.GetState();  // get the newest state
            DeckButtonInput(newState);
            PlayerInput(newState, deckButton1);
            oldState = newState;

            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void PlayerInput(KeyboardState state, int playerDomino){
            
            if(oldState.IsKeyUp(Keys.A) && state.IsKeyDown(Keys.A))
            {
                currentDomino = (Domino)gameDeck.DominoDeck[playerDomino];
                gameBoard.setTileAt(playerX, playerY, currentDomino.Tile1);
                gameBoard.setTileAt(++playerX, playerY, currentDomino.Tile2);
            }
        }

        public void DeckButtonInput(KeyboardState newState)
        {
            if(oldState.IsKeyUp(Keys.D1) && newState.IsKeyDown(Keys.D1))
            {
                if(whereInDeck < deckSize){
                    playerDomino = deckButton1;
                    deckButton5 = whereInDeck;
                    UpdateDeck(deckButton5, deckPositionX1 + 3, deckPositionY1);
                    whereInDeck++;
                }
                else{
                
                }
            } 
            else if(oldState.IsKeyUp(Keys.D2) && newState.IsKeyDown(Keys.D2))
            {
                if(whereInDeck < deckSize){
                    deckButton6 = whereInDeck;
                    UpdateDeck(deckButton6, deckPositionX1 + 3, deckPositionY2);
                    whereInDeck++;
                }
                else{
                
                }
            }
            else if(oldState.IsKeyUp(Keys.D3) && newState.IsKeyDown(Keys.D3))
            {
                if(whereInDeck < deckSize){
                    deckButton7 = whereInDeck;
                    UpdateDeck(deckButton7, deckPositionX1 + 3, deckPositionY3);
                    whereInDeck++;
                }
                else{
                
                }
            }
            else if(oldState.IsKeyUp(Keys.D4) && newState.IsKeyDown(Keys.D4))
            {
                if(whereInDeck < deckSize){
                    deckButton8 = whereInDeck;
                    UpdateDeck(deckButton8, deckPositionX1 + 3, deckPositionY4);
                    whereInDeck++;
                }
                else{
                
                }
            }
        }
        public void UpdateDeck(int where, int x, int y)
        {
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
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
        }
    }
}
