using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No22GenerateParentheses
    {
        /// <summary>
        /// 如果左括号数量不大于 n，我们可以放一个左括号。如果右括号数量小于左括号的数量，我们可以放一个右括号。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O()
        /// S: O(n)
        public IList<string> GenerateParenthesis(int n)
        {
            var ans = new List<string>();
            Backtrack(ans, new StringBuilder(), 0, 0, n);
            return ans;
        }
        public void Backtrack(IList<string> ans, StringBuilder cur, int open, int close, int max)
        {
            if(cur.Length == max * 2)
            {
                ans.Add(cur.ToString());
                return;
            }
            if(open < max)
            {
                cur.Append('(');
                Backtrack(ans, cur, open + 1, close, max);
                cur.Remove(cur.Length - 1, 1);
            }
            if(close < open)
            {
                cur.Append(')');
                Backtrack(ans, cur, open, close + 1, max);
                cur.Remove(cur.Length - 1, 1);
            }
        }
    }
}
