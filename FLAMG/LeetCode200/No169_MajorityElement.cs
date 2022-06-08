using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No169_MajorityElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// 
        /// Brute Force
        /// T: O(N^2)
        /// S: O(1)
        /// 
        /// HashMap
        /// T: O(N)
        /// S: O(N)
        /// 
        /// Sorting
        /// T: O(nlogn)
        /// S:O(1)        
        

        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
    }
}
