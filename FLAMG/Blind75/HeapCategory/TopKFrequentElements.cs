using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.HeapCategory
{
    internal class TopKFrequentElements
    {
        
        // 347. Top K Frequent Elements
        public int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if(dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict.Add(num, 1);
            }
            var queue = new PriorityQueue<int[]>();
            foreach (var item in dict)
            {
                int num = item.Key, count = item.Value;
                if(queue.Count == k)
                {
                    if(queue.Peek()[1] < count)
                    {
                        queue.Dequeue();
                        queue.Enqueue(new int[] {num, count});
                    }
                }
                else
                {
                    queue.Enqueue(new int[] {num, count});
                }
            }
            var ret = new int[k];
            for(int i = 0; i < k; i++)
            {

            }
        }
    }
}
