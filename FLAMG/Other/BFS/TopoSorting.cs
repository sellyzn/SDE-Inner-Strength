using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class TopoSorting
    {
        /**
         * 1. Course Schedule I
         */
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //1. Adjacency table initialization
            var adjacency = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                adjacency[i] = new List<int>();
            }
            //2. Create adjacency table and indegree list
            var indegree = new int[numCourses];
            foreach (var info in prerequisites)
            {
                adjacency[info[1]].Add(info[0]);
                indegree[info[1]]++;
            }
            //3. enqueue the nodes with indegree is 0
            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }

            //4. BFS
            var visited = 0;
            while(queue.Count> 0)
            {
                var pre = queue.Dequeue();
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



        /**
         * 2. Course Schedule II
         */
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            //1. Adjacency table
            var adjacency = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                adjacency[i] = new List<int>();
            }
            //2. Create the adjacency table and indegree list
            var indegree = new int[numCourses];
            foreach (var info in prerequisites)
            {
                adjacency[info[1]].Add(info[0]);
                indegree[info[0]]++;
            }
            //3. Enqueue all nodes with indegree is 0
            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }
            //4. BFS
            var result = new int[numCourses];
            var index = 0;
            while(queue.Count > 0)
            {
                var pre = queue.Dequeue();
                result[index++] = pre;
                foreach (var cur in adjacency[pre])
                {
                    indegree[cur]--;
                    if (indegree[cur] == 0)
                        queue.Enqueue(cur);
                }
            }
            if (index != numCourses)
                return new int[0];
            return result;
        }

        // 3. Loud and Rich






    }
}
