using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode75.TwoPointersPorblems
{
    internal class P1679_MaxNumberOfKSumPairs
    {
        /*
        双指针：
        1. 排序(升序)
        2. left = 0, right = nums.Length - 1，香中间收拢
            如果nums[left] + nums[right] == k --> left++, right++, count++;
            如果nums[left] + nums[right] > k --> right--
            如果nums[left] + nums[right] < k --> left++
        时间: O(nlogn + n)
        空间：O(1)
         */
        public int MaxOperations(int[] nums, int k)
        {
            //var countMap = new SortedDictionary<int, int>();
            ////构建SortedDictionary, (k, v) -> (数字，个数)
            //foreach (var num in nums)
            //{
            //    var v = countMap.GetValueOrDefault(num, 0);
            //    countMap.Add(num, v + 1);
            //}
            //var res = 0;
            //// 遍历所有的键值对
            //while(countMap.Count > 0)
            //{

            //}
            //return res;
            var max = 0;
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1;
            while(left < right)
            {
                if (nums[left] + nums[right] == k)
                {
                    max++;
                    left++;
                    right--;
                }else if (nums[left] + nums[right] > k)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return max;
        }
    }
}
