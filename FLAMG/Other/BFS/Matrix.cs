using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class Matrix
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            int row = mat.Length;
            if (row == 0)
                return mat;
            int col = mat[0].Length;
            if (col == 0)
                return mat;
            var result = new int[row][];
            for (int i = 0; i < row; i++)
            {
                result[i] = new int[col];
            }
            //var result = new int[row, col];
            var visited = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i][j] == 0)
                        result[i][j] = 0;
                    else
                    {
                        result[i][j] = BFS(mat, i, j, visited);
                    }
                }
            }
            return result;
        }
        public int BFS(int[][] mat, int x, int y, int[,] visited)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });
            visited[x, y] = 1;
            var distance = 0;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while (queue.Count > 0)
            {
                distance++;
                var length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var location = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        var new_x = location[0] + dir[0];
                        var new_y = location[1] + dir[1];
                        if (mat[new_x][new_y] == 0)
                            return distance;
                        else if (IsValid(mat, new_x, new_y, visited))
                        {
                            queue.Enqueue(new int[] { new_x, new_y });
                            visited[new_x, new_y] = 1;
                        }
                    }
                }
            }
            return distance;
        }
        public bool IsValid(int[][] mat, int x, int y, int[,] visited)
        {
            if (x < 0 || y < 0 || x >= mat.Length || y >= mat[x].Length)
                return false;
            if (visited[x, y] == 1)
                return false;
            if (mat[x][y] == 0)
                return false;
            return true;
        }
    }
}
