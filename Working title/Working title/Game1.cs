using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.UI.Buttons;

namespace Working_title
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
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

            btnLoginOk = new LoginOk(Content.Load<Texture2D>("BtnOk"), graphics.GraphicsDevice);
            btnLoginOk.SetPosition(new Vector2(475, 500));

            btnRegister= new Register(Content.Load<Texture2D>("BtnRegister"), graphics.GraphicsDevice);
            btnRegister.SetPosition(new Vector2(175, 500));
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



            base.Update(gameTime);
        }


        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
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
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
