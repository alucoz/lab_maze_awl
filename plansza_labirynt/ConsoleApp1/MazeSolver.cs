using System;
using System.Collections.Generic;

public class MazeSolver
{
    private int[,] maze;
    private bool[,] visited;
    private int rows;
    private int cols;
    private List<(int, int)> path;

    public MazeSolver(int[,] maze)
    {
        this.maze = maze;
        rows = maze.GetLength(0);
        cols = maze.GetLength(1);
        visited = new bool[rows, cols];
        path = new List<(int, int)>();
    }

    public bool Solve(int startX, int startY, int endX, int endY)
    {
        return DFS(startX, startY, endX, endY);
    }

    private bool DFS(int x, int y, int endX, int endY)
    {
        if (x < 0 || y < 0 || x >= rows || y >= cols || maze[x, y] == 1 || visited[x, y])
        {
            return false;
        }

        visited[x, y] = true;
        path.Add((x, y));

        if (x == endX && y == endY)
        {
            return true;
        }

        // Move in 4 possible directions: up, down, left, right
        if (DFS(x + 1, y, endX, endY) || DFS(x - 1, y, endX, endY) || DFS(x, y + 1, endX, endY) || DFS(x, y - 1, endX, endY))
        {
            return true;
        }

        path.Remove((x, y));
        return false;
    }

}