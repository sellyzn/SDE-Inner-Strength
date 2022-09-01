using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class BestTimeToBuyAndSellStock
    {
        /*
         * 框架********************************************************************************************
         * **********************************************************
         * 穷举「状态」, 然后在「选择」中选择最优解.                    
         * for 状态1 in 状态1的所有取值:                             
         *    for 状态2 in 状态2的所有取值:                          
         *        for...                                          
         *          dp[状态1][状态2][...] = 择优(选择1，选择2...)    
         * **********************************************************
         * **********************************************************
         * dp[i][k][0 or 1]
         * 0 <= i <= n - 1, 1 <= k <= K
         * n 为天数，大 K 为交易数的上限，0 和 1 代表是否持有股票。
         * 此问题共 n × K × 2 种状态，全部穷举就能搞定。

         *  for 0 <= i < n:
         *      for 1 <= k <= K:
         *          for s in {0, 1}:
         *              dp[i][k][s] = max(buy, sell, rest)
         * **********************************************************
         *      
        「选择」：买入，卖出，无操作， 用buy, sell, rest表示这三种选择。
        「状态」： 
                天数，允许交易的最大次数，当前的持有状态（1表示持有股票，0表示没有持有股票）
                dp[i][k][0 or 1]: 0 <= i <= n - 1, 1 <= k <= K, n为天数，K为交易数的上线，0和1代表是否持有股票
                dp[n-1][k][0]： 最后一天，最多允许K次交易，最多获得多少利润。
        「状态转移方程」： 
                dp[i][k][0] = max(dp[i-1][k][0], dp[i - 1][k][1] + prices[i])
                              max(今天选择rest,    今天选择sell                )
                        在选择buy的时候开启了一次交易
                dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
                              max(今天选择rest,    今天选择buy                 )
        「Base Case」:
                dp[-1][...][0] = 0;
                解释：因为 i 是从 0 开始的，所以 i = -1 意味着还没有开始，这时候的利润当然是 0。

                dp[-1][...][1] = -infinity
                解释：还没开始的时候，是不可能持有股票的。
                因为我们的算法要求一个最大值，所以初始值设为一个最小值，方便取最大值。

                dp[..][0][0] = 0
                解释：因为 k 是从 1 开始的，所以 k = 0 意味着根本不允许交易，这时候利润当然是 0。

                dp[...][0][1] = -infinity
                解释：不允许交易的情况下，是不可能持有股票的。
                因为我们的算法要求一个最大值，所以初始值设为一个最小值，方便取最大值。

        base case：
                dp[-1][...][0] = dp[...][0][0] = 0
                dp[-1][...][1] = dp[...][0][1] = -infinity
        状态转移方程：
                dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
                dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])

        ****************************************************************************************************
         */

        //121. Best Time to Buy and Sell Stock
        // 一次交易, k = 1
        /*
        我们只要用一个变量记录一个历史最低价格 minprice，我们就可以假设自己的股票是在那天买的。那么我们在第 i 天卖出股票能得到的利润就是 prices[i] - minprice。
        因此，我们只需要遍历价格数组一遍，记录历史最低点，然后在每一天考虑这么一个问题：如果我是在历史最低点买进的，那么我今天卖出能赚多少钱？当考虑完所有天数之时，我们就得到了最好的答案。

         */
        public int MaxProfit_Frame(int[] prices)
        {
            int n = prices.Length;
            var dp = new int[n, 2];
            for(int i = 0; i < n; i++)
            {
                if(i - 1 == -1)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }
                dp[i,0] = Math.Max(dp[i - 1,0], dp[i - 1,1] + prices[i]);
                dp[i,1] = Math.Max(dp[i-1,1], -prices[i]);
            }
            return dp[n - 1, 0];
        }
        public int MaxProfit_SpaceOpt(int[] prices)
        {
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            for(int i = 1; i < n; i++)
            {
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, -prices[i]);
            }
            return dp_i_0;
        }
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int minPrice = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            }
            return maxProfit;
        }

        // 122. Best Time to Buy and Sell Stock II
        // 多次交易，每天都可以买入，卖出, k = +infinity
        // 一次遍历
        /*
         股票买卖策略：
        单独交易日： 设今天价格p1、明天价格p2，则今天买入、明天卖出可赚取金额 p2−p1（负值代表亏损）。
        连续上涨交易日： 设此上涨交易日股票价格分别为 p_1, p_2, ... , p_n，则第一天买最后一天卖收益最大，即 p_n - p_1；等价于每天都买卖，即 p_n - p_1=(p_2 - p_1)+(p_3 - p_2)+...+(p_n - p_{n-1})。
        连续下降交易日： 则不买卖收益最大，即不会亏钱。

        算法流程：
        遍历整个股票交易日价格列表 price，策略是所有上涨交易日都买卖（赚到所有利润），所有下降交易日都不买卖（永不亏钱）。
        1. 设 tmp 为第 i-1 日买入与第 i 日卖出赚取的利润，即 tmp = prices[i] - prices[i - 1] ；
        2. 当该天利润为正 tmp > 0，则将利润加入总利润 profit；当利润为 0 或为负，则直接跳过；
        3. 遍历完成后，返回总利润 profit。

        等价于相邻两天的买卖，每天都买卖
         */

        public int MaxProfitII_Frame(int[] prices)
        {
            int n = prices.Length;
            var dp = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                if (i - 1 == -1)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i-1,0] - prices[i]);
            }
            return dp[n - 1, 0];
        }
        public int MaxProfitII_SpaceOpt(int[] prices)
        {
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            for (int i = 1; i < n; i++)
            {
                var temp = dp_i_0;
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
            }
            return dp_i_0;
        }

        public int MaxProfitII(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                    maxProfit += prices[i + 1] - prices[i];
            }
            return maxProfit;
        }

        
        // 309. Best Time to Buy and Sell Stock with Cooldown
        // k = +infinity with cooldown
        /*
        状态转移方程：
                dp[i][0] = max(dp[i - 1][0], dp[i - 1][1] + prices[i])
                dp[i][1] = max(dp[i - 1][1], dp[i - 2][0] - prices[i])
                解释：第 i 天选择 buy 的时候，要从 i-2 的状态转移，而不是 i-1 。
         */
        public int MaxPrifitCooldown_Frame(int[] prices)
        {
            int n = prices.Length;
            var dp = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                if (i - 1 == -1)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }
                if(i - 2 == -1)
                {
                    dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                    dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
                    //   dp[i][1] 
                    // = max(dp[i-1][1], dp[-1][0] - prices[i])
                    // = max(dp[i-1][1], 0 - prices[i])
                    // = max(dp[i-1][1], -prices[i])
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 2, 0] - prices[i]);
            }
            return dp[n - 1, 0];
        }
        public int MaxProfitCooldown_SpaceOpt(int[] prices)
        {
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            int dp_pre_0 = 0; // 代表dp[i-2][0]
            for (int i = 1; i < n; i++)
            {
                var temp = dp_i_0;
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, dp_pre_0 - prices[i]);
                dp_pre_0 = temp;
            }
            return dp_i_0;
        }



        // 714. Best Time to Buy and Sell Stock with Transaction Fee
        // k = +infinity with fee
        /*
        每次交易要支付手续费，只要把手续费从利润中减去即可。
        状态转移方程：
            dp[i][0] = max(dp[i-1][0], dp[i-1][1] + prices[i])
            dp[i][1] = max(dp[i-1][1], dp[i-1][0] - prices[i] - fee)
            解释：相当于买入股票的价格升高了。
            在第一个式子里减也是一样的，相当于卖出股票的价格减小了。

         */
        public int MaxPrifitFee_Frame(int[] prices, int fee)
        {
            int n = prices.Length;
            var dp = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                if (i - 1 == -1)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i] - fee;
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i] - fee);
            }
            return dp[n - 1, 0];
        }
        public int MaxProfitFee_SpaceOpt(int[] prices, int fee)
        {
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            for (int i = 1; i < n; i++)
            {
                var temp = dp_i_0;
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, temp - prices[i] - fee);
            }
            return dp_i_0;
        }

        // 123. Best Time to Buy and Sell Stock III
        //最多两次交易, k = 2
        /*
        状态转移方程：
            dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
            dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])

         */
        public int MaxProfitIII_Frame(int[] prices)
        {
            int n = prices.Length;
            int maxK = 2;
            var dp = new int[n, maxK + 1, 2];
            for(int i = 0; i < n; i++)
            {
                for(int k = maxK; k >= 1; k--)
                {
                    if(i - 1 == -1)
                    {
                        dp[i, k, 0] = 0;
                        dp[i, k, 1] = -prices[i];
                        continue;
                    }
                    dp[i, k, 0] = Math.Max(dp[i - 1, k, 0], dp[i - 1, k, 1] + prices[i]);
                    dp[i, k, 1] = Math.Max(dp[i - 1, k, 1], dp[i - 1, k - 1, 0] - prices[i]);
                }
            }
            return dp[n - 1, maxK, 0];
        }


        // k比较小，可以不用for循环，直接把 k = 1 和 2 的情况全部列出来就可以：
        // 状态转移方程：
        // dp[i][2][0] = max(dp[i-1][2][0], dp[i-1][2][1] + prices[i])
        // dp[i][2][1] = max(dp[i-1][2][1], dp[i-1][1][0] - prices[i])
        // dp[i][1][0] = max(dp[i-1][1][0], dp[i-1][1][1] + prices[i])
        // dp[i][1][1] = max(dp[i-1][1][1], -prices[i])
        public int MaxProfitIII_SpaceOpt(int[] prices)
        {
            int dp_i10 = 0, dp_i11 = int.MinValue;
            int dp_i20 = 0, dp_i21 = int.MinValue;
            foreach (int price in prices)
            {
                dp_i20 = Math.Max(dp_i20, dp_i21 + price);
                dp_i21 = Math.Max(dp_i21, dp_i10 - price);
                dp_i10 = Math.Max(dp_i10, dp_i11 + price);
                dp_i11 = Math.Max(dp_i11, -price);
            }
            return dp_i20;
        }


        // 188. Best Time to Buy and Sell Stock IV
        // k = any integer
        public int MaxProfitIV_Frame(int[] prices, int k)
        {
            int n = prices.Length;
            if (n <= 0)
                return 0;
            if(k > n / 2)
                return MaxProfitIII_Frame(prices);  // 交易次数没有限制
            
            var dp = new int[n, k + 1, 2];
            // k = 0
            for(int i = 0; i < n; i++)
            {
                dp[i, 0, 0] = 0;
                dp[i, 0, 1] = int.MinValue;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = k; j >= 1; j--)
                {
                    if (i - 1 == -1)
                    {
                        dp[i, j, 0] = 0;
                        dp[i, j, 1] = -prices[i];
                        continue;
                    }
                    dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);
                    dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
                }
            }
            return dp[n - 1, k, 0];
        }


    }
}
