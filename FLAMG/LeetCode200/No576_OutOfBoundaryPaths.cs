using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No576_OutOfBoundaryPaths
    {
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            var queue = new Queue<int[]>();
            var visited = new bool[m, m];
            queue.Enqueue(new int[] { startRow, startColumn });
            visited[startRow, startColumn] = true;
            int nums = 0;

            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while (queue.Count > 0 && maxMove > 0)
            {
                var curLen = queue.Count;
                for (int i = 0; i < curLen; i++)
                {
                    var cur = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        var newRow = cur[0] + dir[0];
                        var newCol = cur[1] + dir[1];
                        if (newRow >= 0 && newCol >= 0 && newRow < m && newCol < n)
                        {
                            if (!visited[newRow, newCol])
                            {
                                queue.Enqueue(new int[] { newRow, newCol });
                                visited[newRow, newCol] = true;
                            }
                        }
                        else
                        {
                            if (nums >= Math.Pow(10, 9) + 7)
                            {
                                return (int)Math.Pow(10, 9) + 7;
                            }
                            else
                            {
                                nums++;
                            }
                        }
                    }
                }
                maxMove--;
            }
            return nums;
        }
    }
}
