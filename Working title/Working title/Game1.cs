using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.Cells;
using Working_title.MapGenerator;

namespace Working_title
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static List<GameObject> Objects = new List<GameObject>();
        public static List<CollidingSprite> CollidingSprites = new List<CollidingSprite>();
        public static Dictionary<string,Texture2D> Textures = new Dictionary<string, Texture2D>();
        public static Dictionary<string,SpriteFont> SpriteFonts = new Dictionary<string, SpriteFont>(); 

        private static List<GameObject> ObjectsToAddInNextCycle = new List<GameObject>();
        private static List<GameObject> ObjectsToRemoveInNextCycle = new List<GameObject>();

        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private MapBuilder MapBuilder;
        private static object SyncObject = new object();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here
            MapBuilder = new MapBuilder(new Size(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight));
            base.Initialize();
        }

   

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            LoadTextures();
            LoadSpriteFonts();
            LoadContentOnSprites();
            // Kommenter linjen under ud, hvis man ikke vil have at mappet automatisk fylder skærmen.
            LoadMap();
        }

        private void LoadTextures()
        {
            Textures.Add("Blue", Content.Load<Texture2D>("Images/Blue"));
            Textures.Add("Green", Content.Load<Texture2D>("Images/Green"));
            Textures.Add("Yellow", Content.Load<Texture2D>("Images/Yellow"));
            Textures.Add("Black", Content.Load<Texture2D>("Images/Black"));
            Textures.Add("UpUp", Content.Load<Texture2D>("Images/UpUp"));
            Textures.Add("RightRight", Content.Load<Texture2D>("Images/RightRight"));
            Textures.Add("UpRight", Content.Load<Texture2D>("Images/UpRight"));
            Textures.Add("UpLeft", Content.Load<Texture2D>("Images/UpLeft"));
            Textures.Add("DownLeft", Content.Load<Texture2D>("Images/DownLeft"));
            Textures.Add("DownRight", Content.Load<Texture2D>("Images/DownRight"));
        }

        private void LoadSpriteFonts()
        {
            SpriteFonts.Add("StandardFont", Content.Load<SpriteFont>("Fonts/StandardFont"));
        }

        private void LoadContentOnSprites()
        {
            foreach (var GameObject in Objects)
            {
                (GameObject as Sprite)?.LoadContent();
            }
        }

        private void LoadMap()
        {
            Thread MapBuilderThread = new Thread(() => MapBuilder.Build());
            MapBuilderThread.Start();
        }

       

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            RemoveObjects();
            AddObjects();

            UpdateObjects(gameTime);
            

            base.Update(gameTime);
        }

        private void UpdateObjects(GameTime gameTime)
        {
            foreach (var GameObject in Objects)
            {
                GameObject.Update(gameTime.ElapsedGameTime.Milliseconds);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.FrontToBack);
            DrawSprites(SpriteBatch);
            SpriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void DrawSprites(SpriteBatch spriteBatch)
        {
            foreach (var GameObject in Objects)
            {
                (GameObject as Sprite)?.Draw(spriteBatch);
            }
        }

        public static void AddObjectInNextCycle(GameObject objectToAdd)
        {
            lock (SyncObject)
            {
                ObjectsToAddInNextCycle.Add(objectToAdd);
            }
            
        }

        public static void RemoveObjectInNextCycle(GameObject objectToRemove)
        {
            ObjectsToRemoveInNextCycle.Add(objectToRemove);
        }

        private void AddObjects()
        {
            lock (SyncObject)
            {
                foreach (GameObject ObjectToAdd in ObjectsToAddInNextCycle)
                {
                    if (!Objects.Contains(ObjectToAdd))
                    {
                        Objects.Add(ObjectToAdd);
                        (ObjectToAdd as Sprite)?.LoadContent();
                        if (ObjectToAdd is CollidingSprite)
                        {
                            CollidingSprites.Add(ObjectToAdd as CollidingSprite);
                        }
                    }
                }
                ObjectsToAddInNextCycle.Clear();
            }
        }

        private void RemoveObjects()
        {
            foreach (GameObject ObjectToRemove in ObjectsToRemoveInNextCycle)
            {
                if (Objects.Contains(ObjectToRemove))
                {
                    Objects.Remove(ObjectToRemove);
                }
            }
            ObjectsToRemoveInNextCycle.Clear();
        }
    }
}
