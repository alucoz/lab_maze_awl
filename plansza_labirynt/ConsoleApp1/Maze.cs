using System;

public class Maze
{
    private int[,] maze;
    private int rows;
    private int cols;

    public Maze(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        maze = new int[rows, cols];
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        Random rand = new Random();
        int minObstacles = (rows * cols) / 4;
        int maxObstacles = (rows * cols) / 2;
        int pools = rand.Next(minObstacles, maxObstacles + 1);

        for (int i = 0; i < pools; i++)
        {
            int x, y;
            do
            {
                x = rand.Next(0, rows);
                y = rand.Next(0, cols);
            }
            while ((x == 0 && y == 0) || (x == rows - 1 && y == cols - 1) || maze[x, y] == 1);

            maze[x, y] = 1; // 1 represents a pool (obstacle)
        }
    }

    public int[,] GetMaze()
    {
        return maze;
    }

    public void PrintMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == 0 && j == 0)
                {
                    Console.Write("S "); // Start
                }
                else if (i == rows - 1 && j == cols - 1)
                {
                    Console.Write("E "); // End
                }
                else
                {
                    Console.Write(maze[i, j] == 1 ? "X " : ". ");
                }
            }
            Console.WriteLine();
        }
    }
}