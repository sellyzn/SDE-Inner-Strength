using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P345_ReverseVowelsOfAString
    {
        /*
        双指针
        vowelsSet要包含大小写元音字符
        注意字符串s不可更改，将字符串转化为数组，s.ToCharArray()
        两个指针分别只想字符串的初始位置和末尾位置，向中间移动，两者都遇到元音字符，交换
        返回新的字符串，new string(arr)
        time: O(n)
        space: O(n)
         */
        public string ReverseVowels(string s)
        {
            var vowelsSet = new HashSet<char>();
            vowelsSet.Add('a');
            vowelsSet.Add('e');
            vowelsSet.Add('i');
            vowelsSet.Add('o');
            vowelsSet.Add('u');
            vowelsSet.Add('A');
            vowelsSet.Add('E');
            vowelsSet.Add('I');
            vowelsSet.Add('O');
            vowelsSet.Add('U');
            var arr = s.ToCharArray();
            int left = 0, right = s.Length - 1;
            while(left <= right)
            {
                while(left <= right && !vowelsSet.Contains(s[left]))
                {
                    left++;
                }
                while(left <= right && !vowelsSet.Contains(s[right]))
                {
                    right--;
                }
                if(left <= right)
                {
                    arr[left] = s[right];
                    arr[right] = s[left];
                    left++;
                    right--;
                }
            }
            return new string(arr);
        }
    }
}
