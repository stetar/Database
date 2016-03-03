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

        public override void Init()
        {
            MapBuilder MapBuilder = Game1.MapBuilder;
            AddPlayer(MapBuilder.GridMap);
        }



        public void AddPlayer(GridMap gridmap)
        {
            Cell RandomCell = gridmap.GetRandomCell();
            Vector2 PlayerSpawnPosition = RandomCell.Position;
            AddObjectToLoadingList(new Player(PlayerSpawnPosition, gridmap));
        }

    }
}