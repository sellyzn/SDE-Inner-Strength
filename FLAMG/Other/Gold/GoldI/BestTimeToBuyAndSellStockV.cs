//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace FLAMG.Other.Gold.GoldI
//{
//    public class BestTimeToBuyAndSellStockV
//    {
//        public int GetAns(int[] a)
//        {
//            PriorityQueue<int> minheap = new PriorityQueue<>();
//            int res = 0;
//            foreach (int k in a)
//            {
//                // 如果k比之前遇到过的最低价高
//                if (minheap.size() > 0 && k > minheap.peek())
//                {
//                    // 收益就是当前k - 遇到过的最低价
//                    res += k - minheap.Dequeue();
//                    minheap.Enqueue(k);
//                }
//                // 同时将当前值压入队列
//                minheap.offer(k);
//            }
//            return res;
//        }
//    }
//}
