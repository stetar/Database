using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class GridMap
    {
        public Size Size;
        public List<Vector2> Directions = new List<Vector2>()
        {
            new Vector2(1,0),
            new Vector2(-1,0),
            new Vector2(0,1),
            new Vector2(0,-1)
        };

        private BuildObject[,] Map;
        private List<BuildObject> MyObjectsAsList = new List<BuildObject>();
        private Size CellSize;

        public List<BuildObject> ObjectsAsList
        {
            get
            {
                MyObjectsAsList.Clear();
                for (int x = 0; x < Size.Width; x++)
                {
                    for (int y = 0; y < Size.Height; y++)
                    {
                        BuildObject BuildObject = Map[x, y];
                        MyObjectsAsList.Add(BuildObject);
                    }
                }
                return MyObjectsAsList;
            }
        } 

        public GridMap(Size gridMapSize,Size cellsize)
        {
            Size = gridMapSize;
            Map = new BuildObject[gridMapSize.Width, gridMapSize.Height];
            CellSize = cellsize;
            AddCells();
        }

        private void AddCells()
        {
            for (int x = 0; x < (Map.GetLength(0)); x++)
            {
                for (int y = 0; y < (Map.GetLength(1)); y++)
                {
                    Map[x, y] = new Empty(new Vector2(x,y), new Size(1,1));
                }
            }
        }

        public bool IsWithinBounds(Vector2 position)
        {
            return Size.Width > position.X && Size.Height > position.Y &&
                position.X >= 0 && position.Y >= 0;
        }

        public Vector2 ConvertWorldPositionToGridPosition(Vector2 worldPosition)
        {
            return worldPosition / CellSize.ToVector2();
        }

        public Vector2 ConvertGridPositionToWorldPosition(Vector2 gridPosition)
        {
            return gridPosition * CellSize.ToVector2();
        }


        public Cell GetRandomCell()
        {
            List<Cell> CellsInMap = ObjectsAsList.FindAll(objectInMap => objectInMap is Cell &&
            !(objectInMap as Cell).IsRoomExit).Cast<Cell>().ToList();

            Cell RandomCell = CellsInMap[new Random().Next(0, CellsInMap.Count)];

            return RandomCell;
        }

        public bool IsWalkable(Vector2 position)
        {
            if (IsWithinBounds(position))
            {
                BuildObject BuildObject = this[position];
                return BuildObject is Cell;
            }

            return false;
        }

        public BuildObject this[Vector2 position]
        {
            get
            {
                if (IsWithinBounds(position))
                {
                    return Map[(int)position.X, (int)position.Y];
                }

                return new Wall(new Vector2(0,0), new Size(0,0));
                
            }
            set
            {
                if (IsWithinBounds(position))
                {
                    Map[(int) position.X, (int) position.Y] = value;
                }
            }
        }


    }
}