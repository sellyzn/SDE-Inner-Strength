using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1197_MinimumKnightMoves
    {/// <summary>
    /// BFS
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// T: O()
    /// S: O()
        public int MinKnightMoves(int x, int y)
        {
            if(x == 0 && y == 0)
                return 0;
            var directions = new int[][] { new int[] { 2, 1 }, new int[] { 1, 2 }, new int[] { -1, 2 }, new int[] { -2, 1 }, new int[] { -2, -1 }, new int[] { -2, -2 }, new int[] { 1, -2 }, new int[] { 2, -1 } };
            var queue = new Queue<int[]>();
            var visited = new bool[605, 605];
            queue.Enqueue(new int[] { 0, 0 });
            visited[0, 0] = true;
            var step = 0;
            while(queue.Count > 0)
            {
                var length = queue.Count;
                for(int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    if(node[0] == x && node[1] == y)
                        return step;
                    foreach (var dir in directions)
                    {
                        var newx = node[0] + dir[0];
                        var newy = node[1] + dir[1];
                        if(!visited[newx, newy])
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited[newx, newy] = true;
                        }
                    }
                }
                step++;
            }
            return steps;
        }
    }
}
