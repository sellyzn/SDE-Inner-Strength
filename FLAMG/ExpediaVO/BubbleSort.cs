using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class BubbleSort
    {
        // acsending order
        /*
         * nums: 3 2 5 4 8 6 7 
         *       j
         * nums: 2 3 5 4 8 6 7
         * 
         * T: O(N^2)
         * S: O(1)
         */
        public void BubbleSortImplement(int[] nums)
        {
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(nums[j] > nums[j + 1])
                    {
                        var temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }
    }
}
