using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.UI.Buttons;
using Working_title.Forms;
using System.Data.SQLite;

namespace Working_title
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private StartGame btnStart;
        private AboutTheGame btnAbout;
        private Credit btnCredits;
        private ExitGame btnExit;
        int screenWidth = 800;
        int screenHeight = 600;

        public enum GameState
        {
            Login,      // Login, Password, OK, Register 
            Register,   // Hvis register er valgt : Wished login, Wished password, Ok, --> Gem database --> Send til MainMenu 
            MainMenu,   // Start Game, About the game, Credits, Exit Game
            About,      // Om spillet, controls, historie etc
            Credits,    // Om os udviklerne af spillet
            Playing,    // Spillogik her
            Closing,    // Gemmer alt data til databaserne så progression ikke mistes.
        }

       public static GameState CurrentGameState = GameState.Login;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnStart = new StartGame(Content.Load<Texture2D>("BtnStartGame"), graphics.GraphicsDevice);
            btnStart.SetPosition(new Vector2(275, 100));

            btnAbout = new AboutTheGame(Content.Load<Texture2D>("BtnAbout"), graphics.GraphicsDevice);
            btnAbout.SetPosition(new Vector2(275, 200));

            btnCredits = new Credit(Content.Load<Texture2D>("BtnCredits"), graphics.GraphicsDevice);
            btnCredits.SetPosition(new Vector2(275, 300));

            btnExit = new ExitGame(Content.Load<Texture2D>("BtnExit"), graphics.GraphicsDevice);
            btnExit.SetPosition(new Vector2(275, 400));

        }


        protected override void UnloadContent()
        {

        }


        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouseState = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.Login:
                    //WinForms Inputboxes
                    string inputValueLogi = LoginForm.ShowDialog();
                    break;

                case GameState.Register:
                    //WinForms Inputboxes
                    string inputValueRegi = RegisterForm.ShowDialog();
                    
                    break;

                case GameState.MainMenu:

                    if (btnStart.StartIsClicked == true) CurrentGameState = GameState.Playing;
                    if (btnAbout.AboutIsClicked == true) CurrentGameState = GameState.About;
                    if (btnCredits.CreditsIsClicked == true) CurrentGameState = GameState.Credits;
                    if (btnExit.ExitIsClicked == true) CurrentGameState = GameState.Closing;

                    btnStart.Update(mouseState);
                    btnAbout.Update(mouseState);
                    btnCredits.Update(mouseState);
                    btnExit.Update(mouseState);
                    break;

                case GameState.About:
                    break;

                case GameState.Credits:
                    break;

                case GameState.Playing:
                    break;

                case GameState.Closing:
                    this.Exit();
                    break;
            }
            base.Update(gameTime);
        }


        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            switch (CurrentGameState)
            {
                case GameState.Login:
                    break;

                case GameState.Register:
                    break;

                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("loginBg"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

                    btnStart.Draw(spriteBatch);
                    btnAbout.Draw(spriteBatch);
                    btnCredits.Draw(spriteBatch);
                    btnExit.Draw(spriteBatch);
                    break;

                case GameState.About:
                    spriteBatch.Draw(Content.Load<Texture2D>("loginBg"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    break;

                case GameState.Credits:
                    spriteBatch.Draw(Content.Load<Texture2D>("loginBg"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    break;

                case GameState.Playing:
                    break;

                case GameState.Closing:
                    this.Exit();
                    break;
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
