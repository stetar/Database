using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class CellCreator : Creator
    {
        public List<Vector2> Directions;
        public Size Size;

        public CellCreator(Factory factory, Vector2 startPosition,List<Vector2> directions,Size size ) :
            base(factory, startPosition)
        {
            Directions = directions;
            Size = size;
        }
    }
}