using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    public class BrickCompiler : IComparer<string>
    {
        public int Compare(int a, int b)
        {
            if (a > b)
                return 1;
            else
                return -1;
        }
    }

    internal class No1642_FurthestBuildingYouCanReach
    {
        /// <summary>
        /// Max Heap
        /// 遍历
        /// 如果 height[i] - height[i - 1] <= 0, 直接跳过去就行
        /// 如果 height[i] - height[i - 1] > 0：
        ///     先放砖头，接着往下走，知道砖头都用完了
        ///     找出之前爬过的大楼中，用最多砖头的一次，用梯子替换，将该次的砖头转移过来，继续前进
        ///     直到没有梯子，砖头也不够的时候，返回当前的大楼
        ///     
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="bricks"></param>
        /// <param name="ladders"></param>
        /// <returns></returns>
        /// T: O(NlogN), Heap operations are O(logN) in the worst case.
        /// S: O(N)
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            var hq = new PriorityQueue<int>((a, b) -> b - a);
            for(int i = 1; i < heights.Length; i++)
            {
                int cnt = heights[i] - heights[i - 1];                
                if(cnt > 0)
                {
                    hq.Enqueue(cnt);
                    bricks -= cnt;
                    if(bricks < 0)
                    {
                        if(ladders > 0)
                        {
                            ladders--;
                            bricks += hq.Dequeue();
                        }
                        else
                        {
                            return i - 1;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            return heights.Length - 1;
        }
    }
}
