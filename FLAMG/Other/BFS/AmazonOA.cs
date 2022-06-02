using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class AmazonOA
    {
        public int ShortestPath(List<List<int>> lot)
        {
            var row = lot.Count;
            var col = lot[0].Count;
            if (row == 0 || col == 0)
                return -1;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            var queue = new Queue<List<int>>();
            var visited = new HashSet<List<int>>();
            queue.Enqueue(new List<int> { 0, 0 });
            visited.Add(new List<int> { 0, 0 });
            var step = 0;
            while(queue.Count > 0)
            {
                var len = queue.Count;
                step++;
                for(var i = 0; i < len; i++)
                {
                    var location = queue.Dequeue();
                    var x = location[0];
                    var y = location[1];                    
                    foreach (var dir in directions)
                    {
                        var new_x = x + dir[0];
                        var new_y = y + dir[1];
                        if (IsValid(lot, new_x, new_y, visited))
                        {
                            if (lot[new_x][new_y] == 9)
                                return step;
                            queue.Enqueue(new List<int> { new_x, new_y });
                            visited.Add(new List<int> { new_x, new_y });
                        }
                    }
                }
                
            }

            return -1;
        }
        public bool IsValid(List<List<int>> lot, int x, int y, HashSet<List<int>> visited)
        {
            if (x < 0 || y < 0 || x >= lot.Count || y >= lot[0].Count)
                return false;
            if (visited.Contains(new List<int> { x, y }))
                return false;
            if (lot[x][y] == 0)
                return false;
            return true;
        }


    }
}
