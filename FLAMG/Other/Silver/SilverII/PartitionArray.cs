using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverII
{
    public class PartitionArray
    {
        //Two pointers
        public int PartitionArrayI(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                while (left <= right && nums[left] < k)
                    left++;
                while (left <= right && nums[right] >= k)
                    right--;
                if(left <= right)
                {
                    int tmp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = tmp;
                }
            }
            return left;
        }
    }
}
