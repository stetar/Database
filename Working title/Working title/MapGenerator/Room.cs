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
            return Size.Positions(Position);
        }

        public override bool IsWalkable()
        {
            return EnteredRoom;
        }
    }
}