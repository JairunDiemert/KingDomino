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
        int whereInDeck;
        int deckButton1;
        int deckButton2;
        int deckButton3;
        int deckButton4;
        Rectangle positionAndSize;
        int deckPositionY1;
        int deckPositionY2;
        int deckPositionY3;
        int deckPositionY4;

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
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 600;

            Window.AllowUserResizing = true;
            IsMouseVisible = true;
            
            graphics.ApplyChanges();
            oldState = Keyboard.GetState();
            whereInDeck = 4;
            deckButton1 = 0;
            deckButton2 = 1;
            deckButton3 = 2;
            deckButton4 = 3;
            deckSize = 24;
            deckPositionY1 = 0;
            deckPositionY2 = 1;
            deckPositionY3 = 2;
            deckPositionY4 = 3;
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
            
            //the tileTexture thing in the draw...I think that is going to be info that we get from the array..somehow
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    currentTile = gameBoard.getTileAt(i,j);
                    positionAndSize.X = i * tileSize;
                    positionAndSize.Y = j * tileSize;
                    tileTexture = Content.Load<Texture2D>(boardControl.TypeChecker(currentTile.EnvType));
                    spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
                }
            }
            positionAndSize.X = 3 * tileSize;
            positionAndSize.Y = 3 * tileSize;
            tileTexture = Content.Load<Texture2D>("C1");
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            UpdateDeck(deckButton1, deckPositionY1);
            UpdateDeck(deckButton2, deckPositionY2);
            UpdateDeck(deckButton3, deckPositionY3);
            UpdateDeck(deckButton4, deckPositionY4);

            tileTexture = Content.Load<Texture2D>("K1");
            spriteBatch.Draw(tileTexture, new Rectangle((8 * tileSize) + tileSize/2 + tileSize/4, 0 * tileSize + tileSize/4, tileSize/2, tileSize/2), Color.White);
            
            KeyboardState newState = Keyboard.GetState();  // get the newest state
            DeckButtonInput(newState);
            oldState = newState;

            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void DeckButtonInput(KeyboardState newState)
        {
            if(oldState.IsKeyUp(Keys.D1) && newState.IsKeyDown(Keys.D1))
            {
                if(whereInDeck < deckSize){
                    deckButton1 = whereInDeck;
                    currentDomino = (Domino)gameDeck.DominoDeck[deckButton1];
                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(8 * tileSize, (0 * tileSize), tileSize, tileSize), Color.White);

                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(9 * tileSize, (0 * tileSize), tileSize, tileSize), Color.White);
                    whereInDeck++;
                }
                else{
                
                }
            } 
            else if(oldState.IsKeyUp(Keys.D2) && newState.IsKeyDown(Keys.D2))
            {
                if(whereInDeck < deckSize){
                    deckButton2 = whereInDeck;
                    currentDomino = (Domino)gameDeck.DominoDeck[deckButton2];
                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(8 * tileSize, (1 * tileSize), tileSize, tileSize), Color.White);

                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(9 * tileSize, (1 * tileSize), tileSize, tileSize), Color.White);
                    whereInDeck++;
                }
                else{
                
                }
            }
            else if(oldState.IsKeyUp(Keys.D3) && newState.IsKeyDown(Keys.D3))
            {
                if(whereInDeck < deckSize){
                    deckButton3 = whereInDeck;
                    currentDomino = (Domino)gameDeck.DominoDeck[deckButton3];
                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(8 * tileSize, (2 * tileSize), tileSize, tileSize), Color.White);

                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(9 * tileSize, (2 * tileSize), tileSize, tileSize), Color.White);
                    whereInDeck++;
                }
                else{
                
                }
            }
            else if(oldState.IsKeyUp(Keys.D4) && newState.IsKeyDown(Keys.D4))
            {
                if(whereInDeck < deckSize){
                    deckButton4 = whereInDeck;
                    currentDomino = (Domino)gameDeck.DominoDeck[deckButton4];
                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(8 * tileSize, (3 * tileSize), tileSize, tileSize), Color.White);

                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(9 * tileSize, (3 * tileSize), tileSize, tileSize), Color.White);
                    whereInDeck++;
                }
                else{
                
                }
            }
        }
        public void UpdateDeck(int where, int y)
        {
            currentDomino = (Domino)gameDeck.DominoDeck[where];

            tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
            positionAndSize.X = 8 * tileSize;
            positionAndSize.Y = 2 * tileSize;
            currentDomino.Tile1.PositionAndSize = positionAndSize;
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);

            tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
            positionAndSize.X = 9 * tileSize;
            positionAndSize.Y = 2 * tileSize;
            currentDomino.Tile2.PositionAndSize = positionAndSize;
            spriteBatch.Draw(tileTexture, positionAndSize, Color.White);
        }
    }
}
