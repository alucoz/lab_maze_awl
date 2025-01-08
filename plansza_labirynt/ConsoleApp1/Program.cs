using System;

class Program
{
    static void Main(string[] args) //wywołanie wszystkiego
    {
        Maze maze = new Maze();
        Console.WriteLine("Generated Maze:");
        maze.PrintMaze();

        int rows = maze.GetRows();
        int cols = maze.GetCols();

        MazeSolver solver = new MazeSolver(maze.GetMaze());

        if (solver.Solve(0, 0, rows - 1, cols - 1))
        {
            Console.WriteLine("Path found");
           
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }
}