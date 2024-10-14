using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75
{
    internal class FindTheShortestCellPath
    {
        /*
        BFS 
        */
        public int ShortestCellPath(int[][] grid, int sr, int sc, int tr, int tc)
        {
            var row = grid.Length;
            var col = grid[0].Length;
            var queue = new Queue<int[]>();
            var visited = new bool[row,col];
            queue.Enqueue(new int[] { sr, sc });
            visited[sr,sc] = true;
            var minDistance = 0;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while(queue.Count > 0)
            {
                var count = queue.Count;
                for(int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur[0] == sr && cur[1] == sc)
                    {
                        return minDistance;
                    }
                    foreach(var dir in directions)
                    {
                        var newX = cur[0] + dir[0];
                        var newY = cur[1] + dir[1];
                        if (!visited[newX, newY] && grid[newX][newY] == 1)
                        {
                            queue.Enqueue(new int[] { newX, newY });
                            visited[newX, newY] = true;
                        }
                    }
                }
                minDistance++;
            }
            return -1;
        }
    }
}
