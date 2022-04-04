using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class ConnectedBlocks
    {
        /**
         * 1. Number of Islands
         */
        public int NumIslands(bool[][] grid)
        {
            //corner case
            int row = grid.Length;
            if (row == 0)
                return 0;
            int col = grid[0].Length;
            if (col == 0)
                return 0;

            //
            int count = 0;
            var visited = new HashSet<int[]>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] && IsValid_Islands(i, j, grid, visited))
                    {
                        BFS_Island(i, j, grid, visited);
                        count++;
                    }
                }
            }

            return count;

        }
        public void BFS_Island(int start_x, int start_y, bool[][] grid, HashSet<int[]> visited)
        {            
            var DIRECTIONS = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { start_x, start_y });
            visited.Add(new int[] { start_x, start_y });
            while (queue.Count > 0)
            {
                var location = queue.Dequeue();
                foreach (var dir in DIRECTIONS)
                {
                    int new_x = location[0] + dir[0];
                    int new_y = location[1] + dir[1];
                    if(grid[new_x][new_y] && IsValid_Islands(new_x, new_y, grid, visited))
                    {
                        queue.Enqueue(new int[] { new_x, new_y });
                        visited.Add(new int[] { new_x, new_y });                       
                    }
                }
            }
        }

        public bool IsValid_Islands(int x, int y, bool[][] grid, HashSet<int[]> visited)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length)
                return false;

            if (!grid[x][y])
                return false;

            if (visited.Contains(new int[] { x, y }))
                return false;

            return true;
        }
        /**
         * 2. Number of Big Islands
         */
        public int NumsOfBigIslands(bool[][] grid, int k)
        {
            //corner case
            int row = grid.Length;
            if (row == 0)
                return 0;
            int col = grid[0].Length;
            if (col == 0)
                return 0;

            var visited = new HashSet<int[]>();
            int islandNum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if(grid[i][j] && IsValid_BigIslands(i, j, grid, visited))
                    {
                        int size = BFS_BigIslands(i, j, grid, visited);
                        if (size >= k)
                            islandNum++;
                    }
                }
            }
            return islandNum;
        }
        public int BFS_BigIslands(int start_x, int start_y, bool[][] grid, HashSet<int[]> visited)
        {
            var DIRECTIONS = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            var queue = new Queue<int[]>();
            visited.Add(new int[] { start_x, start_x });
            int size = 1;
            while(queue.Count > 0)
            {
                var location = queue.Dequeue();
                visited.Add(location);
                
                foreach (var dir in DIRECTIONS)
                {
                    var new_x = location[0] + dir[0];
                    var new_y = location[1] + dir[1];
                    if(IsValid_BigIslands(new_x, new_y, grid, visited))
                    {
                        queue.Enqueue(new int[]{new_x, new_y});
                        visited.Add(new int[] { new_x, new_y });
                        size++;
                    }
                }
            }
            return size;
        }
        public bool IsValid_BigIslands(int x, int y, bool[][] grid, HashSet<int[]> visited)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length)
                return false;

            if (!grid[x][y])
                return false;

            if (visited.Contains(new int[] { x, y }))
                return false;

            return true;
        }









    }
}
