using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzelII
{
    public class MedianIndex
    {
        public int GetAns(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dict.Add(nums[i], i);
            }
            Array.Sort(nums);
            if (nums.Length % 2 == 0)
            {
                return dict[nums[nums.Length / 2 - 1]];
            }
            else
            {
                return dict[nums[nums.Length / 2]];
            }
        }
    }
}
