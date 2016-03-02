namespace Working_title
{
    public enum GameState
    {
        MainMenu,   // Start Game, About the game, Credits, Exit Game
        Playing,    // Spillogik her
        Closing,    // Gemmer alt data til databaserne så progression ikke mistes.
        MapLoading, // Loading map
        Credits, 
        AboutGame,   // About the game screen
        None        // No state chosen
    }
}