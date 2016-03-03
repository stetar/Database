using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Working_title.Managers;
using Working_title.MapGenerator;
using Working_title.Utillity;

namespace Working_title.Screens
{
    public class MapLoadingScreen : Screen
    {
        private MapBuilder MapBuilder;
        private LoadingBar LoadingBar;
        private MapScreen MapScreen;

        public MapLoadingScreen(MapScreen mapScreen)
        {
            MapScreen = mapScreen;
        }

        public override void Init()
        {
            MapBuilder = new MapBuilder(new Size(50, 50), MapScreen);
            Game1.Camera.Position = Vector2.Zero;
            Game1.MapBuilder = MapBuilder;
            Thread MapThread = new Thread(() => MapBuilder.Build(OnMapCallBack));
            MapThread.Start();
            MapThread.Priority = ThreadPriority.Highest;
            LoadingBar = new LoadingBar(new Vector2(150, 250), new Size(400, 50), 4, OnLoadingBarDone);
            AddObjectToLoadingList(LoadingBar);
            AddObjectToLoadingList(new NonCollidingStaticSprite(Vector2.Zero, Game1.ScreenSize , "MapLoadingBackground", 0.8f));
        }

        private void OnMapCallBack(List<BuildObject> objectsInMap)
        {
            LoadingBar.ReachedLoadingPoint();
        }

        private void OnLoadingBarDone()
        {
            Game1.CurrentGameState = GameState.Playing;
            MapBuilder.CreateObjects();
            UnLoad();
        }
    }
}