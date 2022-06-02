using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No88MergeSortedArray
    {
        /// <summary>
        /// Three pointers => merge sort
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        /// T: O(m + n), we are performing n + 2 * m reads and n + 2 * m writes.
        /// S: O(m), we are allocating an additional array of length m.
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {            
            int i = m - 1, j = n - 1, k = m + n - 1;
            while(i >= 0 && j >= 0)
            {
                if(nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
            }
            while(j >= 0)
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }
        }
    }
}
