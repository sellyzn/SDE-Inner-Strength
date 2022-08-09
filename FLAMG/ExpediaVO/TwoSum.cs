using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class TwoSum
    {
        // a + b = k
        // a = k - b
        public int[] TwoSum1(int[] nums, int target)
        {
            int[] res = new int[2];
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int difference = target - nums[i];
                if (map.ContainsKey(difference))
                {
                    res[0] = map[difference];
                    res[1] = i;
                    return res;
                }
                else
                {
                    map.Add(nums[i], i);
                }
            }
            return res;
        }

        //follow up:532
        // a - b = k   ||  a + k = b
        /*
         nums: [1,3,1,5,4], k = 0;
        set:   [1,3,5,4]

         */

        public int FindPairTwoPointers(int[] nums, int k)
        {
            Array.Sort(nums);
            int left = 0, right = 1;
            int result = 0;
            while(left < nums.Length && right < nums.Length)
            {
                if (left == right || nums[right] - nums[left] < k)
                    right++;
                else if (nums[right] - nums[left] > k)
                    left++;
                else{
                    left++;
                    right++;
                    while (left < nums.Length && nums[left] == nums[left - 1])
                        left++;
                }
            }
            return result;
        }
        //hashmap
        public int FindPair(int[] nums, int k)
        {
            // a = k + b
            var result = 0;
            var counter = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if(counter.ContainsKey(num))
                    counter[num]++;
                else
                    counter[num] = 1;
            }
            foreach (var item in counter)
            {
                var x = item.Key;
                var val = item.Value;
                if(k > 0 && counter.ContainsKey(k + x))
                    result++;
                else if(k == 0 && val > 1)
                    result++;
            }
            return result;


            return result;
        }


        // follow up:
        // a + k * n = b
        // {1,2,3,4,5,6}, k = 2.返回：1,3  1,5  2,4  2,6  3,5  4,6 
        // a - b = k*n
        // (a - b) / k = n
        // (a - b) % k == 0
        public int TwoSumFollowUp(int[] nums, int k)
        {
            var count = 0;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] - nums[j]) % k == 0)
                        count++;
                }
            }
            return count;
        }
        public int TwoSumFollowUpOp(int[] nums, int k)
        {

        }



        // |a - b| = k





    }
}
