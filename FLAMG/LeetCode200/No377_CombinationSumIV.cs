using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No377_CombinationSumIV
    {
        /// <summary>
        /// 数组nums中所有元素无重复， 返回所有和为target的组合个数。元素可重复使用。顺序不同的序列记作不同的组合。如(1，1，2)和 (1，2，1)为不同的组合。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>      

        int result = 0;        
        int trackSum = 0;
        public int CombinationSum4(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return result;            
            Backtrack(nums, target);
            return result;
        }
        public void Backtrack(int[] nums, int target)
        {
            if (trackSum == target)
            {
                result++;
                return;
            }
            if (trackSum > target)
            {
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            { 
                trackSum += nums[i];
                Backtrack(nums, target);                
                trackSum -= nums[i];
            }
        }

    }
}
