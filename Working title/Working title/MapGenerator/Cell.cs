using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{

    public class Cell : BuildObject
    {
        public bool IsEmpty;
        public bool IsRoomExit;
        public List<Vector2> Directions = new List<Vector2>();
        public Cell ParentCell;
        

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
            Directions.Add(directionCommingFrom);
        }

        public void AddDirection(Vector2 direction)
        {
            Directions.Add(direction);
        }

        public void RemovePasssageTo(Cell cell)
        {
            Vector2 DirectionToRemove = cell.Position - Position;
            Directions.Remove(DirectionToRemove);
        }

        public bool HasDirection(Vector2 direction)
        {
            return Directions.Contains(direction);
        }


       
    }
}