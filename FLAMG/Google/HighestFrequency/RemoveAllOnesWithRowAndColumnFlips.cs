using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class RemoveAllOnesWithRowAndColumnFlips
    {
        public bool RemoveOnes(int[][] grid)
        {
            if (grid == null || grid.Length <= 1)
                return true;
            for(int i = 1; i < grid.Length; i++)
            {
                // if the first index is identical to grid[0][0]
                if(grid[i][0] == grid[0][0])
                {
                    //then the rest must be all identical, if there's one not identical return false
                    for(int j = 1; j < grid[0].Length; j++)
                    {
                        if(grid[i][j] != grid[0][j])
                            return false;
                    }
                }
                // if the first index if complement to grid[0][0]
                else
                {
                    // then the rest must be all complement, if there's one identical then return false
                    for (int j = 1; j < grid[0].Length; j++)
                    {
                        if (grid[i][j] == grid[0][j])
                            return false;
                    }
                }
            }
            return true;
        }
        public int RemoveOnesII(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            var steps = 0;
            for(int c = 0; c < cols; c++)
            {
                if(grid[0][c] == 1)
                {
                    steps++;
                    // flips column c
                    for(int r = 0; r < rows; r++)
                    {
                        if (grid[r][c] == 1)
                            grid[r][c] = 0;
                        else
                            grid[r][c] = 1;
                    }

                }
            }
            for(int r = 0; r < rows; r++)
            {
                if (grid[r][0] == 1)
                    steps++;
            }
            return steps;
        }
    }
}
