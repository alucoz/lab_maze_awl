using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        Maze maze = new Maze(rows, cols);
        Console.WriteLine("Generated Maze:");
        maze.PrintMaze();

        MazeSolver solver = new MazeSolver(maze.GetMaze());

        if (solver.Solve(0, 0, rows - 1, cols - 1))
        {
            Console.WriteLine("Path found:");
            solver.PrintPath();
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }
}