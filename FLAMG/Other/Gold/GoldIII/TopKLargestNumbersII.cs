using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIII
{
    //用一个最大堆维护这些数字
    //当遇到add(number)这个操作时，就将元素加入到最大堆中，
    //当遇到topk操作时就分K次取出最大堆顶元素，返回这些元素，然后将刚才加入的元素放回最大堆即可
    public class TopKLargestNumbersII
    {
        int maxSize;
        PriorityQueue<int> minHeap;
        public TopKLargestNumbersII(int k)
        {
            maxSize = k;
            minHeap = new PriorityQueue<int>();
        }

        public void Add(int num)
        {
            if(minHeap.Size() < maxSize)
            {
                minHeap.Add(num);
                return;
            }
            if(num > minHeap.Peek())
            {
                minHeap.PopFirst();
                minHeap.Add(num);
            }
        }
        
        public IList<int> TopK()
        {            
            var result = new List<int>();
            int index = 0;
            while(index < maxSize)
            {
                result.Add(minHeap.PopLast());
            }
            
            return result;
        }
    }
}
