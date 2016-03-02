using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public GridMap GridMap => MyGridMap;

        public MapBuilder(Size mapSize)
        {
            CellFactory = new CellFactory();
            MapFactory = new MapFactory();
            MapSize = mapSize;
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