using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No200_NumberOfIsland
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// T: O(MN)
        /// S: O(MN)
        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            if (m == 0)
                return 0;
            int n = grid[0].Length;
            if (n == 0)
                return 0;
            var visited = new int[m, n];
            int count = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(grid[i][j] == '1' && visited[i,j] == 0)
                    {
                        count++;
                        BFS(grid, i, j, visited);
                    }
                }
            }
            return count;
        }

        public void BFS(char[][] grid, int x, int y, int[,] visited)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });
            visited[x, y] = 1;
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
                        if(grid[newx][newy] == '1' && visited[newx, newy] == 0)
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited[newx, newy] = 1;
                        }
                    }
                }
            }
        }
    }
}
