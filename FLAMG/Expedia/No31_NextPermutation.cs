using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No31_NextPermutation
    {
        /// <summary>
        /// 分析：
        /// 1. 希望下一个数比当前数大：
        ///     将后面的大数与前面的小数交换，就能得到一个更大的数
        /// 2. 希望下一个数增加的幅度尽可能小：
        ///     在尽可能靠右的低位进行交换，需要从后向前查找
        ///     将一个尽可能小的大数与前面的小数交换
        ///     将大数换到前面后，需要将大数后面的所有数重置为升序，升序排列就是最小的排列。
        /// 算法：
        /// 1. 从后向前查找第一个相邻升序的元素对（i,j），满足A[i] < A[j]。此时[j,end)必然是降序
        /// 2. 在[j,end)从后向前查找第一个满足A[i] < A[k]的k。 A[i], A[k]分别就是上面说的小数，大数
        /// 3. 将A[i], A[k]交换
        /// 4. 可以判定这时[j,end)必然是降序，逆置[j,end)，使其升序
        /// 5. 如果在步骤1找不到符合的相邻元素对，说明当前[begin, en)为一个降序顺序，直接跳到步骤4.
        /// </summary>
        /// <param name="nums"></param>
        /// T: O(N)
        /// S: O(1)
        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;
            if(i >= 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[i] >= nums[j])
                    j--;
                Swap(nums, i, j);
            }
            Reverse(nums, i + 1);
        }
        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        public void Reverse(int[] nums, int start)
        {
            int left = start, right = nums.Length - 1;
            while(left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }
    }
}
