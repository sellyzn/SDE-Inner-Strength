using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No6ZigzagConversion
    {
        /// <summary>
        /// r = numRows. 当r == 1(只有一行)或者r >= n(只有一列)的情况，return s.
        /// Z字形变化的周期 t = r + r - 2 = 2r - 2， 每个周期会占用矩阵的列数： 1 + r - 2 = r - 1列
        /// 周期个数： ⌈n / t⌉ ， 最后一个周期视为完整周期
        /// 矩阵列数: c = ⌈n / t⌉ * (r - 1), 矩阵列数 = 周期数*每个周期的列数
        /// 判断什么时候向下移动什么时候向上移动？
        /// 初始位置(x, y) = (0, 0)， 即矩阵左上角。 若当前字符下标i满足 i mod t < r - 1， 则向下移动，否则向上移动。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        /// T: O(r * n), r = numRows, n = s.Length
        /// S: O(r * n)
        public string Convert(string s, int numRows)
        {
            if (s == null || s.Length == 0)
                return "";
            int n = s.Length, r = numRows;
            if (r == 1 || n <= r)
                return s;
            //周期个数
            int t = r * 2 - 2;
            //矩阵总列数
            int c = (n + t - 1) / t * (r - 1);

            var mat = new char[r, c];

            for(int i = 0, x = 0, y = 0; i < n; i++)
            {
                mat[x,y] = s[i];
                if (i % t < r - 1)
                {
                    x++;
                }
                else
                {
                    x--;
                    y++;
                }
            }
            var res = new StringBuilder();
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    if(mat[i, j] != 0)
                        res.Append(mat[i, j]);
                }
            }
            return res.ToString();
        }
    }
}
