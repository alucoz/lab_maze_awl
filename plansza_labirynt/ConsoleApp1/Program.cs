using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        Console.Write("Enter number of pools: ");
        int pools = int.Parse(Console.ReadLine());

        Maze maze = new Maze(rows, cols, pools);
        Console.WriteLine("Generated Maze:");
        maze.PrintMaze();

        MazeSolver solver = new MazeSolver(maze.GetMaze());

        Console.WriteLine("Enter start coordinates:");
        Console.Write("Start X: ");
        int startX = int.Parse(Console.ReadLine());
        Console.Write("Start Y: ");
        int startY = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter end coordinates:");
        Console.Write("End X: ");
        int endX = int.Parse(Console.ReadLine());
        Console.Write("End Y: ");
        int endY = int.Parse(Console.ReadLine());

        if (solver.Solve(startX, startY, endX, endY))
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