using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class SubarraysWithKDifferentIntegers
    {
        // Wrong answer:
        public int SubarrayWithKDistinctErr(int[] nums, int k)
        {            
            var window = new Dictionary<int, int>();
            int left = 0, right = 0;
            int count = 0;
            while(right < nums.Length)
            {
                if (window.Count == k)
                    count++;
                var num = nums[right];
                right++;
                if (window.ContainsKey(num))
                    window[num]++;
                else
                    window[num] = 1;
                               

                while(window.Count > k)
                {
                   
                    var del = nums[left];
                    left++;
                    if (window[del] > 1)
                        window[del]++;
                    else
                        window.Remove(del);
                }
            }
            return count;
        }


        public int SubarrayWithKDistinct(int[] nums, int k)
        {
            return AtMostKDistinct(nums, k) - AtMostKDistinct(nums, k - 1);
        }
        /// <summary>
        /// 最左包含K个不同整数的子区间的个数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int AtMostKDistinct(int[] nums, int k)
        {
            var len = nums.Length;
            var freq = new int[len + 1];

            int left = 0;
            int right = 0;
            // [left, right)里不同整数的个数
            int count = 0;
            int res = 0;
            // [left, right)包含不同整数的个数小于等于k
            while(right < len)
            {
                if (freq[nums[right]] == 0)
                    count++;
                freq[nums[right]]++;
                right++;
                while(count > k)
                {
                    freq[nums[left]]--;
                    if (freq[nums[left]] == 0)
                        count--;
                    left++;
                }
                // 为什么用数组的长度[right - left]来表示增加的子数组个数呢？
                // 借鉴动态规划的思想：
                // 例如：当满足条件的组数组从[a,b,c]增加到[a,b,c,d]时，新子数组的长度为4，同时增加的子数组为[d],[c,d],[b,c,d],[a,b,c,d]也为4
                res += right - left;
            }
            return res;
        }
        public int GetMostDistinct(int[] nums, int k)
        {
            var window = new Dictionary<int, int>();
            int left = 0, right = 0, ret = 0;
            while(right < nums.Length)
            {
                var num = nums[right];
                right++;
                if (window.ContainsKey(num))
                    window[num]++;
                else
                    window[num] = 1;
                while(window.Count > k)
                {
                    var del = nums[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
                // 如果这里改成ret = max(ret, right - left),那么此函数就是leecode904题的解：求长度最大的子数组（此数组中包含不同整数个数最多为k）
                ret += right - left;
            }
            return ret;
        }
    }
}
