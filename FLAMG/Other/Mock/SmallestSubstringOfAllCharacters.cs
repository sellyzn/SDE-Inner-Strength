using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Other.Mock
{
    internal class SmallestSubstringOfAllCharacters
    {
        public string GetShotestUniqueSubstring(char[] arr, string str)
        {
            //your code goes here
            //input:  arr = ['x','y','z'], str = "xyyzyzyx"

            //output: "zyx"
            // str : "xyyzyzyx"
            // i: 0, str.Length - 1
            // j : 0, str.Length - 1;
            // i : 0 1 2 3 4 5 6
            // j:  3  7 7 7 7 7 7
            // subLen: 4 8 6 5 3  
            // left: 0
            // right : 0

            var arrLength = arr.Length;
            var strLength = str.Length;
            if (strLength < arrLength)
                return "";

            int left = 0, right = 0;
            var dict = new Dictionary<char, int>();
            var minSubStr = str;
            var curSubStr = "";
            while (left < strLength && right < strLength)
            {

                if (dict.Count < arrLength)
                {
                    curSubStr = str.Substring(left, right - left + 1);
                    if (dict.ContainsKey(str[right]))
                        dict[str[right]]++;
                    else
                        dict.Add(str[right], 1);
                    right++;
                }
                else
                {
                    minSubStr = minSubStr.Length < curSubStr.Length ? minSubStr : curSubStr;
                    var charLeft = str[left];
                    if (dict[charLeft] > 1)
                    {
                        dict[charLeft]--;
                    }
                    else
                    {
                        dict.Remove(charLeft);
                    }
                    left++;
                    curSubStr = str.Substring(left, right - left + 1);
                }
            }
            return minSubStr;
        }
        //static void Main(string[] args)
        //{
        //    var arr = new char[] { 'x', 'y', 'z' };
        //    var str = "xyyzyzyx";
        //    var result = Solution.GetShortestUniqueSubstring(arr, str);
        //    Console.WriteLine(result);
        //}
    }
}
