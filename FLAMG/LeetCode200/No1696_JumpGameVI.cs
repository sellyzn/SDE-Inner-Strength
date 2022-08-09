using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1696_JumpGameVI
    {
        /// <summary>
        /// DP + Priority Queue
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O()
        /// S: o()
        /// 


        public int MaxResult(int[] nums, int k)
        {
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            var windowIndices = new Queue<int>();
            for(int i = 1; i < nums.Length; i++)
            {
                while(windowIndices.Count > 0 && dp[i - 1] >= dp[windowIndices.Peek()])
                {
                    windowIndices.Dequeue();
                }
                windowIndices.Enqueue(i - 1);



            }
        }

        //错误！！！
        public int MaxResult_Error(int[] nums, int k)
        {
            int n = nums.Length;
            int result = 0;
            if(k >= n)
            {
                for(int i = 0; i < n; i++)
                {
                    result += nums[i];
                }
                return result;
            }
            else
            {
                var dp = new int[n];
                dp[0] = nums[0];                
                for(int i = 1;i < n; i++)
                {
                    if(i - k >= 0)
                    {
                        dp[i] = Math.Max(dp[i - 1], dp[i - k]) + nums[i];
                    }
                    else
                    {
                        dp[i] = dp[i - 1] + nums[i];
                    }
                    result = Math.Max(result, dp[i]);
                }
                return result;
            }
        }
    }
}
