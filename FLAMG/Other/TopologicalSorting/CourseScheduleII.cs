using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.TopologicalSorting
{
    public class CourseScheduleII
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numCourse"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        
        //stores the 
        List<List<int>> edges;
        //Stores the indeg
        int[] indeg;
        //stores the result
        int[] result;
        // result index
        int index;
        public int[] FindOrder(int numCourse, int[][] prerequisites)
        {
            edges = new List<List<int>>();
            for(int i = 0; i < numCourse; i++)
            {
                edges.Add(new List<int>());
            }

            indeg = new int[numCourse];
            result = new int[numCourse];
            index = 0;
            foreach (var info in prerequisites)
            {
                edges[info[1]].Add(info[0]);
                indeg[info[0]]++;
            }

            var queue = new Queue<int>();
            //travese all nodes, put the nodes which indeg is 0 into queue
            for(int i = 0; i < numCourse; i++)
            {
                if (indeg[i] == 0)
                    queue.Enqueue(i);
            }

            while(queue.Count > 0)
            {
                //dequeue one node from queue front
                int u = queue.Dequeue();
                result[index++] = u;
                foreach (var v in edges[u])
                {
                    indeg[v]--;
                    if (indeg[v] == 0)
                        queue.Enqueue(v);
                }
            }

            if (index != numCourse)
                return new int[0];
            return result;
        }
    }
}
