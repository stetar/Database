using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class GridMap 
    {
        public Size Size;
        public static Size CellSize;

        public List<Vector2> Directions = new List<Vector2>()
        {
            new Vector2(1,0),
            new Vector2(-1,0),
            new Vector2(0,1),
            new Vector2(0,-1)
        };

        private BuildObject[,] Map;
        

        public List<BuildObject> ObjectsAsList
        {
            get
            {
                List<BuildObject> ObjectsInGridMap = new List<BuildObject>();
                for (int x = 0; x < Size.Width; x++)
                {
                    for (int y = 0; y < Size.Height; y++)
                    {
                        BuildObject BuildObject = Map[x, y];
                        if (!ObjectsInGridMap.Contains(BuildObject))
                        {
                            ObjectsInGridMap.Add(BuildObject);
                        }
                    }
                }
                return ObjectsInGridMap;
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

        public static Vector2 ConvertWorldPositionToGridPosition(Vector2 worldPosition)
        {
            return worldPosition / CellSize.ToVector2();
        }

        public static Vector2 ConvertGridPositionToWorldPosition(Vector2 gridPosition)
        {
            return gridPosition * CellSize.ToVector2();
        }

        public static Size ConvertWorldSizeToGridSize(Size size)
        {
            return size / CellSize;
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
                BuildObject.Entered();
                return BuildObject.IsWalkable();
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


        public object CleanClone()
        {
            return new GridMap(Size,CellSize);
        }
    }
}