using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using The_RPG_thread_game.Utillity;

namespace Working_title.MapGenerator
{
    public class RoomBuilder : Builder
    {
        private const int NumberOfRoomTries = 500000;

        private readonly Size SizeAroundRooms = new Size(1,1);
        private readonly Size RoomMaxSize = new Size(5,5);
        private readonly Size RoomMinSize = new Size(2, 2);
        private readonly Limit RoomLimit = new Limit(40,25);
        

        private List<Room> Rooms = new List<Room>();
        private Size GridMapSize;
        private GridMap GridMap;
        private Random Random;
         

        public RoomBuilder(Size gridMapSize, GridMap gridMap)
        {
            GridMapSize = gridMapSize;
            GridMap = gridMap;
            Random = new Random();
        }

        public void Build(BuilderCallback builderCallback)
        {
            int RoomsToBuild = RoomLimit.RandomIntWithinLimit();

            for (int i = 0; i < NumberOfRoomTries; i++)
            {
                Size RandomSize = Size.GetRandomSize(RoomMinSize, RoomMaxSize, Random);
                Vector2 RandomPosition = Size.GetRandomSize(new Size(0, 0), GridMapSize, Random).ToVector2();
                Rectangle RoomCollisionBox = new Rectangle(RandomPosition.ToPoint(), RandomSize.ToPoint());
                Room NewRoom = new Room(RandomPosition, RandomSize, RoomCollisionBox);

                Rectangle RoomCollisionBoxClone = new Rectangle(RandomPosition.ToPoint(), RandomSize.ToPoint());
                RoomCollisionBoxClone.Inflate(SizeAroundRooms.Width, SizeAroundRooms.Height);

                if (!Rooms.Exists(room => room.CollisionBox.Intersects(RoomCollisionBoxClone)) && IsWithinBounds(NewRoom))
                {
                    AddRoom(NewRoom);
                }
                if (Rooms.Count >= RoomsToBuild)
                {
                    break;
                }
            }

            builderCallback(Rooms.Cast<BuildObject>().ToList());
        }

        private void AddRoom(Room room)
        {
            Rooms.Add(room);
            foreach (var RoomPosition in room.Positions())
            {
                GridMap[RoomPosition] = room;
            }
        }

        private bool IsWithinBounds(Room room)
        {
            return room.Positions().All(IsWithinBounds);
        }

      

        private bool IsWithinBounds(Vector2 position)
        {
            return GridMapSize.Width > position.X && GridMapSize.Height > position.Y &&
            position.X > 0 && position.Y > 0;
        }


 

       

        
    }
}