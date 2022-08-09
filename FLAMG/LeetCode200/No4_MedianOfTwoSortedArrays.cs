using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No4_MedianOfTwoSortedArrays
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            // Edge case
            if(m == 0)
            {
                if (n % 2 == 0)
                    return (double)(nums2[n / 2] + nums2[n / 2 - 1]) / 2;
                else
                    return nums2[n / 2];
            }else if(n == 0)
            {
                if (m % 2 == 0)
                    return (double)(nums1[m / 2] + nums1[m / 2 - 1]) / 2;
                else
                    return nums1[m / 2];
            }
            else
            {
                // 
                if ((m + n) % 2 == 0)
                {
                    int midIndex1 = (m + n) / 2 - 1, midIndex2 = (m + n) / 2;
                    double median = (double)(GetKthElement(nums1, nums2,midIndex1 + 1) + GetKthElement(nums1, nums2, midIndex2 + 1)) / 2;
                    return median;
                }
                else
                {
                    int midIndex = (m + n) / 2;
                    double median = GetKthElement(nums1, nums2, midIndex + 1);
                    return median;
                }
            }

            
        }
        public int GetKthElement(int[] nums1, int[] nums2, int k)
        {
            /* 主要思路：要找到第 k (k>1) 小的元素，那么就取 pivot1 = nums1[k/2-1] 和 pivot2 = nums2[k/2-1] 进行比较
             * 这里的 "/" 表示整除
             * nums1 中小于等于 pivot1 的元素有 nums1[0 .. k/2-2] 共计 k/2-1 个
             * nums2 中小于等于 pivot2 的元素有 nums2[0 .. k/2-2] 共计 k/2-1 个
             * 取 pivot = min(pivot1, pivot2)，两个数组中小于等于 pivot 的元素共计不会超过 (k/2-1) + (k/2-1) <= k-2 个
             * 这样 pivot 本身最大也只能是第 k-1 小的元素
             * 如果 pivot = pivot1，那么 nums1[0 .. k/2-1] 都不可能是第 k 小的元素。把这些元素全部 "删除"，剩下的作为新的 nums1 数组
             * 如果 pivot = pivot2，那么 nums2[0 .. k/2-1] 都不可能是第 k 小的元素。把这些元素全部 "删除"，剩下的作为新的 nums2 数组
             * 由于我们 "删除" 了一些元素（这些元素都比第 k 小的元素要小），因此需要修改 k 的值，减去删除的数的个数
             */

            
            int length1 = nums1.Length, length2 = nums2.Length;
            int index1 = 0, index2 = 0;
            int kthElement = 0;

            while (true)
            {
                // Edge Case
                if (index1 == length1)
                    return nums2[index2 + k - 1];
                if (index2 == length2)
                    return nums1[index1 + k - 1];
                if (k == 1)
                    return Math.Min(nums1[index1], nums2[index2]);

                // Common Case
                int half = k / 2;
                int newIndex1 = Math.Min(index1 + half, length1) - 1;
                int newIndex2 = Math.Min(index2 + half, length2) - 1;
                int pivot1 = nums1[newIndex1], pivot2 = nums2[newIndex2];
                if(pivot1 <= pivot2)
                {
                    k -= (newIndex1 - index1 + 1);
                    index1 = newIndex1 + 1;
                }
                else
                {
                    k -= (newIndex2 - index2 + 1);
                    index2 = newIndex2 + 1;
                }
            }
        }
              
        
    }
}
