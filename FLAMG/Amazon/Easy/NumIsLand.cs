using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    class NumIsLand
    {
        //DFS
        public int NumIsLands_DFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;
            for(int r = 0; r < nr; r++)
            {
                for(int c = 0; c < nc; c++)
                {
                    if (grid[r][c] == '1')
                        num_islands++;
                    DFS(grid, r, c);
                }
            }
            return num_islands;
        }
        public void DFS(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
                return;
            grid[r][c] = '0';
            DFS(grid, r - 1, c);
            DFS(grid, r + 1, c);
            DFS(grid, r, c - 1);
            DFS(grid, r, c + 1);
        }


















        //695. Max Area of Island
        //int num;
        public int MaxAreaOfIsland(int[][] grid)
        {
            //num = 1;
            int res = 0;
            if (grid == null || grid.Length == 0)
                return res;
            int nr = grid.Length;
            int nc = grid[0].Length;
            for(int r = 0; r < nr; r++)
            {
                for(int c = 0; c < nc; c++)
                {
                    if (grid[r][c] == 1)
                        res = Math.Max(res, DFS_MaxArea(grid, r, c));
                }
            }
            return res;
        }
        public int DFS_MaxArea(int[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;
            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == 0)
                return 0;

            grid[r][c] = 0;
            int num = 1;
            num += DFS_MaxArea(grid, r - 1, c);
            num += DFS_MaxArea(grid, r + 1, c);
            num += DFS_MaxArea(grid, r, c - 1);
            num += DFS_MaxArea(grid, r, c + 1);
            return num;
        }




        // Island Perimeter
        public int IslandPerimeter(int[][] grid)
        {

        }


    }
}
