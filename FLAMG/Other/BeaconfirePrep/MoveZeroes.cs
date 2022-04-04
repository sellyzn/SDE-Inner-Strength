using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BeaconfirePrep
{
    public class MoveZeroes
    {
        public void MoveZeroesSolution(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {                
                if(nums[fast] != 0)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            for(int i = slow; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
