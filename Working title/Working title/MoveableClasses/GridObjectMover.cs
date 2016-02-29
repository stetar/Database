using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.MoveableClasses
{
    public class GridObjectMover
    {
        private GameObject ObjectToMove;
        private GridMap GridMap;

        public GridObjectMover(GridMap gridMap)
        {
            GridMap = gridMap;
        }


        public GridObjectMover(GridMap gridMap,GameObject objectToMove)
        {
            GridMap = gridMap;
            ObjectToMove = objectToMove;
        }

        public void SetObjectToMove(GameObject gameObject)
        {
            ObjectToMove = gameObject;
        }

        public void Move(Vector2 direction)
        {
            Vector2 GridPositionBeforeMoved = GridMap.ConvertWorldPositionToGridPosition(ObjectToMove.Position);
            Vector2 GridPositionAfterMoved = GridPositionBeforeMoved + direction;
            Cell CellBeforeMoved = GridMap[GridPositionBeforeMoved] as Cell;
            if (HasCellDirection(CellBeforeMoved,direction) && GridMap.IsWalkable(GridPositionAfterMoved))
            {
                ObjectToMove.Position = GridMap.ConvertGridPositionToWorldPosition(GridPositionAfterMoved);
            }
        }

        private bool HasCellDirection(Cell cell,Vector2 direction)
        {
            return cell != null && cell.HasDirection(direction);
        }
    }
}