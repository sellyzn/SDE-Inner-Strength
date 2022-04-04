using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class Excercise
    {
        public int NumIsland(bool[][] grid)
        {
            //corner case
            int row = grid.Length;
            if (row == 0)
                return 0;
            int col = grid[0].Length;
            if (col == 0)
                return 0;

            //traverse the array
            int count = 0;
            var visited = new HashSet<int[]>();
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if (grid[i][j] && !visited.Contains(new int[] { i, j}))
                    {
                        BFS_Island(grid, i, j, visited);
                        count++;
                    }
                }
            }
            return count;
        }
        public void BFS_Island(bool[][] grid, int start_x, int start_y, HashSet<int[]> visited)
        {
            var DIRECTIONS = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { start_x, start_y });
            visited.Add(new int[] { start_x, start_y });
            while(queue.Count > 0)
            {
                var location = queue.Dequeue();
                foreach(var dir in DIRECTIONS)
                {
                    int new_x = location[0] + dir[0];
                    int new_y = location[1] + dir[1];
                    if(grid[new_x][new_y] && IsValid(grid, new_x, new_y, visited))
                    {
                        queue.Enqueue(new int[] { new_x, new_y });
                        visited.Add(new int[] { new_x, new_y });
                    }
                }
            }
        }
        public bool IsValid(bool[][] grid, int x, int y, HashSet<int[]> visited)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length)
                return false;
            if (!grid[x][y])
                return false;
            if (visited.Contains(new int[] { x, y }))
                return false;
            return true;
        }


        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // 1. Adjacency list initialization
            //var adjacency = new Dictionary<int, int>();
            var adjacency = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                adjacency[i] = new List<int>();
            }

            // 2. Adjacency list and indegree list creation
            //var indegree = new Dictionary<int, int>();
            var indegree = new int[numCourses];
            foreach (var info in prerequisites)
            {
                //adjacency.Add(info[1], info[0]);

                //if (indegree.ContainsKey(info[0]))
                //    indegree[info[0]]++;
                //else
                //    indegree.Add(info[0], 1);

                //if (!indegree.ContainsKey(info[1]))
                //    indegree.Add(info[1], 0);
                adjacency[info[1]].Add(info[0]);
                indegree[info[0]]++;
            }

            // 3. Traverse all nodes, and enqueue nodes with indegree 0
            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }

            // 4. BFS
            var visited = 0;
            while(queue.Count > 0)
            {
                int pre = queue.Dequeue();
                visited++;
                foreach (var cur in adjacency[pre])
                {
                    indegree[cur]--;
                    if (indegree[cur] == 0)
                        queue.Enqueue(cur);
                }
            }
            return visited == numCourses;
        }

    }
}
