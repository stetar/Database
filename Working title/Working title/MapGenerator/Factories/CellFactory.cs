using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Working_title.Cells;

namespace Working_title.MapGenerator
{
    public class CellFactory : Factory
    {
        private Vector2 LeftDirection = new Vector2(-1, 0);
        private Vector2 RightDirection = new Vector2(1, 0);
        private Vector2 UpDirection = new Vector2(0, -1);
        private Vector2 DownDirection = new Vector2(0, 1);

        private List<Vector2> RightRightDirections;
        private List<Vector2> LeftLeftDirections;
        private List<Vector2> UpUpDirections;
        private List<Vector2> DownDownDirections;
        private List<Vector2> UpRightDirections;
        private List<Vector2> UpLeftDirections;
        private List<Vector2> DownLeftDirections;
        private List<Vector2> DownRightDirections;
        private List<Vector2> RightUpDirections;
        private List<Vector2> LeftUpDirections;
        private List<Vector2> LeftDownDirections;
        private List<Vector2> RightDownDirections;

        public CellFactory()
        {
            RightRightDirections = new List<Vector2>()  { RightDirection, RightDirection};
            LeftLeftDirections = new List<Vector2>()    { LeftDirection, LeftDirection  };
            UpUpDirections = new List<Vector2>()        { UpDirection, UpDirection      };
            DownDownDirections = new List<Vector2>()    { DownDirection, DownDirection  };
            UpRightDirections = new List<Vector2>()     { UpDirection, RightDirection   };
            UpLeftDirections = new List<Vector2>()      { UpDirection, LeftDirection    };
            DownLeftDirections = new List<Vector2>()    { DownDirection, LeftDirection  };
            DownRightDirections = new List<Vector2>()   { DownDirection, RightDirection };
            RightUpDirections = new List<Vector2>()     { RightDirection, UpDirection   };
            LeftUpDirections = new List<Vector2>()      { LeftDirection, UpDirection    };
            LeftDownDirections = new List<Vector2>()    { LeftDirection, DownDirection  };
            RightDownDirections = new List<Vector2>()   { RightDirection, DownDirection };
    }

        public GameObject CreateObject(Creator creator)
        {
            CellCreator CellCreator = (CellCreator) creator;
            List<Vector2> CellDirections = CellCreator.Directions;

            if (IsDirectionsEqual(CellDirections, RightRightDirections) ||
                IsDirectionsEqual(CellDirections, LeftLeftDirections) ||
                IsMoving(CellDirections, LeftDirection) ||
                IsMoving(CellDirections, RightDirection))
            {
                return new RightRightCell(CellCreator.StartPosition,CellCreator.Size);
            }
            if (IsDirectionsEqual(CellDirections, UpUpDirections) || 
                IsDirectionsEqual(CellDirections, DownDownDirections) ||
                IsMoving(CellDirections,LeftDirection) || 
                IsMoving(CellDirections, RightDirection))
            {
                return new UpUpCell(CellCreator.StartPosition, CellCreator.Size);
            }
            if (IsDirectionsEqual(CellDirections, UpRightDirections) ||
                IsDirectionsEqual(CellDirections, LeftDownDirections))
            {
                return new UpRightCell(CellCreator.StartPosition, CellCreator.Size);
            }
            if (IsDirectionsEqual(CellDirections, UpLeftDirections) ||
                IsDirectionsEqual(CellDirections, RightDownDirections))
            {
                return new UpLeftCell(CellCreator.StartPosition, CellCreator.Size);
            }
            if (IsDirectionsEqual(CellDirections, DownLeftDirections) || 
                IsDirectionsEqual(CellDirections, RightUpDirections))
            {
                return new DownLeftCell(CellCreator.StartPosition, CellCreator.Size);
            }
            if (IsDirectionsEqual(CellDirections, DownRightDirections) ||
                IsDirectionsEqual(CellDirections, LeftUpDirections))
            {
                return new DownRightCell(CellCreator.StartPosition, CellCreator.Size);
            }

            return new EmptyCell();
        }

        private bool IsMoving(List<Vector2> directions,Vector2 directionToCheck)
        {
            return directions.Count == 1 && directions.Contains(directionToCheck);
        }

        private bool IsDirectionsEqual(List<Vector2> directions1, List<Vector2> directions2)
        {
            return directions1.SequenceEqual(directions2);
        }

        
    }
}