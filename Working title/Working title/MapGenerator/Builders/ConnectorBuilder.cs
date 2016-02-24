using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using The_RPG_thread_game.Utillity;

namespace Working_title.MapGenerator
{
    public class ConnectorBuilder : Builder
    {
        private GridMap GridMap;
        private Size GridSize;
        private List<BuildObject> Connectors = new List<BuildObject>();
        private List<Room> ConnectedRooms = new List<Room>(); 
        private Random Random;  
        

        private List<Vector2> Directions = new List<Vector2>()
        {
            new Vector2(1,0),
            new Vector2(-1,0),
            new Vector2(0,1),
            new Vector2(0,-1)
        };

        public ConnectorBuilder(GridMap gridMap, Size gridSize)
        {
            GridMap = gridMap;
            GridSize = gridSize;
            Random = new Random();
        }

        public List<BuildObject> Build()
        {
            for (int x = 0; x < GridSize.Width; x++)
            {
                for (int y = 0; y < GridSize.Height; y++)
                {
                    Room Room = GridMap[x, y] as Room;
                    if (Room != null)
                    {
                        BuildObject RandomConnectorInRoom = GetRandomConnectorInRoom(Room);
                        if (RandomConnectorInRoom != null && !ConnectedRooms.Contains(Room))
                        {
                            SetCellToPointToRoom(RandomConnectorInRoom);
                            Connectors.Add(RandomConnectorInRoom);
                            GridMap[x, y] = new Door(RandomConnectorInRoom.Position, new Size(1,1));
                            ConnectedRooms.Add(Room);
                        }
                    }
                }
            }

            return Connectors;
        }

        private void SetCellToPointToRoom(BuildObject connector)
        {
            List<BuildObject> BuildObjects = GetBuildObjectsSurroundingPoint(Directions, connector.Position);
            List<Cell> Cells = BuildObjects.FindAll(buildObject => buildObject is Cell).Cast<Cell>().ToList();
            int RandomNumber = Random.Next(0, Cells.Count);
            Cell RandomCell = Cells[RandomNumber];
            RandomCell.AddDirection(RandomCell.Position - connector.Position);
        }

        private BuildObject GetRandomConnectorInRoom(Room room)
        {
            List<BuildObject> ConnectorsInRoom = GetConnectersInRoom(room);
            if (ConnectorsInRoom.Count <= 0)
            {
                return null;
            }
            int RandomNumber = Random.Next(0, ConnectorsInRoom.Count);
            return ConnectorsInRoom[RandomNumber];
        }

        private List<BuildObject> GetConnectersInRoom(Room room)
        {
            return (from Position in room.Positions()
                    where IsConnectorPoint(Position)
                    select new BuildObject(Position, new Size(1, 1))).ToList();
        }

        private bool IsConnectorPoint(Vector2 position)
        {
            List<BuildObject> BuildObjects = GetBuildObjectsSurroundingPoint(Directions, position);
            int CellCount = BuildObjects.FindAll(buildObject => buildObject is Cell).Count;
            int RoomCount = BuildObjects.FindAll(buildObject => buildObject is Room).Count;

            if ((CellCount == 1 && RoomCount == 3) || (CellCount == 2 && RoomCount == 2))
            {
                return true;
            }
            return false;

        }

        private List<BuildObject> GetBuildObjectsSurroundingPoint(List<Vector2> directions,Vector2 point)
        {
            List<BuildObject> BuildObjects = new List<BuildObject>();

            foreach (var Direction in directions)
            {
                Vector2 NewPosition = point + Direction;
                if (GridMap.IsWithinBounds(NewPosition))
                {
                    BuildObjects.Add(GridMap[(int)NewPosition.X, (int)NewPosition.Y]);
                }
            }

            return BuildObjects;
        }

    }
}