using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            whereInDeck = 0;
            deckSize = 24;
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
            tileSize = boardControl.GetTileSize();
            grid = boardControl.GetGridSize();
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

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            
            //the tileTexture thing in the draw...I think that is going to be info that we get from the array..somehow
            for (int i = 0; i < grid; ++i)
            {
                for (int j = 0; j < grid; ++j)
                {
                    currentTile = gameBoard.getTileAt(i,j);
                    tileTexture = Content.Load<Texture2D>(boardControl.TypeChecker(currentTile.EnvType));
                    spriteBatch.Draw(tileTexture, new Rectangle(i * tileSize, j * tileSize, tileSize, tileSize), Color.White);
                }
            }

            tileTexture = Content.Load<Texture2D>("C1");
            spriteBatch.Draw(tileTexture, new Rectangle(3 * tileSize, 3 * tileSize, tileSize, tileSize), Color.White);

            //testing to see if can display domino from populated list

                currentDomino = (Domino)gameDeck.DominoDeck[whereInDeck];
                tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
                spriteBatch.Draw(tileTexture, new Rectangle(8 * tileSize, (0 * tileSize), tileSize, tileSize), Color.White);

                tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
                spriteBatch.Draw(tileTexture, new Rectangle(9 * tileSize, (0 * tileSize), tileSize, tileSize), Color.White);
                

            tileTexture = Content.Load<Texture2D>("K1");
            spriteBatch.Draw(tileTexture, new Rectangle((8 * tileSize) + tileSize/2 + tileSize/4, 0 * tileSize + tileSize/4, tileSize/2, tileSize/2), Color.White);
            
            KeyboardState newState = Keyboard.GetState();  // get the newest state
 
            // handle the input
            if(oldState.IsKeyUp(Keys.A) && newState.IsKeyDown(Keys.A))
            {
                if(whereInDeck <= deckSize){
                    currentDomino = (Domino)gameDeck.DominoDeck[whereInDeck];
                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile1.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(8 * tileSize, (0 * tileSize), tileSize, tileSize), Color.White);

                    tileTexture = Content.Load<Texture2D>(currentDomino.Tile2.TileImageName);
                    spriteBatch.Draw(tileTexture, new Rectangle(9 * tileSize, (0 * tileSize), tileSize, tileSize), Color.White);
                    whereInDeck++;
                }
                else{
                
                }
            }

            oldState = newState;


            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
