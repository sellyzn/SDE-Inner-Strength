using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1TwoSum
    {
        // Dictionary
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            var res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    res[0] = dict[diff];
                    res[1] = i;
                    return res;
                }
                else
                    dict[nums[i]] = i;          // dict.Add(nums[i], i)  error--> [1,1,1,1,4,1,1,1,7,1,1,1,1], 11
            }
            return res;
        }
        // T: O(N)， N is the length of nums, we use a for loop to traverse the array nums, so the time complexity is O(N)
        // S: O(N), N is the length of nums, we use a dictionary to store the key-value pair, the largest size is N - 1
    }
}
