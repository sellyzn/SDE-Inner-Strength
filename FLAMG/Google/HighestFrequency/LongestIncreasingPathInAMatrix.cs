using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class LongestIncreasingPathInAMatrix
    {
        public int LongestIncreasingPath(int[][] matrix)
        {
            int row = matrix.Length;
            if (row == 0)
                return 0;
            int col = matrix[0].Length;
            if (col == 0)
                return 0;

            var maxLength = 0;
            var visited = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    maxLength = Math.Max(maxLength, BFS(matrix, i, j, visited));
                }
            }
            return maxLength;
        }
        // 求得以（x, y）为起点的最大递增路径长度
        public int BFS(int[][] matrix, int x, int y, int[,] visited)
        {
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            var length = 1;
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });
            while(queue.Count > 0)
            {
                var queueLength = queue.Count;
                for (int i = 0; i < queueLength; i++)
                {
                    foreach (var dir in directions)
                    {
                        var new_x = x + dir[0];
                        var new_y = y + dir[1];
                        if (new_x >= 0 && new_y >= 0 && new_x < matrix.Length && new_y < matrix[new_x].Length)
                        {
                            if (matrix[new_x][new_y] > matrix[x][y] && visited[new_x, new_y] == 0)
                            {                                
                                queue.Enqueue(new int[] { new_x, new_y });
                                visited[new_x, new_y] = 1;
                            }
                        }
                    }
                }                
                length++;
            }            
            return length;
        }
        public int DFS(int[][] matrix, int x, int y, int[,] memo)
        {
            if(memo[x,y] != 0)
                return memo[x,y];
            memo[x, y]++;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            foreach (var dir in directions)
            {
                var new_x = x + dir[0];
                var new_y = y + dir[1];
                if (new_x >= 0 && new_y >= 0 && new_x < matrix.Length && new_y < matrix[new_x].Length)
                {
                    if (matrix[new_x][new_y] > matrix[x][y])
                    {
                        memo[x, y] = Math.Max(memo[x, y], DFS(matrix, new_x, new_y, memo) + 1);
                    }
                }
            }
            return memo[x, y];
        }
    }
}
