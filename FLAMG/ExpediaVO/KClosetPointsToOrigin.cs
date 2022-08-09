using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Node(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    internal class KClosetPointsToOrigin
    {
        public int[][] KClosest(int[][] points, int k)
        {
            // distance = x^2 + y^2 
            // distance最小的前k个点
            // distance升序排序，取前k个
            // Dictionary<int[], long>()
            var distanceMap = new Dictionary<Node, long>();
            for(int i = 0; i < points.Length; i++)
            {
                var node = new Node(points[i][0], points[i][1]);
                long distance = (long)Math.Pow(points[i][0], 2) + (long)Math.Pow(points[i][1], 2);
                distanceMap.Add(node, distance);
            }
            var res = new List<int[]>();
            foreach (var item in distanceMap)
            {
                res.Add(new int[] {item.Key.X, item.Key.Y});
            }
            res.Sort(
                delegate(int[] arr1, int[] arr2)
                {
                    var node1 = new Node(arr1[0], arr1[1]);
                    var node2 = new Node(arr2[0], arr2[1]);
                    return (int)(distanceMap[node1] - distanceMap[node2]);
                }
                );
            return res.GetRange(0, k).ToArray();
        }
        public int[][] KCloset1(int[][] points, int k)
        {
            var distanceMap = new Dictionary<int[], long>();
            for (int i = 0; i < points.Length; i++)
            {
                var node = new int[] { points[i][0], points[i][1] };
                long distance = (long)Math.Pow(points[i][0], 2) + (long)Math.Pow(points[i][1], 2);
                distanceMap.Add(node, distance);
            }
            var res = new List<int[]>();
            foreach (var item in distanceMap)
            {
                res.Add(new int[] { item.Key[0], item.Key[1] });
            }
            res.Sort(
                delegate (int[] arr1, int[] arr2)
                {                    
                    return (int)(distanceMap[arr1] - distanceMap[arr2]);
                }
                );
            return res.GetRange(0, k).ToArray();
        }

        /// <summary>
        /// Sorting
        /// </summary>
        /// <param name="points"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(nlogn)
        /// S: O()
        public int[][] KCloset(int[][] points, int k)
        {
            points = points.OrderBy(x => x[0] * x[0] + x[1] * x[1]).ToArray();
            var res = new List<int[]>();
            for(int i = 0; i < k; i++)
            {
                res.Add(new int[] { points[i][0], points[i][1] });
            }
            return res.ToArray();
        }
    }
}
