using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class MagneticForceBetweenTwoBalls
    {
        // 单调性： 最小磁力越大，最多能放置的球的个数越小。
        public int MaxDistance(int[] position, int m)
        {
            // 假设最小磁力是f，此时可以放入的最多球数是num
            // num随着f的增加二单调递减
            // 对于f进行二分查找，计算对应的num与m进行比较
            // 如果num >= m， 说明可以放下m个球，则f<=我们要找的目标磁力
            // f的取值范围为【1， max(position) - min(position)】
            //
            Array.Sort(position);
            int left = 1, right = position[position.Length - 1] - position[0];
            
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if(Check(position, mid, m))
                    left = mid;
                else
                    right = mid - 1;
            }
            return left;
        }
        public bool Check(int[] position, int f, int m)
        {
            // 排序后的第一个位置一定放一个球
            int curPos = position[0];
            int cnt = 1;
            foreach (var pos in position)
            {
                // 如果遍历到的位置与前一个放球的位置间距不小于 f，则满足条件，可以放球
                if (pos - curPos >= f)
                {
                    cnt++;
                    curPos = pos;
                }
            }
            return cnt >= m;
        }
    }
}
