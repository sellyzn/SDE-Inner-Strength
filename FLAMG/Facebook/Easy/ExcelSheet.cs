using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Easy
{
    public class ExcelSheet
    {
        public string ConvertToTittle(int columnNumber)
        {
            var sb = new StringBuilder();
            while(columnNumber > 0)
            {
                columnNumber--;
                sb.Append((char)(columnNumber % 26 + 'A'));
                columnNumber /= 26;
            }
            int left = 0, right = sb.Length - 1;
            while(left < right)
            {
                char tmp = sb[left];
                sb[left] = sb[right];
                sb[right] = tmp;
                left++;
                right--;
            }
            return sb.ToString();
        }


        public int TittleToNumber(string columnTittle)
        {
            int res = 0;
            for (int i = 0; i < columnTittle.Length; i++)
            {
                int num = columnTittle[i] - 'A' + 1;
                res = res * 26 + num;
            }
            return res;
        }
    }
}
