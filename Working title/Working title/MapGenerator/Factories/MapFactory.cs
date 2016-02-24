namespace Working_title.MapGenerator
{
    public class MapFactory : Factory
    {
        public GameObject CreateObject(Creator creator)
        {
            MapCreator MapCreator = (MapCreator) creator;
            BuildObject BuildObject = MapCreator.BuildObject;

            if (BuildObject != null)
            {
                BuildObject.ConvertToWorldKooridinates(MapCreator.ConverterSize);
                BuildObject.ConvertToWorldSize(MapCreator.ConverterSize);

                if (BuildObject is EmptyCell)
                {
                    return new WallSprite(BuildObject.Position,BuildObject.Size);
                }

                if (BuildObject is Room)
                {
                     return new RoomSprite(BuildObject.Position, BuildObject.Size);
                }

                if (BuildObject is Cell)
                {
                    Cell Cell = BuildObject as Cell;
                    CellCreator CellCreator = new CellCreator(MapCreator.CellFactory, Cell.Position, Cell.Directions, Cell.Size);
                    return CellCreator.CreateObject();
                }

                if (BuildObject is Door)
                {
                    return new DoorSprite(BuildObject.Position, BuildObject.Size);
                }
            }

            return new EmptyGameObject();
        }
    }
}