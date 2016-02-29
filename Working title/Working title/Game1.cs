using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_RPG_thread_game.Utillity;
using Working_title.UI.Buttons;
using Working_title.Cells;
using Working_title.MapGenerator;
using Working_title.MoveableClasses;
using Working_title.Screens;
using Working_title.Setup;


namespace Working_title
{

    public class Game1 : Game
    {

        public static GameState CurrentGameState = GameState.Login;
        public static List<GameObject> Objects = new List<GameObject>();
        public static List<CollidingSprite> CollidingSprites = new List<CollidingSprite>();
        public static Dictionary<string,Texture2D> Textures = new Dictionary<string, Texture2D>();
        public static Dictionary<string,SpriteFont> SpriteFonts = new Dictionary<string, SpriteFont>();

        private static GraphicsDeviceManager Graphics;
        private static List<GameObject> ObjectsToAddInNextCycle = new List<GameObject>();
        private static List<GameObject> ObjectsToRemoveInNextCycle = new List<GameObject>();
        private static GameState LastGameState = GameState.None;

        private SpriteBatch SpriteBatch;
        private static object SyncObject = new object();
        private List<WorldSetup> WorldSetups = new List<WorldSetup>();
        private List<Screen> Screens = new List<Screen>();
        private Screen CurrentScreen;
        

        public static Size ScreenSize
        {
            get
            {
                return new Size(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
            }
            set
            {
                Graphics.PreferredBackBufferWidth = value.Width;
                Graphics.PreferredBackBufferHeight = value.Height;

                Graphics.ApplyChanges();
            }
        } 


        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            AddWorldSetups();
            AddScreens();
        }


        protected override void Initialize()
        {
            base.Initialize();
            WorldSetups.DoActionOnItems(setup => setup.Init());
            Screens.DoActionOnItems(screen => screen.Init());
        }

        private void AddWorldSetups()
        {
            WorldSetups.Add(new DebugSetup());
            WorldSetups.Add(new GeneralSetup());
            WorldSetups.Add(new LoginSetup());
            WorldSetups.Add(new MapSetup());
            WorldSetups.Add(new PlayerSetup());
        }

        private void AddScreens()
        {
            Screens.Add(new LoginScreen());
            Screens.Add(new MapScreen());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            WorldSetups.DoActionOnItems(setup => setup.LoadContent(Content));
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

            if (CurrentGameState != LastGameState)
            {
                CurrentScreen?.UnLoad();
                LoadScreen(CurrentGameState);
                CurrentScreen?.Load();
            }
            LastGameState = CurrentGameState;
            UpdateObjects(gameTime);

            base.Update(gameTime);
        }

        private void LoadScreen(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Login:
                    CurrentScreen = Screens.Find(screen => screen is LoginScreen);
                    break;

                case GameState.Register:
                    break;

                case GameState.MainMenu:
                    break;

                case GameState.Playing:
                    CurrentScreen = Screens.Find(screen => screen is MapScreen);
                    break;

                case GameState.Closing:
                    break;
            }
        }


        private void UpdateObjects(GameTime gameTime)
        {
            foreach (var GameObject in Objects)
            {
                UiButton UiButton = GameObject as UiButton;
                UiButton?.Update(Mouse.GetState());
                GameObject.Update(gameTime);
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
