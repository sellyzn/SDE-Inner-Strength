using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class LongestSubstringWithoutRepeatingCharacters
    {
        // 3. Longest Substring Without Repeating Characters
        // Sliding Window + HashMap
        /*
         * [l, r)
         * window.Count < r - l, move forward l
         * window.Count == r - l, update maxLength
            l
        s: abcabcbb
               r
        window:{{a,1}, {b,1}, {c, 1}}
        curLen = r - l = 3
        maxLen:3

         */
        public int LengthOfLongestSubstring(string s)
        {
            if(s == null || s.Length == 0)
                return 0;
            var window = new Dictionary<char, int>();
            int left = 0, right = 0;
            var maxLength = 0;            
            while(right < s.Length)
            {
                var ch = s[right];
                right++;
                if (window.ContainsKey(ch))
                    window[ch]++;
                else
                    window[ch] = 1;
                while(window.Count < right - left)
                {
                    var del = s[left];
                    left++;
                    if(window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
                maxLength = Math.Max(maxLength, right - left);
            }
            return maxLength;
        }

        // 159. Longest Substring with At Most Two Distinct Characters
        // Sliding Window + HashMap
        /*
         * [l, r)
         * window.Count > 2, move forward l
         * window.Count == 2, update maxLen
           l
        s: eceba
           r

        window:{}
        curLen = r - l = 
        maxLen:

         */
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            var window = new Dictionary<char, int>();
            int left = 0, right = 0;
            var maxLength = 0;
            while(right < s.Length)
            {
                var ch = s[right];
                right++;
                if (window.ContainsKey(ch))
                    window[ch]++;
                else
                    window[ch] = 1;
                while(window.Count > 2)
                {
                    var del = s[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
                maxLength = Math.Max(maxLength, right - left);
            }
            return maxLength;
        }

        // 340. Longest Substring with At Most K Distinct Characters

        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (s == null || s.Length == 0)
                return 0;
            var window = new Dictionary<char, int>();
            int left = 0, right = 0;
            var maxLength = 0;
            while (right < s.Length)
            {
                var ch = s[right];
                right++;
                if (window.ContainsKey(ch))
                    window[ch]++;
                else
                    window[ch] = 1;
                while (window.Count > k)
                {
                    var del = s[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
                maxLength = Math.Max(maxLength, right - left);
            }
            return maxLength;
        }

        // 992. Subarrays with K Different Integers

        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            return GetMostKDistinct(nums, k) - GetMostKDistinct(nums, k - 1);
        }
        // 最多存在K个不同整数的子区间的个数
        public int GetMostKDistinct(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var window = new Dictionary<int, int>();
            int left = 0, right = 0;
            //var maxLength = 0;
            var count = 0;
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
                //maxLength = Math.Max(maxLength, right - left);
                /*
                双指针算法是在左边界固定的前提下让右边界走到最右边。
                所有的左边界固定的前提下，根据右边界的下标，计算出来的子区间的个数就是整个函数要返回的值。
                例如：最多包含3中不同整数的子区间[1,3,2,3]，当前可以确定1开始的满足最多包含3中不同整数的
                子区间有[1], [1,3], [1,3,2], [1,3,2,3]。就是right - left的值。
                 */
                count += right - left;
            }
            return count;
        }

        


    }
}
