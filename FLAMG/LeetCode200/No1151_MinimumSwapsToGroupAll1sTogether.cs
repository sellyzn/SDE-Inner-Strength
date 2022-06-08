using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1151_MinimumSwapsToGroupAll1sTogether
    {
        /// <summary>
        /// Sliding Window + Two Pointers
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int MinSwaps(int[] data)
        {
            // calculate the number of 1
            // use a sliding window, whichi size is equal to the number of 1, to traverse the data array
            // find the max numbers of 1 in the sliding window
            // count - maxCount

            int count = 0;
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i] == 1)
                    count++;
            }
            int left = 0, right = 0;
            int maxCount = 0;
            var curCount = 0;
            while(right < data.Length)
            {
                while(right - left < count)
                {
                    if(data[right] == 1)
                    {
                        curCount++;
                    }
                    right++;
                }
                maxCount = Math.Max(maxCount, curCount);
                if (data[right] == 0 && data[left] == 1)
                    curCount--;
                else if(data[right] == 1 && data[left] == 0)
                    curCount++;
                maxCount = Math.Max(maxCount,curCount);
                right++;
                left++;                    
            }
            return count - maxCount;
        }
    }
}
