namespace Working_title
{
    public enum GameState
    {
        Login,      // Login, Password, OK, Register 
        Register,   // Hvis register er valgt : Wished login, Wished password, Ok, --> Gem database --> Send til MainMenu 
        MainMenu,   // Start Game, About the game, Credits, Exit Game
        Playing,    // Spillogik her
        Closing,    // Gemmer alt data til databaserne så progression ikke mistes.
        None        // No state chosen
    }
}