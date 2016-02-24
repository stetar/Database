using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Working_title.MapGenerator
{
    public class MapBuilder
    {
        private readonly Size CellSize = new Size(15, 15);

        private Size MapSize;

        private RoomBuilder RoomBuilder;
        private MazeBuilder MazeBuilder;
        private ConnectorBuilder ConnectorBuilder;
        private DeadEndRemover DeadEndRemover;
        private GridMap GridMap;
        private CellFactory CellFactory;
        private MapFactory MapFactory;
        private MapCreator MapCreator;
        private List<Room> RoomsAdded = new List<Room>(); 

        public MapBuilder(Size mapSize)
        {
            CellFactory = new CellFactory();
            MapFactory = new MapFactory();
            MapSize = mapSize;
            GridMap = new GridMap(MapSize / CellSize);
            RoomBuilder = new RoomBuilder(GridMap.Size, GridMap);
            MazeBuilder = new MazeBuilder(GridMap);
            ConnectorBuilder = new ConnectorBuilder(GridMap, GridMap.Size);
            DeadEndRemover = new DeadEndRemover(GridMap);
        }
 

        public void Build()
        {
            RoomBuilder.Build();
            MazeBuilder.Build();
            ConnectorBuilder.Build();
            DeadEndRemover.Start();

            foreach (var BuildObject in GridMap.ObjectsAsList)
            {
                MapCreator = new MapCreator(MapFactory, BuildObject, CellSize, CellFactory);
                Game1.AddObjectInNextCycle(MapCreator.CreateObject());
            }
                    
             
        }
    }
}