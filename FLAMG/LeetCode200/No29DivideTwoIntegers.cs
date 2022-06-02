using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No29DivideTwoIntegers
    {
        /// <summary>
        /// X / Y = Z ==> Z * Y <= X < (Z + 1) * Y, 二分查找，找出最大的Z使得 Z * Y >= X
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            //考虑被除数为最小值的情况
            if(dividend == int.MinValue)
            {
                if(divisor == 1)
                {
                    return int.MinValue;
                }
                if(divisor == -1)
                {
                    return int.MaxValue;
                }
            }
            // 考虑除数为最小值的情况
            if(divisor == int.MinValue)
            {
                return dividend == int.MinValue ? 1 : 0;
            }
            //考虑被除数为0的情况
            if(dividend == 0)
            {
                return 0;
            }

            //一般情况，使用二分查找
            //将所有的正数取相反数，这样就只需要考虑一种情况
            bool rev = false;
            if(dividend > 0)
            {
                dividend = -dividend;
                rev = !rev;
            }
            if(divisor > 0)
            {
                divisor = -divisor;
                rev = !rev;
            }

            int left = 1, right = int.MaxValue, ans = 0;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                bool check = QuickAdd(divisor, mid, dividend);
                if (check)
                {
                    ans = mid;
                    if (mid == int.MaxValue)
                        break;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }

            }
            return rev ? -ans : ans;
        }
        //快速乘
        public bool QuickAdd(int y, int z, int x)
        {

        }
    }
}
