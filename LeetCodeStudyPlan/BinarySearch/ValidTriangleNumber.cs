using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class ValidTriangleNumber
    {
        /*
         [2,2,3,4]

         */
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            var count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];
                    var index = j + 1;
                    while (index < nums.Length && sum > nums[index])
                        index++;
                    count += index - j - 1;
                }
            }
            return count;
        }       
    }
}
