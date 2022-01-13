using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzelII
{
    public class RemoveDuplicateNumbersInArray
    {
        public int DeDuplecation(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            Array.Sort(nums);
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                //if (nums[slow] == nums[fast])
                //    fast++;
                //else if(nums[slow] != nums[fast])
                //{
                //    slow++;
                //    nums[slow] = nums[fast];
                //    fast++;
                //}


                if(nums[slow] != nums[fast])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
                fast++;
            }
            return slow + 1;
        }
    }
}
