namespace Working_title.MapGenerator
{
    public class DeadEndRemover
    {
        private const int NumberOfDeadEndsToRemove = 500;

        private BuildObject[,] GridMap;

        public DeadEndRemover(BuildObject[,] gridMap)
        {
            GridMap = gridMap;
        }

        public void Start()
        {
            
        }
    }
}