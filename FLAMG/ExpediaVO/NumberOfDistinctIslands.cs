using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class NumberOfDistinctIslands
    {
        public int NumberDistinctIslands(int[][] grid)
        {
            int m = grid.Length;
            if(m == 0)
                return 0;
            int n = grid[0].Length;
            if (n == 0)
                return 0;

            var visited = new bool[m, n];
            var count = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(grid[i][j] == 1 && !visited[i, j])
                    {
                        count++;
                        BFS(grid, i, j, visited);
                    }
                }
            }
            return count;
        }
        public void BFS(int[][] grid, int x, int y, bool[,] visited)
        {

        }
    }
}
