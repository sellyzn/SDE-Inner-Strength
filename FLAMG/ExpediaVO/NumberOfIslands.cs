using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class NumberOfIslands
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// T: O(M*N)
        /// S: O(M*N)
        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            if (m == 0)
                return 0;
            int n = grid[0].Length;
            if (n == 0)
                return 0;

            var visited = new bool[m, n];
            var count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        count++;
                        BFS(grid, i, j, visited);
                    }
                }
            }
            return count;
        }
        public void BFS(char[][] grid, int x, int y, bool[,] visited)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });
            visited[x, y] = true;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                foreach (var dir in directions)
                {
                    var newx = cur[0] + dir[0];
                    var newy = cur[1] + dir[1];
                    if(newx >= 0 && newy >= 0 && newx < grid.Length && newy < grid[0].Length)
                    {
                        if(grid[newx][newy] == '1' && !visited[newx, newy])
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited[newx, newy] = true;
                        }
                    }
                }
            }
        }
    }
}
