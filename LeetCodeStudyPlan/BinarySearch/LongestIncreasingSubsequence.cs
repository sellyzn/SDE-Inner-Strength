using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;
            var dp = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }
            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            return dp.Max();
        }
        public int LengthOfLISII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;
            // dp数组定义：长度为 i+1 的上升序列的末尾最小是几
            var dp = new int[nums.Length];
            // end表示有序数组dp的最后一个已经赋值元素的索引
            var end = 0;
            // 遍历第一个数，直接放在有序数组dp的开头
            dp[0] = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                
            }
            for (int i = 1; i < nums.Length; i++)
            {
                // 【逻辑1】比 tail 数组实际有效的末尾的那个元素还大
                if (nums[i] > dp[end])
                {
                    // 直接添加在那个元素的后面，所以 end 先加 1
                    end++;
                    dp[end] = nums[i];
                }
                else
                {
                    // 使用二分查找法，在有序数组 tail 中
                    // 找到第 1 个大于等于 nums[i] 的元素，尝试让那个元素更小
                    int left = 0, right = end;
                    while (left < right)
                    {
                        int mid = left + (right - left) / 2;
                        if (dp[mid] < nums[i])
                        {
                            // 中位数肯定不是要找的数，把它写在分支的前面
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid;
                        }
                    }
                    // 走到这里是因为 【逻辑 1】 的反面，因此一定能找到第 1 个大于等于 nums[i] 的元素
                    // 因此，无需再单独判断
                    dp[left] = nums[i];
                }
            }

            // end 是有序数组 tail 最后一个元素的索引
            // 题目要求返回的是长度，因此 +1 后返回
            return end + 1;
        }
    }
}
