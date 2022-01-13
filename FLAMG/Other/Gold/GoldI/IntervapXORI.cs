using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldI
{
    public class IntervapXORI
    {
        public IList<int> IntervalXOR(int[] arr, int[][] query)
        {
            int n = arr.Length;
            int[] xors = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                xors[i + 1] = xors[i] ^ arr[i];
            }
            int m = query.Length;
            int[] ans = new int[m];
            for (int i = 0; i < m; i++)
            {
                ans[i] = xors[query[i][0]] ^ xors[query[i][1] + 1];
            }
            return ans;
        }
        public IList<int> IntervalXORII(int[] nums, List<int[]> query)
        {

            var res = new List<int>();
            foreach (var q in query)
            {
                
                int start = q[0], end = q[1];
                int ans = nums[start];
                for(int i = start + 1; i < start + end; i++)
                {
                    ans ^= nums[i];
                }
                res.Add(ans);
            }
            return res;
        }
    }
}
