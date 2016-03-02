using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Working_title.MapGenerator;
using Working_title.Utillity;

namespace Working_title.Screens
{
    public class MapLoadingScreen : Screen
    {
        private MapBuilder MapBuilder;
        private LoadingBar LoadingBar;

        public override void Init()
        {
            MapBuilder = new MapBuilder(new Size(10, 10));
            Game1.MapBuilder = MapBuilder;
            LoadingBar = new LoadingBar(new Vector2(150, 250), new Size(400, 50), 4,OnLoadingBarDone);
            AddObjectToLoadingList(LoadingBar);
            AddObjectToLoadingList(new NonCollidingStaticSprite(Vector2.Zero, Game1.ScreenSize , "Blue", 0.8f));
        }

        public override void Load()
        {
            base.Load();
            Thread MapThread = new Thread(() => MapBuilder.Build(OnMapCallBack));
            MapThread.Start();
            MapThread.Priority = ThreadPriority.Highest;
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