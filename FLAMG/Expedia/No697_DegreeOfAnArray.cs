using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No697_DegreeOfAnArray
    {
        /// <summary>
        /// HashMap<int, int[]>()
        /// int[]为长度为3的数组，数组的三个元素分别代表这个数出现的次数，这个数在原数组中第一次出现的位置和这个数在原数组中最后一次出现的位置。
        /// 遍历哈希表，找到元素出现次数最多，且前后位置差最小的数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindShortestSubArray(int[] nums)
        {
            var map = new Dictionary<int, int[]>();
            int degree = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]][0]++;
                    map[nums[i]][2] = i;
                }
                else
                {
                    map.Add(nums[i], new int[] { 1, i, i });
                }
                degree = Math.Max(degree, map[nums[i]][0]);
            }

            int minLength = int.MaxValue;
            foreach (var item in map)
            {
                if (item.Value[0] == degree)
                    minLength = Math.Min(minLength, item.Value[2] - item.Value[1] + 1);
            }
            return minLength;
        }
    }
}
