using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Working_title.Cells;
using Working_title.MapGenerator;

namespace Working_title
{
    public class RoomSprite : SpawedCell
    {
        private List<Vector2> RoomPositions = new List<Vector2>(); 

        public RoomSprite(Vector2 position,Size size) :
            base(position, size , "Floor")
        {
            ProcentChanceToSpawnEnemy = 30;
            RoomPositions = GridMap.ConvertWorldSizeToGridSize(size).Positions(GridMap.ConvertWorldPositionToGridPosition(Position));
            foreach (var RoomPosition in RoomPositions)
            {
                Vector2 RandomGridPosition = GetRandomPositionInRoom(RoomPositions);
                EnemySpawnPosition = GridMap.ConvertGridPositionToWorldPosition(RandomGridPosition);
                EnemySpawnSize = GridMap.CellSize;
                ShouldSpawnEnemy();
            } 
        }

        private Vector2 GetRandomPositionInRoom(List<Vector2> roomPositions)
        {
            return roomPositions[new Random().Next(0, roomPositions.Count)];
        }


    }
}