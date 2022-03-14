using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class LongestValidParentheses
    {
        //
        // DP
        // dp[i]: the lenght of longest valid parentheses ending with subscript i character以下标i字符结尾的最长有效括号的长度
        // 
        //        s[i]           dp[i]
        // 1)   ""                0
        // 2)   "......("         0
        // 3)   ".....()"         dp[i - 2] + 2       (s[i - 1] == '(' && s[i] = ')' &&  i - 2 >= 0 )
        // 4)   ".....))"         dp[i - 1] + 2 + dp[i - dp[i - 1] - 2]        ( s[i - 1] == '(' && s[i] = ')' && i - dp[i - 1) - 2 >= 0)
        //
        //       i-dp[i-1]-1   i
        //           ||       ||
        //           \/       \/
        //     0  1  2  3  4  5
        //     (  )  (  (  )  )
        // dp  0  2  0  0  2  dp[i] = dp[i - 1] + 2 + dp[i - dp[i - 1] - 2] = 2 + 2 + 2 = 6

        public int LongestValidParentheses_DP(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            //dp[i]: the lenght of longest valid parentheses ending with subscript i character以下标i字符结尾的最长有效括号的长度
            var dp = new int[s.Length];
            var maxLength = 0;
            dp[0] = 0;
            for(int i = 1; i < s.Length; i++)
            {
                if(s[i] == ')')
                {
                    if (s[i - 1] == '(')
                        //dp[i] = dp[i - 2] + 2;
                        dp[i] = (i - 2 >= 0 ? dp[i - 2] : 0) + 2;    //注意i-2的范围，不要OutOfIndex. 
                    else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                        //dp[i] = dp[i - 1] + 2 + dp[i - dp[i - 1] - 2];
                        dp[i] = dp[i - 1] + ((i - dp[i - 1] - 2) >= 0 ? dp[i - dp[i - 1] - 2] : 0) + 2;  //注意 i - dp[i-1] - 2的范围，不要OutOfIndex

                    //if (s[i - 1] == '(' && i - 2 >= 0)
                    //    dp[i] = dp[i - 2] + 2;
                    //else if (s[i - 1] == ')' && i - dp[i - 1] - 2 >= 0)
                    //    dp[i] = dp[i - 1] + 2 + dp[i - dp[i - 1] - 2];
                    //else
                    //    dp[i] = 0;
                }                
                maxLength = Math.Max(maxLength, dp[i]);
            }
            return maxLength;
        }
    }
}
