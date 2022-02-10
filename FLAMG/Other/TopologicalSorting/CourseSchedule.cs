using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.TopologicalSorting
{
    public class CourseSchedule
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numCourses"></param> the number of courses you have to take, labeled from 0 to numCourses - 1
        /// <param name="prerequisites"></param> prerequisites[i] = [ai, bi], indicates that you must take course bi first if you want to take course ai
        /// <returns></returns>
        /// 
        List<List<int>> edges;
        int[] visited;
        bool valid = true;
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            edges = new List<List<int>>();
            for(int i = 0; i < numCourses; i++)
            {
                edges.Add(new List<int>());   //initialize
            }

            foreach (var info in prerequisites)
            {
                // you must take course info[1] first if you want to take course info[0], so info[1] points to info[0]
                // for the list of info[1], it stores the course that info[1] points to
                edges[info[1]].Add(info[0]);
            }

            for(int i = 0; i < numCourses; i++)
            {
                // if the course has not been visited, then DFS
                if (visited[i] == 0)
                    DFS(i);
            }
            return valid;
        }
        public void DFS(int u)
        {
            visited[u] = 1; 
            foreach (var v in edges[u])
            {
                if(visited[v] == 0)
                {
                    DFS(v);
                    if (!valid)
                        return;
                }else if(visited[v] == 1)
                {
                    valid = true;
                    return;
                }
            }
            visited[u] = 2;
        }

        //List<List<int>> edges;
        int[] indeg;
        public bool CanFinish_BFS(int numCourses, int[][] prerequisites)
        {
            edges = new List<List<int>>();
            for(int i = 0; i < numCourses; i++)
            {
                edges.Add(new List<int>());
            }

            indeg = new int[numCourses];
            foreach (var info in prerequisites)
            {
                edges[info[1]].Add(info[0]);
                indeg[info[0]]++;
            }

            var queue = new Queue<int>();
            // traverse all nodes, put all nodes which indegree is 0 into queue
            for(int i = 0; i < numCourses; i++)
            {
                if (indeg[i] == 0)
                    queue.Enqueue(i);
            }

            int visited = 0;
            while(queue.Count > 0)
            {
                visited++;
                int u = queue.Dequeue();
                foreach (var v in edges[u])
                {
                    indeg[v]--;
                    if (indeg[v] == 0)
                        queue.Enqueue(v);
                }
            }
            return visited == numCourses;
        }
    }
}
