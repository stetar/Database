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

        private List<Vector2> LeftRightDirections;
        private List<Vector2> DownUpDirections;
        private List<Vector2> UpRightDirections;
        private List<Vector2> UpLeftDirections;
        private List<Vector2> DownLeftDirections;
        private List<Vector2> DownRightDirections;
        private List<Vector2> RightUpDirections;
        private List<Vector2> LeftUpDirections;
        private List<Vector2> LeftDownDirections;
        private List<Vector2> RightDownDirections;
        private List<Vector2> TCrossRightDirections;
        private List<Vector2> TCrossLeftDirections;
        private List<Vector2> TCrossUpDirections;
        private List<Vector2> TCrossDownDirections;

        public CellFactory()
        {
            LeftRightDirections = new List<Vector2>()   { RightDirection, LeftDirection };
            DownUpDirections = new List<Vector2>()      { UpDirection, DownDirection    };
            UpRightDirections = new List<Vector2>()     { UpDirection, RightDirection   };
            UpLeftDirections = new List<Vector2>()      { UpDirection, LeftDirection    };
            DownLeftDirections = new List<Vector2>()    { DownDirection, LeftDirection  };
            DownRightDirections = new List<Vector2>()   { DownDirection, RightDirection };
            RightUpDirections = new List<Vector2>()     { RightDirection, UpDirection   };
            LeftUpDirections = new List<Vector2>()      { LeftDirection, UpDirection    };
            LeftDownDirections = new List<Vector2>()    { LeftDirection, DownDirection  };
            RightDownDirections = new List<Vector2>()   { RightDirection, DownDirection };

            TCrossRightDirections = new List<Vector2>() { RightDirection, DownDirection, UpDirection    };
            TCrossLeftDirections = new List<Vector2>()  { LeftDirection, DownDirection, UpDirection     };
            TCrossUpDirections = new List<Vector2>()    { RightDirection, LeftDirection, UpDirection    };
            TCrossDownDirections = new List<Vector2>()  { RightDirection, LeftDirection, DownDirection  };
        }

        public GameObject CreateObject(Creator creator)
        {
            CellCreator CellCreator = (CellCreator) creator;
            List<Vector2> CellDirections = CellCreator.Directions;

            if (IsDirectionsEqual(CellDirections, LeftRightDirections) ||
                IsMovingInOneDirection(CellDirections, LeftDirection) ||
                IsMovingInOneDirection(CellDirections, RightDirection))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "RightRight");
            }

            if (IsDirectionsEqual(CellDirections, DownUpDirections) ||
                IsMovingInOneDirection(CellDirections,LeftDirection) || 
                IsMovingInOneDirection(CellDirections, RightDirection))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "UpUp");
            }

            if (IsDirectionsOrderEqual(CellDirections, UpLeftDirections) ||
                IsDirectionsOrderEqual(CellDirections, LeftUpDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "UpLeft");
            }

            if (IsDirectionsOrderEqual(CellDirections, UpRightDirections) ||
                IsDirectionsOrderEqual(CellDirections, RightUpDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "UpRight");
            }

            if (IsDirectionsOrderEqual(CellDirections, DownLeftDirections) || 
                IsDirectionsOrderEqual(CellDirections, LeftDownDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "DownLeft");
            }

            if (IsDirectionsOrderEqual(CellDirections, DownRightDirections) ||
                IsDirectionsOrderEqual(CellDirections, RightDownDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "DownRight");
            }

            if (IsDirectionsEqual(CellDirections, TCrossLeftDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "TCrossLeft");
            }

            if (IsDirectionsEqual(CellDirections, TCrossRightDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "TCrossRight");
            }

            if (IsDirectionsEqual(CellDirections, TCrossUpDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "TCrossUp");
            }

            if (IsDirectionsEqual(CellDirections, TCrossDownDirections))
            {
                return new SpawedCell(CellCreator.StartPosition, CellCreator.Size, "TCrossDown");
            }

            return new EmptyGameObject();
        }

        private bool IsMovingInOneDirection(List<Vector2> directions,Vector2 directionToCheck)
        {
            return directions.Count == 1 && directions.Contains(directionToCheck);
        }

        private bool IsDirectionsEqual(List<Vector2> directions1, List<Vector2> directions2)
        {
            return directions1.Except(directions2).ToList().Count <= 0;
        }

        private bool IsDirectionsOrderEqual(List<Vector2> directions1, List<Vector2> directions2)
        {
            return directions1.SequenceEqual(directions2);
        }

        
    }
}