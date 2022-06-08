using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No122_BestTimeToBuyAndSellStockII
    {
        /// <summary>
        /// Greedy
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int MaxProfit(int[] prices)
        {
            if(prices == null || prices.Length == 0)
                return 0;
            int maxProfit = 0;
            for(int i = 0; i < prices.Length - 1; i++)
            {
                if(prices[i + 1] > prices[i])
                    maxProfit += prices[i + 1] - prices[i];
            }
            return maxProfit;
        }
    }
}
