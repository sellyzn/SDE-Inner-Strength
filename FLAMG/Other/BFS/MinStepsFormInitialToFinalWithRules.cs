using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class MinStepsFormInitialToFinalWithRules
    {
        public int Zombie(int[][] grid)
        {
            // corner case
            int row = grid.Length;
            if (row == 0)
                return 0;
            int col = grid[0].Length;
            if (col == 0)
                return 0;

            //1. Enqueue all zombies into queue
            var queue = new Queue<int[]>();
            var visited = new HashSet<int[]>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue(new int[] { i, j });
                        visited.Add(new int[] { i, j });
                    }
                }
            }
            //2. BFS
            int days = 0;
            var DIRECTIONS = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while(queue.Count > 0)
            {
                days++;
                for (int i = 0; i < queue.Count; i++)
                {
                    var location = queue.Dequeue();
                    var x = location[0];
                    var y = location[1];
                    foreach (var dir in DIRECTIONS)
                    {
                        var new_x = x + dir[0];
                        var new_y = y + dir[1];
                        if(IsValid(grid, new_x, new_y, visited))
                        {
                            queue.Enqueue(new int[] { new_x, new_y });
                            visited.Add(new int[] { new_x, new_y });
                        }
                    }
                }
            }
            //3. Traverse array, to check if there are uninfected people
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 0 && !visited.Contains(new int[] {i, j }))
                        return -1;
                }
            }
            return days;
        }
        public bool IsValid(int[][] grid, int x, int y, HashSet<int[]> visited)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length)
                return false;
            if (visited.Contains(new int[] { x, y }))
                return false;
            if (grid[x][y] != 0)
                return false;
            return true;
        }






    }
}
