using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIV
{
    public class Backpack
    {
        /// <summary>
        /// How full you can fill the backpack
        /// </summary>
        /// <param name="m"></param> the size of a backpack
        /// <param name="A"></param> n terms with size Ai
        /// <returns></returns>
        public int BackPack(int m, int[] A)
        {
            //dp[i][j]前i个物品塞入容量为j的背包最满有多满
            var dp = new int[m + 1];

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = m; j >= A[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - A[i]] + A[i]);
                }
            }
            return dp[m];
        }

        /// <summary>
        /// there are n items and a backpack with size m
        /// </summary>
        /// <param name="m"></param> the size of backpack
        /// <param name="A"></param> array A represents the size of each item A[i]
        /// <param name="V"></param> array V represents the value of each item V[i]
        /// <returns></returns> the maximum value put into the backpack
        public int BackPackII(int m, int[] A, int[] V)
        {
            int n = A.Length;
            int[] dp = new int[m + 1];
            ////f[j] = max{f[j], f[j-w[i]] + v[i]}
            for (int i = 0; i < n; i++)
            {                
                for (int j = m; j >= 0; j--)   // j >= V[i] XXX
                {
                    dp[j] = Math.Max(dp[j], j - A[i] >= 0 ? dp[j - A[i]] + V[i] : 0);
                }
            }
            return dp[m];            
        }





        /// <summary>
        /// Find the number of ways to fill the backpack
        /// Each item may be chosen unlimited number of times
        /// dp[i,j] : 使用前i个物品，当背包容量为j时，有dp[i,j]种方法，即，若只使用前i个物品，若想凑出容量为j，有dp[i,j]种方法。
        /// </summary>
        /// <param name="nums"></param> Give n items and an array, nums[i] indicate the size of i th item.
        /// <param name="target"></param> the size of backpack
        /// <returns></returns>
        public int BackPackIV(int[] nums, int target)
        {
            int n = nums.Length;
            var dp = new int[n + 1, target + 1];
            for(int i = 0; i <= n; i++)
            {
                dp[i, 0] = 1;
            }
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= target; j++)
                {
                    if(j - nums[i - 1] >= 0)
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - nums[i - 1]];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[n, target];
        }
        //Optimize
        public int BackPackIV_Up(int[] nums, int target)
        {
            int n = nums.Length;
            var dp = new int[target + 1];
            dp[0] = 1;
            for(int i = 0; i < n; i++)
            {
                for(int j = 1; j <= target; j++)
                {
                    dp[j] = dp[j] + dp[j - nums[i]];
                }
            }
            return dp[target];
        }

        /// <summary>
        /// Each item may only be used once
        /// </summary>
        /// <param name="nums"></param> Given n items with size nums[i] which an integer array and all positive numbers
        /// <param name="target"></param> integer target denotes the size of a backpack.
        /// <returns></returns> the number of possible fill the backpack.
        public int BackPackV(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var n = nums.Length;
            var dp = new int[target + 1];
            dp[0] = 1;
            for(var i = 1; i <= n; i++)
            {
                for(var j = target; j >= 0; j--)
                {
                    if (j - nums[i - 1] >= 0)
                        dp[j] = dp[j] + dp[j - nums[i - 1]];
                }
            }
            return dp[target];
        }




        /// <summary>
        /// DP
        /// </summary>
        /// <param name="n"></param> assume that you have n yuan
        /// <param name="prices"></param> the prices of rice[i]
        /// <param name="weight"></param> the weight of rice[i]
        /// <param name="amount"></param> the quantity of rice[i]
        /// <returns></returns> the maximun weight of rice that you can purchase
        public int BackPackVII(int n, int[] prices, int[] weight, int[] amounts)
        {
            int m = prices.Length;
            int[] dp = new int[n + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j <= amounts[i]; j++)
                {
                    for (int k = n; k >= prices[i]; k--)
                    {
                        dp[k] = Math.Max(dp[k], dp[k - prices[i]] + weight[i]);
                    }
                }
            }
            return dp[n];
        }
    } 
}
