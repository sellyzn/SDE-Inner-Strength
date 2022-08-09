using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No453_MinimumMovesToEqualArrayElements
    {
        /// <summary>
        /// 脑筋急转弯啊
        /// 每次操作即为使 n - 1 个元素增加1，也可以理解为使1个元素减少1。最后计算将数组中所有元素都减少到数组中元素最小值所需的操作数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int MinMoves(int[] nums)
        {
            int minNum = nums.Min();
            int res = 0;
            foreach(int num in nums)
            {
                res += num - minNum;
            }
            return res;
        }
    }
}
