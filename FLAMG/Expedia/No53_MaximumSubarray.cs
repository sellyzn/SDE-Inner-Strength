using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No53_MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0], pre = 0;
            foreach (var num in nums)
            {
                pre = Math.Max(pre + num, num);
                maxSum = Math.Max(maxSum, pre);
            }
            return maxSum;
        }
    }
}
