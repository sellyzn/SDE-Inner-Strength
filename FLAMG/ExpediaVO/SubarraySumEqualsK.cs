using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class SubarraySumEqualsK
    {
        /// <summary>
        /// Prefix Sum + HashMap
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var prefixSum = new int[nums.Length + 1];
            var dict = new Dictionary<int, int>();
            prefixSum[0] = 0;
            dict.Add(0, 1);
            var count = 0;
            for(int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
                if(dict.ContainsKey(prefixSum[i] - k))
                    count += dict[prefixSum[i] - k];

                if (dict.ContainsKey(prefixSum[i]))
                    dict[prefixSum[i]]++;
                else
                    dict[prefixSum[i]] = 1;
            }
            return count;
        }
    }
}
