using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No45JumpGameII
    {
        /// <summary>
        /// Greedy
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// 
        /// 反向查找出发位置:
        /// 目标是到达数组的最后一个位置，因此可以考虑最后一步跳跃前所在的位置，该位置通过条约能够到达最后一个位置。
        /// 如果有多个位置通过跳跃都能到达最后一个位置，我们贪心地选择距离最后一个位置最远的那个位置，也就是对应下标最小的那个位置。因此，我们可以从左到右遍历数组，选择第一个满足要求的位置。
        /// 找到最后一步跳跃前所在的位置后，继续贪心地寻找倒数第二步跳跃前所在的位置，以此类推，知道找到数组的开始位置。
        /// T: O(N^2)
        /// S: O(1)
        /// 
        /// 正向查找可到达的最大位置
        /// T: O(N)
        /// S: O(1)
        /// 
        
        public int Jump_Start(int[] nums)
        {
            int position = nums.Length - 1;
            int steps = 0;
            while(position > 0)
            {
                for(int i = 0; i < position; i++)
                {
                    if(i + nums[i] >= position)
                    {
                        position = i;
                        steps++;
                        break;
                    }
                }
            }
            return steps;
        }
        
        public int Jump(int[] nums)
        {
            int n = nums.Length;
            int currentJumpEnd = 0;
            int farthest = 0;
            int steps = 0;
            for(int i = 0; i < n - 1; i++)
            {
                // we continuously find the how far we can reach in the current jump
                farthest = Math.Max(farthest, i + nums[i]);
                // if we have come to the end of the current jump, we need to make another jump
                if(i == currentJumpEnd)
                {
                    currentJumpEnd = farthest;
                    steps++;
                }
            }
            return steps;
        }
    }
}
