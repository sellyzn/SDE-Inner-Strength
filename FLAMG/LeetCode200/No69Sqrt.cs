using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No69Sqrt
    {
        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// T: O(logN)
        /// S: O(1)
        /// Note: num = (long) mid * mid; we should transform to long
        /// 最后返回的是right。比如pow(3)，返回1.
        public int MySqrt(int x)
        {
            if (x < 2)
                return x;
            long num;
            int left = 2, right = x / 2;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                num = (long)mid * mid;
                if(num == x)
                    return mid;
                else if(num < x)
                    left = mid + 1;
                else if(num > x)
                    right = mid - 1;
            }
            return right;
        }
    }
}
