using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class MinimumLimitOfBallsInABag
    {
        // 最小化最大值问题
        // 1. 题目转化：
        // 题目为：给定拆分次数，寻找单个袋子球数的最大值
        // 转化为： 给定单个袋子球数的最大值，计算拆分次数（如果一个袋子最多只能装X个球，需要拆分多少次？）
        // 每个袋子能装的球越多，则需要拆分的次数就越少，拆分次数y关于x单调递减，具有单调性。
        // 对每个x，得到的拆分次数y可以看作一个降序排列的数组，从左到右第一个等于maxOperations的y对应的“索引”x即为要找的最小化开销（满足题意条件的最小的x值）。           
        // 2. 计算拆分次数：
        // 如果nums[i]能被x整除，则拆分次数为nums[i]/x - 1（可以少拆分一次，减去最后不必要的一次拆分x和0）
        // 如果nums[i]不能被x整除，则拆分次数为nums[i]/x（最后一次拆分为x和余数（余数大于0））
        // 将两种情况综合起来，则拆分次数合并为（nums[i] - 1）/ x
        // 3.二分查找
        // x的取值范围：【1，max(nums)】
        // 如果operationTime(mid) == maxOperations, 不能直接跳出循环，因为mid左边还有可能有更小的x值对应同样的拆分次数maxOperations，
        // 但也不能将右指针左移到mid-1,因为mid左边也可能对应的所有拆分次数都已经大于maxOperations了。
        // 故当OperationTime(mid) <= maxOperations时，r = mid;否则l = mid+1.
        public int MinimumSize(int[] nums, int maxOperations)
        {
            int left = 1, right = nums.Max();
            if (OperationTime(nums, left) == maxOperations)
                return left;
            while(left < right)
            {
                var mid = left + (right - left) / 2;
                if (OperationTime(nums, mid) <= maxOperations)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        // x是每个袋子最多装的球的个数，返回拆分次数
        // 
        public int OperationTime(int[] nums, int x)
        {
            var oper = 0;
            foreach (var num in nums)
            {
                if (num > x)
                    oper += (num - 1) / x;
            }
            return oper;
        }
    }
}
