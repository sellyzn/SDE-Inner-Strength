using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class MinLengghSubArrayContainsKDistinctInteger
    {
        public int MinLengthSubarray(int[] arr, int k)
        {
            if (arr.Length < k)
                return -1;
            var window = new Dictionary<int, int>();
            int left = 0, right = 0;
            int minLength = int.MaxValue;
            while(right < arr.Length)
            {
                var num = arr[right];
                right++;
                if (window.ContainsKey(num))
                    window[num]++;
                else
                    window[num] = 1;

                while(window.Count == k)
                {
                    minLength = Math.Min(minLength, right - left);
                    var delNum = arr[left];
                    left++;
                    if (window[delNum] > 1)
                        window[delNum]--;
                    else if(window[delNum] == 1)
                        window.Remove(delNum);
                }
            }
            return minLength == int.MaxValue ? -1 : minLength;
        }
    }
}
