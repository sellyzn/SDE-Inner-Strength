using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No129_SumRootToLeafNumbers
    {
        /// <summary>
        /// Backtrack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        int result = 0;
        StringBuilder path = new StringBuilder();
        public int SumNumbers(TreeNode root)
        {
            Backtrack(root);
            return result;
        }
        public void Backtrack(TreeNode root)
        {
            if (root == null)
                return;
            path.Append(root.val);
            if(root.left == null && root.right == null)
            {
                result += int.Parse(path.ToString());
            }
            Backtrack(root.left);
            Backtrack(root.right);
            path.Remove(path.Length - 1, 1);
        }
    }
}
