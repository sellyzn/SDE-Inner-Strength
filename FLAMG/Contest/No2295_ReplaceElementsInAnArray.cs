using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class No2295_ReplaceElementsInAnArray
    {
        public int[] ArrayChange(int[] nums, int[][] operations)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                for(int j = 0; j < operations.Length; j++)
                {
                    if(operations[j][0] == num)
                    {
                        nums[i] = operations[j][1];
                    }
                }
            }
            return nums;
        }
        public int[] ArrayChange_HashMap(int[] nums, int[][] operations)
        {
            var dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                dict.Add(nums[i], i);
            }
            for(int i = 0; i < operations.Length; i++)
            {
                if (dict.ContainsKey(operations[i][0]))     // 查询数组中是否拥有要替换的数字
                {
                    int index = dict[operations[i][0]];     // 获取nums的索引
                    nums[index] = operations[i][1];
                    dict[operations[i][1]] = index;
                }
            }
            return nums;
        }
    }
}
