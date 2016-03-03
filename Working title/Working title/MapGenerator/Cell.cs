using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{

    public class Cell : BuildObject
    {
        public bool IsEmpty;
        public bool IsRoomExit;

        public Cell ParentCell;

        private List<Vector2> MyDirections = new List<Vector2>();

        public List<Vector2> Directions => MyDirections;


        public Cell() : 
            base(Vector2.Zero, new Size(0,0))
        {
            IsEmpty = true;
        }
            
        public Cell(Vector2 position,Size size) :
            base(position, size)
        {
            Position = position;
        }

        public Cell(Vector2 position,Vector2 directionCommingFrom,Size size) :
            base(position, size)
        {
            Position = position;
            MyDirections.Add(directionCommingFrom);
        }

        public void AddDirection(Vector2 direction)
        {
            MyDirections.Add(direction);
        }

        public void RemovePasssageTo(Cell cell)
        {
            Vector2 DirectionToRemove = cell.Position - Position;
            MyDirections.Remove(DirectionToRemove);
        }

        public override bool IsWalkable()
        {
            return true;
        }

        public bool HasDirection(Vector2 direction)
        {
            return Directions.Contains(direction);
        }
    }
}