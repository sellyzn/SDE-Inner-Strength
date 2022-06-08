using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No128_LongestConsecutiveSequence
    {
        /// <summary>
        /// HashSet
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int LongestConsecutive(int[] nums)
        {
            var numSet = new HashSet<int>();
            foreach (var num in nums)
            {
                numSet.Add(num);
            }
            int longestStreak = 0;
            foreach (var num in nums)
            {
                if(!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;
                    while(numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }
    }
}
