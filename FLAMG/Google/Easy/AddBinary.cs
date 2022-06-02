using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Google.Easy
{
    public class AddBinary
    {
        public string AddBinarySum(string a, string b)
        {
            // sum, carry
            //if (a == null || a.Length == 0)
            //    return b;
            //if (b == null || b.Length == 0)
            //    return a;
            //var lenA = a.Length;
            //var lenB = b.Length;
            //var len = lenA > lenB ? lenB : lenA;

            //for(int i = lenA - 1; i >= lenA - len; i--)
            //{
            //    var sum = a[i] ^ b[i] ;
            //    var carry = a[i] & b[i] << 1;
            //}
            //if
            if (a == null || a.Length == 0)
                return b;
            if (b == null || b.Length == 0)
                return a;
            var sb = new StringBuilder();
            var carry = 0;
            for(int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int sum = carry;
                sum += i >= 0 ? a[i] - '0' : 0;
                sum += j >= 0 ? b[j] - '0' : 0;
                sb.Insert(0, sum % 2);
                carry = sum / 2;
            }
            if (carry == 1)
                sb.Insert(0, carry);
            //int left = 0, right = sb.Length - 1;
            //while(left < right)
            //{
            //    var tmp = sb[left];
            //    sb[left] = sb[right];
            //    sb[right] = tmp;
            //    left++;
            //    right--;
            //}
            return sb.ToString();
        }
    }
}
