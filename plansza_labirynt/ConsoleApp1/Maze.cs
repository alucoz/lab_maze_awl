using System;

public class Maze
{
    private int[,] maze;
    private int rows;
    private int cols;

    public Maze(int rows, int cols, int pools)
    {
        this.rows = rows;
        this.cols = cols;
        maze = new int[rows, cols];
        GenerateMaze(pools);
    }

    private void GenerateMaze(int pools)
    {
        Random rand = new Random();
        for (int i = 0; i < pools; i++)
        {
            int x = rand.Next(0, rows);
            int y = rand.Next(0, cols);
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
                Console.Write(maze[i, j] == 1 ? "X " : ". ");
            }
            Console.WriteLine();
        }
    }
}