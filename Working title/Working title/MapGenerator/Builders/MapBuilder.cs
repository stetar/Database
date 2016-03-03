using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Working_title.Screens;

namespace Working_title.MapGenerator
{
    public class MapBuilder : Builder
    {
        public bool DoneBuildindMap;

        private readonly Size CellSize = new Size(30, 30);

        private Size MapSize;

        private RoomBuilder RoomBuilder;
        private MazeBuilder MazeBuilder;
        private ConnectorBuilder ConnectorBuilder;
        private DeadEndRemover DeadEndRemover;
        private GridMap MyGridMap;
        private CellFactory CellFactory;
        private MapFactory MapFactory;
        private MapCreator MapCreator;
        private Screen MapScreen;

        public GridMap GridMap => MyGridMap;

        public MapBuilder(Size mapSize,Screen mapScreen)
        {
            MapSize = mapSize;
            MapScreen = mapScreen;
            CellFactory = new CellFactory();
            MapFactory = new MapFactory();
            MyGridMap = new GridMap(MapSize,CellSize);
            RoomBuilder = new RoomBuilder(MyGridMap.Size, MyGridMap);
            MazeBuilder = new MazeBuilder(MyGridMap);
            ConnectorBuilder = new ConnectorBuilder(MyGridMap, MyGridMap.Size);
            DeadEndRemover = new DeadEndRemover(MyGridMap);
        }
 
        public void Build(BuilderCallback builderCallback)
        {
            RoomBuilder.Build(builderCallback);
            MazeBuilder.Build(builderCallback);
            ConnectorBuilder.Build(builderCallback);
            DeadEndRemover.Start();

            DoneBuildindMap = true;
            builderCallback(MyGridMap.ObjectsAsList);
        }

        public void CreateObjects()
        {
            foreach (var BuildObject in MyGridMap.ObjectsAsList)
            {
                MapCreator = new MapCreator(MapFactory, BuildObject, CellSize, CellFactory);
                Game1.AddObjectInNextCycle(MapCreator.CreateObject());
            }
        }
    }
}