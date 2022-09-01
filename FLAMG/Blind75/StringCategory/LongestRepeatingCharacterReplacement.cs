using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class LongestRepeatingCharacterReplacement
    {
        // 424. Longest Repeating Character Replacement
        // 
        // right - left在整个过程是非递减的。
        // 只要right 的值加进去不满足条件，left和right就一起右滑，
        // 因为长度小于right - left的区间就没必要考虑了，所以right - left一直保持为当前的最大值

        /* 双指针
              l
        s: AABABBA, K = 1
                 r
               A B C D E F G H I J K L M N O P Q R S T U V W X Y Z
        nums: [2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
        maxn: 3
        
         */
        public int CharacterReplacement(string s, int k)
        {
            var nums = new int[26];
            int n = s.Length;
            int maxn = 0;
            int left = 0, right = 0;
            while(right < n)
            {
                nums[s[right] - 'A']++;
                maxn = Math.Max(maxn, nums[nums[right] - 'A']);
                if(right - left + 1 - maxn > k)
                {
                    nums[s[left] - 'A']--;
                    left++;
                }
                right++;
            }
            return right - left;
        }

        // Sliding Window
        public int CharacterReplacement1(string s, int k)
        {
            var window = new Dictionary<char, int>();
            int maxn = 0;
            var maxLen = 0;
            int left = 0, right = 0;
            while(right < s.Length)
            {
                var ch = s[right];
                right++;
                if(window.ContainsKey(ch))
                    window[ch]++;
                else
                    window[ch] = 1;
                maxn = Math.Max(maxn, window[ch]);
                while(right - left - maxn > k)
                {
                    var del = s[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
                maxLen = Math.Max(maxLen, right - left);
            }
            return maxLen;
        }

        // 1004. Max Consecutive Ones III
        // 将0翻转为1，最多翻转k次，求连续1的最大长度
        public int LongestOnesIII(int[] nums, int k)
        {
            var window = new Dictionary<int, int>();
            int countOne = 0;
            int maxLen = 0;
            int left = 0, right = 0;
            while(right < nums.Length)
            {
                var num = nums[right];
                right++;
                if(window.ContainsKey(num))
                    window[num]++;
                else
                    window[num] = 1;
                if (num == 1)
                    countOne++;
                while(right - left - countOne > k)
                {
                    var del = nums[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                    if(del == 1)
                        countOne--;
                }
                maxLen = Math.Max(maxLen, right - left);
            }
            return maxLen;
        }

        // 487. Max Consecutive Ones II
        public int LongestOnesII(int[] nums, int k)
        {
            var window = new Dictionary<int, int>();
            int countOne = 0;
            int maxLen = 0;
            int left = 0, right = 0;
            while (right < nums.Length)
            {
                var num = nums[right];
                right++;
                if (window.ContainsKey(num))
                    window[num]++;
                else
                    window[num] = 1;
                if (num == 1)
                    countOne++;
                while (right - left - countOne > 1)
                {
                    var del = nums[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                    if (del == 1)
                        countOne--;
                }
                maxLen = Math.Max(maxLen, right - left);
            }
            return maxLen;
        }

        // 485. Max Consecutive Ones
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if(nums == null || nums.Length == 0)
                return 0;
            int left = 0, right = 0;
            var maxLen = 0;
            while(left < nums.Length)
            {
                while (right < nums.Length && nums[right] == 0)
                    right++;
                left = right;
                while (right < nums.Length && nums[right] == 1)
                    right++;
                maxLen = Math.Max(maxLen, right - left);
            }
            return maxLen;
        }
    }
}
