using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class No2293_MinMaxGame
    {
        public int MinMaxGame(int[] nums)
        {
            int length = nums.Length;
            int res = nums[0];
            while(length > 1)
            {
                var newNums = new int[length / 2];
                for(int i = 0; i < length / 2; i++)
                {
                    if (i % 2 == 0)
                        newNums[i] = Math.Min(nums[2 * i], nums[2 * i + 1]);
                    else
                        newNums[i] = Math.Max(nums[2 * i], nums[2 * i + 1]);
                }
                nums = newNums;
                length = newNums.Length;
                if (length == 1)
                    res = newNums[0];
            }
            return res;
        }
    }
}
