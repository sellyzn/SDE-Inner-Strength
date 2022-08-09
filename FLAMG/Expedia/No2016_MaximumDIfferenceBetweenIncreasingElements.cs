using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No2016_MaximumDIfferenceBetweenIncreasingElements
    {
        /// <summary>
        /// Prefix minimum value
        /// 当我们固定j时选择的下标i一定是满足0 <= i < j并且nums[i]最小的那个i。 因此我们可以使用循环对j进行遍历，同时维护nums[0...j - 1]的前缀最小值，记为premin。这样一来：
        /// 如果nums[j] > premin, 那么就用nums[i] - premin对答案进行更新
        /// 否则, 用nums[j]来更新前缀最小值premin
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public int MaximumDifference(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return 0;
            int ans = -1, premin = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                if(nums[i] > premin)
                    ans = Math.Max(ans, nums[i] - premin);
                else
                    premin = nums[i];
            }
            return ans;
        }
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2)
                return 0;
            int maxProfit = 0, premin = prices[0];
            for(int i = 1; i < prices.Length; i++)
            {
                maxProfit = Math.Max(maxProfit, prices[i] - premin);
                premin = Math.Min(premin, prices[i]);
            }
            return maxProfit;
        }
    }
}
