using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Working_title.MapGenerator
{
    public class Room : BuildObject
    {
        public bool EnteredRoom;
        public Rectangle CollisionBox;

        public Room(Vector2 position,Size size, Rectangle collisionBox) :
            base(position,size)
        {
            CollisionBox = collisionBox;
        }

        public List<Vector2> Positions()
        {
            List<Vector2> RoomPositions = new List<Vector2>();

            Vector2 RoomPosition = Position;

            for (int Width = 0; Width < Size.Width; Width++)
            {
                for (int Height = 0; Height < Size.Height; Height++)
                {
                    RoomPositions.Add(new Vector2((int)RoomPosition.X + Width, (int)RoomPosition.Y + Height));
                }
            }

            return RoomPositions;
        }

        public override bool IsWalkable()
        {
            return EnteredRoom;
        }
    }
}