using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Pramp
{
    internal class ShortestCellPath
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>  int array
        /// <param name="sr"></param> starting row
        /// <param name="sc"></param> starting column
        /// <param name="tr"></param> target row
        /// <param name="tc"></param> target column
        /// <returns></returns>
        /// T: O(M * N)
        /// S: O(M * N)
        public int ShortestCellPathSolution(int[][] grid, int sr, int sc, int tr, int tc)
        {
            var row = grid.Length;
            var col = grid[0].Length;
            var queue = new Queue<int[]>();
            var visited = new bool[row, col];
            queue.Enqueue(new int[] {sr, sc});
            visited[sr, sc] = true;
            var minDistance = 0;
            var directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            while (queue.Count > 0)
            {
                var currentLength = queue.Count;                
                for(int i = 0; i < currentLength; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur[0] == tr && cur[1] == tc)
                        return minDistance;
                    foreach (var dir in directions)
                    {
                        var newX = cur[0] + dir[0];
                        var newY = cur[1] + dir[1];
                        if(newX >= 0 && newY >= 0 && newX < row && newY < col)
                        {
                            if(grid[newX][newY] == 1 && !visited[newX, newY])
                            {
                                queue.Enqueue(new int[] { newX, newY });
                                visited[newX, newY] = true;
                            }
                        }
                    }
                }
                minDistance++;
            }
            return -1;
        }
    }
}
