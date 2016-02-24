using System.Collections.Generic;

namespace Working_title.MapGenerator
{
    public class GridMap
    {
        public Size Size;

        private BuildObject[,] Map;
        private List<BuildObject> ObjectsInMap = new List<BuildObject>();

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
                    Map[x, y] = null;
                }
            }
        }

        public BuildObject this[int index,int index2]
        {
            get
            {
                return Map[index,index2];
            }
            set
            {
                Map[index, index2] = value;
            }
        }


    }
}