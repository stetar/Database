using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Microsoft.Xna.Framework;
using The_RPG_thread_game.Utillity;

namespace Working_title.MapGenerator
{
    public class MazeBuilder : Builder
    {
        private readonly Size CellSize;
        
        private List<Cell> Maze = new List<Cell>();
        private List<Cell> SearchMazeList = new List<Cell>();
        private GridMap GridMap;
        private Random Random;

        private List<Vector2> Directions = new List<Vector2>()
        {
            new Vector2(1,0),
            new Vector2(-1,0),
            new Vector2(0,1),
            new Vector2(0,-1)
        };

        public MazeBuilder(GridMap gridMap)
        {
            GridMap = gridMap;
            Random = new Random();
        }

        public List<BuildObject> Build()
        {
            AddCell(GetRandomCell());

            while(SearchMazeList.Count > 0)
            {
                Cell CurrentCell = GetNewestCell();

                Cell RandomNeighborCell = GetRandomNeighborCell(CurrentCell);
                RandomNeighborCell.ParentCell = CurrentCell;

                if (Math.Abs(Vector2.Distance(RandomNeighborCell.Position, CurrentCell.Position)) <= 1)
                {
                    CurrentCell.AddDirection(RandomNeighborCell.Position - CurrentCell.Position);
                }

                if (!RandomNeighborCell.IsEmpty)
                {
                    AddCell(RandomNeighborCell);
                }
                else
                {
                    RemoveCell(CurrentCell);
                }
            }

            return Maze.Cast<BuildObject>().ToList();
        }

        private void AddCell(Cell cell)
        {
            SearchMazeList.Add(cell);
            Maze.Add(cell);
        }

        private void RemoveCell(Cell cell)
        {
            SearchMazeList.Remove(cell);
        }

        private Cell GetRandomCell()
        {
            Vector2 RandomPosition = Size.GetRandomSize(new Size(0, 0),GridMap.Size).ToVector2();

            return new Cell(RandomPosition, new Size(1, 1));
        }

        private Cell GetNewestCell()
        {
            return SearchMazeList[SearchMazeList.Count - 1];
        }

        private Cell GetRandomNeighborCell(Cell cell)
        {
            List<Vector2> DirectionsTaken = new List<Vector2>();
            Vector2 CurrentDirection = Vector2.Zero;

            while (Math.Abs(CurrentDirection.X - 9999) > 0.1f && Math.Abs(CurrentDirection.Y - 9999) > 0.1f)
            {
                CurrentDirection = GetRandomDirectionNotTaken(DirectionsTaken);
                Vector2 NewCellPosition = cell.Position + CurrentDirection;
                if (GridMap.IsWithinBounds(NewCellPosition) && GridMap[NewCellPosition] is EmptyCell)
                {
                    Cell NewCell = new Cell(NewCellPosition, CurrentDirection, new Size(1,1));
                    GridMap[NewCellPosition] = NewCell;
                    return NewCell;
                }

                DirectionsTaken.Add(CurrentDirection);
            }

            return new Cell();
        }

        private Vector2 GetRandomDirectionNotTaken(List<Vector2> directionsTaken)
        {
            List<Vector2> DirectionsNotTaken = GetDirectionsNotTaken(Directions, directionsTaken);
            if (DirectionsNotTaken.Count > 0)
            {
                int RandomNumber = Random.Next(0, DirectionsNotTaken.Count);
                return DirectionsNotTaken[RandomNumber];
            }
            return new Vector2(9999,9999);
        }

        private List<Vector2> GetDirectionsNotTaken(List<Vector2> directions, List<Vector2> directionsTaken)
        {
            return directions.FindAll(direction => !directionsTaken.Contains(direction));
        }

        private void ConvertMazeToWorldPosition(Size converterSize)
        {
            Maze.DoActionOnItems(cell => cell.ConvertToWorldKooridinates(converterSize));
        }

      




    }
}