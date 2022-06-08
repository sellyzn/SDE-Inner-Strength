using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class VisitInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visit { get; set; }
        public VisitInfo(int x, int y, bool visit)
        {
            this.X = x;
            this.Y = y;
            this.Visit = visit;            
        }
    }
    internal class No1197_MinimumKnightMoves
    {
        // Runtime Error:
        public int MinKnightMoves(int x, int y)
        {
            if (x == 0 && y == 0)
                return 0;
            var queue = new Queue<int[]>();
            var visited = new HashSet<VisitInfo>();
            visited.Add(new VisitInfo(0, 0, true));
            queue.Enqueue(new int[] { 0, 0});
            var directions = new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 1, -2 }, new int[] { 2, -1 }, new int[] { -1, 2 }, new int[] { -2, 1 }, new int[] { -1, -2 }, new int[] { -2, -1 } };
            var steps = 0;
            while (queue.Count > 0)
            {
                steps++;
                int length = queue.Count;
                for(int i = 0; i < length; i++)
                {
                    var location = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        var newx = location[0] + dir[0];
                        var newy = location[1] + dir[1];
                        if (newx == x && newy == y)
                            return steps;
                        var vi = new VisitInfo(newx, newy, true);
                        if (!visited.Contains(vi))
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited.Add(vi);
                        }
                    }
                }
            }
            return steps;
        }

        // Time Limit Exceeded: 
        public int MinKnightMoves1(int x, int y)
        {
            if (x == 0 && y == 0)
                return 0;
            var queue = new Queue<int[]>();
            var visited = new HashSet<string>();
            visited.Add("0,0");           
            queue.Enqueue(new int[] { 0, 0 });
            var directions = new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 1, -2 }, new int[] { 2, -1 }, new int[] { -1, 2 }, new int[] { -2, 1 }, new int[] { -1, -2 }, new int[] { -2, -1 } };
            var steps = 0;
            while (queue.Count > 0)
            {
                steps++;
                int length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var location = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        var newx = location[0] + dir[0];
                        var newy = location[1] + dir[1];
                        if (newx == x && newy == y)
                            return steps;                        
                        if (!visited.Contains(newx + "," + newy))
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited.Add(newx + "," + newy);
                        }
                    }
                }
            }
            return -1;
        }

        // Accepted
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// T: O((max(|x|,|y|))^2), the area can be approximated by the area of a square with an edge length of max(2|x|, 2|y|), the number of cells within this square would be (max(2|x|, 2|y|))^2.
        ///      |x| * |y|   ???
        /// S: O((max(|x|,|y|))^2)
        public int MinKnightMoves_Pass(int x, int y)
        {
            if (x == 0 && y == 0)
                return 0;
            var queue = new Queue<int[]>();
            var visited = new bool[608, 608];
            visited[0, 0] = true;
            queue.Enqueue(new int[] { 0, 0 });
            var directions = new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 1, -2 }, new int[] { 2, -1 }, new int[] { -1, 2 }, new int[] { -2, 1 }, new int[] { -1, -2 }, new int[] { -2, -1 } };
            var steps = 0;
            while (queue.Count > 0)
            {
                int length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var curr = queue.Dequeue();
                    if (curr[0] == x && curr[1] == y)
                        return steps;
                    foreach (var dir in directions)
                    {
                        var newx = curr[0] + dir[0];
                        var newy = curr[1] + dir[1];

                        if (!visited[newx + 302, newy + 302])
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited[newx + 302, newy + 302] = true;
                        }
                    }
                }
                steps++;
            }
            return steps;
        }

    }
}
