using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class MapCreator : Creator
    {
        public Size Size;
        public BuildObject BuildObject;
        public Size ConverterSize;
        public Factory CellFactory;

        public MapCreator(Factory factory, BuildObject buildObject,Size converterSize,Factory cellFactory) :
            base(factory, buildObject.Position)
        {
            Size = buildObject.Size;
            BuildObject = buildObject;
            ConverterSize = converterSize;
            CellFactory = cellFactory;
        }
    }
}