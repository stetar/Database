using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.UI.Buttons;
using Working_title.Cells;
using Working_title.MapGenerator;


namespace Working_title
{

    public class Game1 : Game
    {
        private LoginOk btnLoginOk;
        private Register btnRegister;
        int screenWidth = 800;
        int screenHeight = 600;

        enum GameState
        {
            Login,      // Login, Password, OK, Register 
            Register,   // Hvis register er valgt : Wished login, Wished password, Ok, --> Gem database --> Send til MainMenu 
            MainMenu,   // Start Game, About the game, Credits, Exit Game
            Playing,    // Spillogik her
            Closing,    // Gemmer alt data til databaserne så progression ikke mistes.
        }

        GameState CurrentGameState = GameState.Login;
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


        protected override void Initialize()
        {
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

            LoadLoginStuff();
            LoadTextures();
            LoadSpriteFonts();
            LoadContentOnSprites();
            // Kommenter linjen under ud, hvis man ikke vil have at mappet automatisk fylder skærmen.
            //LoadMap();
        }

        private void LoadLoginStuff()
        {
            Graphics.PreferredBackBufferWidth = screenWidth;
            Graphics.PreferredBackBufferHeight = screenHeight;

            Graphics.ApplyChanges();
            IsMouseVisible = true;

            btnLoginOk = new LoginOk(Content.Load<Texture2D>("BtnOk"), Graphics.GraphicsDevice);
            btnLoginOk.SetPosition(new Vector2(475, 500));

            btnRegister = new Register(Content.Load<Texture2D>("BtnRegister"), Graphics.GraphicsDevice);
            btnRegister.SetPosition(new Vector2(175, 500));
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
            MapBuilder = new MapBuilder(new Size(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight));
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


        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            RemoveObjects();
            AddObjects();

            MouseState mouseState = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.Login:
                    if (btnLoginOk.LoginOkIsClicked == true) CurrentGameState = GameState.MainMenu;
                    if (btnRegister.RegisterIsClicked == true) CurrentGameState = GameState.Register;

                    btnLoginOk.Update(mouseState);
                    btnRegister.Update(mouseState);
                    break;

                case GameState.Register:
                    break;

                case GameState.MainMenu:
                    break;

                case GameState.Playing:
                    break;

                case GameState.Closing:
                    break;
            }


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
            DrawLoginScreen(SpriteBatch);
            SpriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void DrawLoginScreen(SpriteBatch spriteBatch)
        {
            switch (CurrentGameState)
            {
                case GameState.Login:
                    spriteBatch.Draw(Content.Load<Texture2D>("loginBg"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnLoginOk.Draw(spriteBatch);
                    btnRegister.Draw(spriteBatch);
                    break;

                case GameState.Register:
                    break;

                case GameState.MainMenu:
                    break;

                case GameState.Playing:
                    break;

                case GameState.Closing:
                    this.Exit();
                    break;
            }
            
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
