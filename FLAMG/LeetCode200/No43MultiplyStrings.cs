using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No43MultiplyStrings
    {
        /// <summary>
        /// 竖式加法模拟乘法， 两个字符串相加
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        /// T: O(mn + n^2)，m, n分别是num1, num2的长度。需要从左往右遍历num2， 对于num2的每一位都要和num1的每一位计算乘积， 因此计算乘积的总次数是mn。
        ///     字符串相加有n次。 相加的字符串长度最长位m + n， 因此字符串相加的时间复杂度位O(mn + n^2)。 总时间复杂度位O(mn + n^2)。
        /// S: O(m + n)
        public string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";
            string ans = "0";
            int len1 = num1.Length, len2 = num2.Length;
            for(int i = len2 - 1; i >= 0; i--)
            {
                var cur = new StringBuilder();
                int carry = 0;
                // 乘数第i位，后面都补0
                for(int j = len2 - 1; j > i; j--)
                {
                    cur.Append(0);
                }
                int y = num2[i] - '0';
                for(int j = len1 - 1; j >= 0; j--)
                {
                    int x = num1[j] - '0';
                    int product = x * y + carry;
                    cur.Insert(0, product % 10);
                    carry = product / 10;
                }
                if(carry != 0)
                {
                    cur.Insert(0, carry);
                }
                ans = AddStrings(ans, cur.ToString());
            }
            return ans;
        }
        public string AddStrings(string num1, string num2)
        {
            StringBuilder res = new StringBuilder();
            int i = num1.Length - 1, j = num2.Length - 1, carry = 0;
            while (i >= 0 || j >= 0)
            {
                int n1 = i >= 0 ? num1[i] - '0' : 0;
                int n2 = j >= 0 ? num2[j] - '0' : 0;

                int tmp = n1 + n2 + carry;
                carry = tmp / 10;
                res.Insert(0, tmp % 10);
                i--;
                j--;
            }
            if (carry == 1)
                res.Insert(0, 1);

            return res.ToString();
        }
    }
}
