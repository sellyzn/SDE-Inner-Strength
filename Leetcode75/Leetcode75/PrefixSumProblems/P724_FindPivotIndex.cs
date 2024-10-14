using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.PrefixSumProblems
{
    internal class P724_FindPivotIndex
    {
        /*
        prefix sum:
        计算出所有元素的总和totalSum
        为节省空间，定义一个变量sum，表示前i个元素的和。在下面的遍历中不断更新此值。
        遍历数组，若找到 2 * sum + nums[i] == totalSum，则找到了nums[i]前边的所有元素和与后面的所有元素和相等，返回i。
        若遍历完后仍未找到这样的i， 则返回-1.
        时间：O(n)
        空间：O(1)
        */
        public int PivotIndex(int[] nums)
        {
            var totalSum = 0;
            foreach (var num in nums)
            {
                totalSum += num;
            }
            var sum = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                if(2 * sum + nums[i] == totalSum)
                {
                    return i;
                }
                sum += nums[i];
            }
            return -1;
        }
    }
}
