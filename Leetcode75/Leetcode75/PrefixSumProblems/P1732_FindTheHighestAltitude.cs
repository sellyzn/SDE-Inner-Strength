using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.PrefixSumProblems
{
    internal class P1732_FindTheHighestAltitude
    {
        /*
        Prefix Sum
        时间：O(n)
        空间:O(n)
        */
        public int LargestAltitude(int[] gain)
        {
            var prefixSum = new int[gain.Length + 1];
            prefixSum[0] = 0;
            var highest = prefixSum[0];
            for(var i = 1; i <= gain.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + gain[i - 1];
                highest = Math.Max(highest, prefixSum[i]);
            }
            return highest;
        }
    }
}
