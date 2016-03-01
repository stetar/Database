using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Working_title.MapGenerator;
using Working_title.MoveableClasses;

namespace Working_title.Screens
{
    public class MapScreen : Screen
    {
        private MapBuilder MapBuilder;
        private Player Player;

        public override void Init()
        {
            MapBuilder = new MapBuilder(Game1.ScreenSize);
            Player = new Player(Vector2.Zero, MapBuilder.GridMap);
            AddObjectToLoadingList(Player);
        }

        public override void Load()
        {
            base.Load();
            Thread MapThread = new Thread(() => MapBuilder.Build(OnMapFinnished));
            MapThread.Start();
        }

        private void OnMapFinnished(List<BuildObject> objectsInMap)
        {
            GridMap GridMap = MapBuilder.GridMap;
            Cell RandomCell = GridMap.GetRandomCell();
            Vector2 PlayerSpawnPosition = RandomCell.Position;
            Player.Position = PlayerSpawnPosition;
        }
    }
}