using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No27RemoveElement
    {
        /// <summary>
        /// Two pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        
        // 相向双指针
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                while (left <= right && nums[right] == val)
                    right--;
                while (left <= right && nums[left] != val)
                    left++;
                if(left < right)
                {
                    if (nums[left] == val)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    left++;
                    right--;
                }                
            }
            return left;
        }

        // 同向双指针
        // 
        public int RemoveElement_Opt(int[] nums, int val)
        {
            int i = 0;
            for(int j = 0; j < nums.Length; j++)
            {
                if(nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }
    }
}
