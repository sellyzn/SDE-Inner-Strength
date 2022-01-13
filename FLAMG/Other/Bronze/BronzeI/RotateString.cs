using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeI
{
    public class RotateString
    {
        public void RotateStringI(char[] str, int offset)
        {
            if (str == null || str.Length == 0)
                return;
            offset = offset < str.Length ? offset : offset % str.Length;
            Reverse(str, 0, str.Length - 1);
            Reverse(str, 0, offset - 1);
            Reverse(str, offset, str.Length - 1);
            
        }
        public void Reverse(char[] str, int left, int right)
        {
            if (left >= right)
                return;
            while(left < right)
            {
                char tmp = str[left];
                str[left] = str[right];
                str[right] = tmp;
                left++;
                right--;
            }
        }
    }
}
