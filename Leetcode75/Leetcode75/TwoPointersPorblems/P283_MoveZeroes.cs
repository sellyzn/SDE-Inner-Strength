using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.TwoPointersPorblems
{
    internal class P283_MoveZeroes
    {
        /*
        方法一：双指针
        左指针控制非零位置，左指针左边均为非零数
        右指针控制零的位置，右指针左边到左指针处均为零。
        如果数组没有0，那么快慢指针始终指向同一个位置，每个位置自己和自己交换， 如果数组有0， 那么快指针先走一步，此时慢指针对应的就是0， 所以要交换。
        非0，交换数据，做右指针都往右移；0，右指针右移。
        时间：O(n)
        空间：O(1)
        方法二：覆盖，补0
        非零的从下标0添加，数组剩下位置都填0
         */
        public void MoveZeroes(int[] nums)
        {
            //方法一：双指针
            //int left = 0, right = 0;
            //while(right < nums.Length)
            //{
            //    if (nums[right] != 0)
            //    {
            //        var temp = nums[left];
            //        nums[left] = nums[right];
            //        nums[right] = temp;
            //        left++;
            //    }
            //    right++;
            //}

            //方法二：一个指针保存相对位置+覆盖+补0
            int index = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            for(int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
