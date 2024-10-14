using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P334_IncreasingTripletSubsequence
    {
        /*
        1. 双向遍历
        nums[i] < nums[j] < nums[k], i < j < k 
        <==> 在数组nums中存在一个下标i满足1<=i<n，使得在nums[i]左边存在一个元素小于nums[i]，右边存在一个元素大于nums[i]。
        <==> nums[i]左边的最小元素小于nums[i]，右边的最大元素大于nums[i]。

        双向遍历，获得两个数组leftMin, rightMax.
        leftMin[i]: nums[0]到nums[i]中的最小值。
        rightMax[i]: nums[i]到nums[n-1]中的最大值。

        遍历数组，查找是否存在一个下标i，使得leftMin[i-1]<nums[i]<rightMax[i+1].
        时间：O(n)
        空间：O(n)

        2.贪心 (降低空间复杂度到O(1))
        从左到右遍历一次数组，遍历中维护两个变量first和second，分别表示递增的三元子序列中的第一个数和第二个数，任何时候都有first<second。
        初始赋值:first = nums{0]，second=int.MaxValue，找第三个数third。
        (1)如果third比second大，那就是找到了，直接返回true.
        (2)如果third比second小，但是比first大，那就把second只想third，继续遍历寻找third
        (3)如果third比first还小，那就把first指向third，然后继续遍历找third(这样的话first会跑到second后边，但是不要紧，引文在second的前面，老first还是满足的)
        时间：O(n)
        空间：O(1)

         */
        public bool IncreasingTriplet(int[] nums)
        {
            int n = nums.Length;
            if(n < 3)
            {
                return false;
            }
            //var leftMin = new int[n];
            //leftMin[0] = nums[0];
            //for(int i = 1; i < n; i++)
            //{
            //    leftMin[i] = Math.Min(leftMin[i - 1], nums[i]);
            //}
            //var rightMax = new int[n];
            //rightMax[n - 1] = nums[n - 1];
            //for(int i = n - 2; i >= 0; i--)
            //{
            //    rightMax[i] = Math.Max(rightMax[i + 1], nums[i]);
            //}
            //for(int i = 1; i < n - 1; i++)
            //{
            //    if (leftMin[i - 1] < nums[i] && nums[i] < rightMax[i + 1])
            //    {
            //        return true;
            //    }
            //}
            //return false;
            int first = nums[0], second = int.MaxValue;
            for(int i = 1; i < n; i++)
            {
                int num = nums[i];
                if (num > second)
                {
                    return true;
                }else if(num > first)
                {
                    second = num;
                }
                else
                {
                    first = num;
                }
            }
            return false;
        }
    }
}
