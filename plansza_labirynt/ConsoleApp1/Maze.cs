using System;
using System.Collections.Generic;

public class Maze
{
    private int[,] maze;
    private int rows;
    private int cols;
    private Random rand = new Random();

    public Maze()
    {
        rows = rand.Next(20, 101); // Random rows between 20 and 100
        cols = rand.Next(20, 101); // Random columns between 20 and 100
        maze = new int[rows, cols];
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        // Initialize the maze with walls
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                maze[i, j] = 1; // 1 represents a wall
            }
        }

        // Start the maze generation from the top-left corner
        CarvePath(0, 0);

        // Ensure the start and end points are open
        maze[0, 0] = 0; // Start
        maze[rows - 1, cols - 1] = 0; // End
    }

    private void CarvePath(int x, int y)
    {
        // Define the directions (up, right, down, left)
        var directions = new List<(int, int)> { (0, -1), (1, 0), (0, 1), (-1, 0) };
        Shuffle(directions);

        foreach (var (dx, dy) in directions)
        {
            int nx = x + dx * 2;
            int ny = y + dy * 2;

            if (InBounds(nx, ny) && maze[nx, ny] == 1)
            {
                maze[x + dx, y + dy] = 0; // Carve path between cells
                maze[nx, ny] = 0; // Carve path to new cell
                CarvePath(nx, ny);
            }
        }
    }

    private bool InBounds(int x, int y)
    {
        return x >= 0 && x < rows && y >= 0 && y < cols;
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public int[,] GetMaze()
    {
        return maze;
    }

    public int GetRows()
    {
        return rows;
    }

    public int GetCols()
    {
        return cols;
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