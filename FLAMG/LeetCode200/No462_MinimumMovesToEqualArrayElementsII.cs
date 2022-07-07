using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No462_MinimumMovesToEqualArrayElementsII
    {
        /// <summary>
        /// Sorting
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(NlogN)
        /// S: O(logN)
        public int MinMoves2(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length, ret = 0, x = nums[n / 2];
            for(int i = 0; i < n; i++)
            {
                ret += Math.Abs(nums[i] - x);
            }
            return ret;
        }
        
        /// <summary>
        /// Quick Selection
        /// </summary>
        /// x取nums第[n/2]小元素（从0开始计数）时，所需要的移动数量最少。
        /// 求数组中第K小元素，使用快速选择法
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N), 快速选择算法的平均时间复杂度位O(N)
        /// S: O(logN)， 递归栈的平均占用空间位O(logN)
        public int MinMoves2_QuickSelection(int[] nums)
        {
            int n = nums.Length, ret = 0, x = QuickSelect(nums, 0, n - 1, n / 2);
            for (int i = 0; i < n; i++)
            {
                ret += Math.Abs(nums[i] - x);
            }
            return ret;
        }
        public int QuickSelect(int[] nums, int left, int right, int k)
        {
            int q = Partition(nums, left, right);
            if(q == k)
            {
                return nums[q];
            }
            else
            {
                return q < k ? QuickSelect(nums, q + 1, right, k) : QuickSelect(nums, left, q - 1, k);
            }
        }
        public int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            int l = left, r = right + 1;
            while (true)
            {
                while (++l <= right && nums[l] < pivot) ;
                while(--r >= left && nums[r] > pivot) ;
                if(l < r)
                {
                    Swap(nums, l, r);
                }
                else
                {
                    break;
                }
            }
            nums[left] = nums[r];
            nums[r] = pivot;
            return r;
            
        }
        public void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
    }
}
