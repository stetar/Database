using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class BuildObject
    {
        public Vector2 Position;
        public Size Size;

        public BuildObject(Vector2 position, Size size)
        {
            Position = position;
            Size = size;
        }

        public void ConvertToWorldKooridinates(Size conververSize)
        {
            Position =  new Vector2(Position.X * conververSize.Width, Position.Y * conververSize.Height);
        }
        public void ConvertToWorldSize(Size conververSize)
        {
            Size *= conververSize;
        }

        public virtual void Entered()
        {
            
        }

        public virtual  bool IsWalkable()
        {
            return false;
        }
    }
}