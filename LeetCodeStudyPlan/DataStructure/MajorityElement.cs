using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.DataStructure
{
    internal class MajorityElement
    {
        // brute force
        public int MajorityElement1(int[] nums)
        {
            int majorityCount = nums.Length / 2;
            foreach (var num in nums)
            {
                int count = 0;
                foreach (var elem in nums)
                {
                    if (elem == num)
                        count++;
                }
                if (count > majorityCount)
                    return num;
            }
            return -1;
        }
        //sorting
        public int MajorityElement2(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
        //bit manupulation
        public int MajorityElement3(int[] nums)
        {
            int n = nums.Length;
            int majorityElement = 0;
            for(int i = 0; i < 32; i++)
            {
                int bit = 1 << i;
                int bitCount = 0;
                foreach (var num in nums)
                {
                    if ((num & bit) != 0)
                        bitCount++;
                }
                if (bitCount > n / 2)
                    majorityElement |= bit;
            }
            return majorityElement;
        }

    }
}
