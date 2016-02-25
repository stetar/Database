using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class GridMap
    {
        public Size Size;

        private BuildObject[,] Map;
        private List<BuildObject> MyObjectsAsList = new List<BuildObject>();

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

        public GridMap(Size gridMapSize)
        {
            Size = gridMapSize;
            Map = new BuildObject[gridMapSize.Width, gridMapSize.Height];
            AddCells();
        }

        private void AddCells()
        {
            for (int x = 0; x < (Map.GetLength(0)); x++)
            {
                for (int y = 0; y < (Map.GetLength(1)); y++)
                {
                    Map[x, y] = new EmptyCell(new Vector2(x,y), new Size(1,1));
                }
            }
        }

        public bool IsWithinBounds(Vector2 position)
        {
            return Size.Width > position.X && Size.Height > position.Y &&
                position.X >= 0 && position.Y >= 0;
        }

        public BuildObject this[Vector2 position]
        {
            get
            {
                return Map[(int)position.X, (int)position.Y];
            }
            set
            {
                Map[(int)position.X, (int)position.Y] = value;
            }
        }


    }
}