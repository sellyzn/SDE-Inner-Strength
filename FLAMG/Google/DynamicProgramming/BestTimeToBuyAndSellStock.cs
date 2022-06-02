using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.DynamicProgramming
{
    public class BestTimeToBuyAndSellStock
    {
        // 121.
        public int MaxProfit(int[] prices)
        {
            // dp[i]: the max profit at the ith day.
            // dp[i] = Max(dp[i - 1], prices[i] - minValue),    minValue is the min price from prices[0] to prices[i - 1]

            var maxProfit = 0;
            var minValue = int.MaxValue;
            for(int i = 0; i < prices.Length; i++)
            {
                maxProfit = Math.Max(maxProfit, prices[i] - minValue);
                minValue = Math.Min(minValue, prices[i]);
            }
            return maxProfit;
        }

        // 122.
        public int MaxProfit_II(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int maxProfit = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if(prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }
    }
}
