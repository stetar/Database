using System;
using Working_title.Enemies;
using Working_title.MapGenerator;

namespace Working_title.Cells.Factory
{
    public class EnemyFactory : MapGenerator.Factory
    {
        public GameObject CreateObject(Creator creator)
        {
            EnemyCreator EnemyCreator = (EnemyCreator) creator;

            return new StandardEnemy(EnemyCreator.StartPosition, EnemyCreator.Tier, EnemyCreator.Size);
        }
    }
}