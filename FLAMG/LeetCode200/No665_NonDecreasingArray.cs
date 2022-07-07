using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No665_NonDecreasingArray
    {
        public bool CheckPossibility(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return true;
            var flag = false;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if(flag == false)
                {
                    if(nums[i] > nums[i + 1])
                    {
                        if(i == 0)
                        {
                            nums[i] = nums[i + 1];
                        }
                        else
                        {
                            if(nums[i + 1] < nums[i - 1])
                            {
                                nums[i + 1] = nums[i];
                            }
                            //nums[i] = nums[i - 1];                            
                        }
                        flag = true;
                    }
                }
                else
                {
                    if (nums[i] > nums[i + 1])
                        return false;
                }
            }
            return true;
        }
    }
}
