using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P605_CanPlaceFlowers
    {
        /*
        贪心
        [0], [0,0,1],[1,0,0],[1,0,0,0,0,1]
        考虑corner case: [0]
        定义初始指针index，遍历一遍数组flowerbed
        [0,0,1]类： 
            index+2<flowerbed.Length && flowerbed[index]==flowerbed[index+1]==0 && flowerbed[index+2]==1: n--,index +=2.
        普通类：
            当flowerbed[index]值为1时（注意index在有效范围内），移动index，即index++。
            当flowerbed[index] == flowerbed[index+1] == flowerbed[index+2] == 0时，说明可以放一株新的花，index向右移动2个位置，即index += 2， 同时n--。
        [1，0，0]类：
            判断边界情况，当index+2 == flowerbed.Length时，如果flowerbed[index] == flowerbed[index+1] == 0, 说明可以在最后一个位置放入一株新的花，n--。
        如果上述几种情况都不符合，移动index，index++。
        循环结束后，如果n<=0， 即可以放入n株花，则返回true，否则，返回false。
         */
        public bool CanPlaceFlowers0(int[] flowerbed, int n)
        {
            //if(flowerbed.Length == 1 && flowerbed[0] == 0 && n <= 1)
            //{
            //    return true;
            //}
            //int index = 0;
            //while (index < flowerbed.Length)
            //{
            //    // [0，0，1]
            //    if (index + 2 < flowerbed.Length && flowerbed[index] == 0 && flowerbed[index + 1] == 0 && flowerbed[index + 2] == 1)
            //    {
            //        n--;
            //        index += 2;                    
            //    }
            //    while (index < flowerbed.Length && flowerbed[index] == 1)
            //    {
            //        index++;
            //    }                
            //    while (index + 2 < flowerbed.Length && flowerbed[index] == 0 && flowerbed[index + 1] == 0 && flowerbed[index + 2] == 0)
            //    {
            //        n--;
            //        index += 2;                    
            //    }
            //    //[1,0,0] ([0,0]也可以归为这类)
            //    if (index + 2 == flowerbed.Length && flowerbed[index] == 0 && flowerbed[index + 1] == 0)
            //    {
            //        n--;
            //    }                
            //    index++;
            //}
            //if (n <= 0)
            //{
            //    return true;
            //}
            //return false;
            int len = flowerbed.Length;
            for(int i = 0; i < len; i++)
            {
                if((i == 0 || flowerbed[i - 1] == 0) && flowerbed[i] == 0 && (i == len - 1 || flowerbed[i + 1] == 0))
                {
                    n--;
                    i++; // 下一个位置肯定不能种花
                }
            }
            return n <= 0;
        }

        /*
        从左到右遍历数组，能种花就立即种花。
        如果要在下标i处种花，需要满足flowerbed[i-1] == flowerbed[i] == flowerbed[i+1] == 0.
        每种一朵花，就把n减一。如果最后n<=0，则返回true,否则返回false。
         */
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int len = flowerbed.Length;
            for (int i = 0; i < len; i++)
            {
                if ((i == 0 || flowerbed[i - 1] == 0) && flowerbed[i] == 0 && (i == len - 1 || flowerbed[i + 1] == 0))
                {
                    n--;
                    i++; // 下一个位置肯定不能种花
                }
            }
            return n <= 0;
        }
    }
}
