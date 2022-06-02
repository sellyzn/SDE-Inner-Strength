using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No121BestTimeToBuyAndSellStock
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        /// 
        /// Brute force:
        /// T: O(N^2)
        /// S: O(1)
        /// 
        /// Find Min price, DP
        /// T: O(N)
        /// S: O(1)
        public int MaxProfit(int[] prices)
        {
            // dp[n] = Max(dp[n - 1], prices[n] - minPrice)
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for(int j = i; j < prices.Length; j++)
                {
                    maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
                }
            }
            return maxProfit;
        }
        public int MaxProfit_Opt(int[] prices)
        {
            int maxProfit = 0;
            int minPrice = int.MaxValue;
            for(int i = 0;i < prices.Length; i++)
            {
                if(prices[i] < minPrice)
                    minPrice = prices[i];
                maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            }
            return maxProfit;
        }
    }
}
