using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No163MissingRanges
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        /// The output list has a worst case size of O(N). 
        /// This case occurs when we have a missing range between each of the consecutive elements in the input array 
        /// (for example, if the input array contains all even numbers between lower and upper).
        /// We aren't using any other additional space, beyond fixed-sized constants that don't grow with the size of the input.

        /// However, output space that is simply used to return the output(and not to do any processing) is not counted 
        /// for the purpose of space complexity analysis.For this reason, the overall space complexity is O(1).
        /// 
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            // traverse nums, check nums[i] + 1, nums[i + 1] - 1
            // if(nums[i] + 1 < nums[i + 1] - 1) => "num[i] + 1 -> nums[i + 1] - 1"
            // if(nums[i] + 1 == nums[i + 1] - 1) => "nums[i] + 1"
            // if(nums[i] + 1 > nums[i + 1] - 1) => null
            // edge: nums[0] - 1 with lower, nums[n - 1] + 1 with upper
            // if(lower == nums[0] - 1) => "lower"
            // if(lower < nums[0] - 1) => "lower -> nums[0] - 1"
            // if (lower > nums[0] - 1) => null
            // if(upper == nums[n - 1] + 1) => "lower"
            // if(upper > nums[n - 1] + 1) => "lower -> nums[0] - 1"
            // if (upper < nums[n - 1] + 1) => null

            var result = new List<string>();
            if (nums == null || nums.Length <= 1)
                return result;

            var arrayStart = nums[0] - 1;
            if(lower < arrayStart)
                result.Add(lower + "->" + arrayStart);
            if (lower == arrayStart)
                result.Add(lower.ToString());
            
            for(int i = 0; i < nums.Length - 1; i++)
            {
                var start = nums[i] + 1;
                var end = nums[i + 1] - 1;
                if (start < end)
                    result.Add(start + "->" + end);
                else if (start == end)
                    result.Add(start.ToString());
            }

            // 结果和顺序有关，所以要放在后面
            var arrayEnd = nums[nums.Length - 1] + 1;
            if (upper > arrayEnd)
                result.Add(arrayEnd + "->" + upper);
            if (arrayEnd == upper)
                result.Add(upper.ToString());

            return result;
        }
    }
}
