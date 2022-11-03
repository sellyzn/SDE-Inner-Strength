using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class FindTheDuplicateNumber
    {
        ///*
        // nums: 1,3,4,2,2
        //sum1: all the element of nums
        //sum2: 1~n
        //duplicate: sum1 - sum2
        // */
        //public int FindDuplicate(int[] nums)
        //{
        //    var n = nums.Length;
        //    var num = 1;
        //    var sum = 0;
        //    for(var i = 0; i < n - 1; i++)
        //    {
        //        sum += nums[i] - num;
        //        num++;
        //    }
        //    sum += nums[n - 1];
        //    return sum;
        //}

        // All the integers in nums appear only once except for precisely one integer which appears two or more times.
        public int FindDuplicate(int[] nums)
        {
            if (nums.Length > 1)
            {
                int slow = nums[0];
                int fast = nums[nums[0]];
                while (slow != fast)
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                }

                fast = 0;
                while (fast != slow)
                {
                    fast = nums[fast];
                    slow = nums[slow];
                }
                return slow;
            }
            return -1;
        }
    }
}
