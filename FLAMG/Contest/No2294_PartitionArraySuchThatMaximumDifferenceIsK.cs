using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class No2294_PartitionArraySuchThatMaximumDifferenceIsK
    {
        public int PartitionArray(int[] nums, int k)
        {
            Array.Sort(nums);
            int ans = 1, min = nums[0];
            foreach (var num in nums)
            {
                if(num - min > k)
                {
                    ans++;
                    min = num;
                }
            }
            return ans;
        }
    }
}
