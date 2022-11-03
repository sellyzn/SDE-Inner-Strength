using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.DataStructure
{
    internal class SingleNumber
    {
        // 位运算
        public int SingileNumber1(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            var result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
    }
}
