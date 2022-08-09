using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class SubarraySumsDivisibleByK
    {
        /// <summary>
        /// 通常涉及连续子数组的问题的时候，我们使用前缀和来解决
        /// P[i] = nums[0] + ... + nums[i]
        /// sum(i,j) = p[j] - P[i - 1]
        /// 判断子数组能否被k整除 <=> (P[j] - P[i - 1]) mod k == 0
        /// P[j] mod k == P[i - 1] mod k即可
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        
        /*
         nums:   [4,5,0,-2,-3,1]  k = 5

         preSum: [4,9,9,7,4,5]
        
        record: {{0,2}{4,4},{2,1}}
        result: 0 + 1 + 2 + 0 + 4 = 7

        nums: [-1,2,9], k = 2
        preSum:[-1,1,10]
        modulus: [-1,1,0]

        record:{{0,2},{1,2}}
        result: 0 + 1 + 1 = 2
         
         */
        public int SubarraysDivByK(int[] nums, int k)
        {            
            var record = new Dictionary<int, int>();
            record.Add(0, 1);
            int preSum = 0, result = 0;
            foreach (var num in nums)
            {
                preSum += num;
                int modulus = (preSum % k + k) % k;
                //int modulus = preSum % k;
                
                if (record.ContainsKey(modulus))
                {
                    result += record[modulus];
                    record[modulus]++;
                }
                else
                {
                    record.Add(modulus, 1);
                }
                 
            }
            return result;
        }
    }
}
