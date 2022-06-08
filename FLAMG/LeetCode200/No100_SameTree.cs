using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No100_SameTree
    {
        /// <summary>
        /// Recursion
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        /// T: O(N), N is the number of nodes in the tree, since one visites each node exactly once.
        /// S: O(logN) is the best case of completed balanced tree and O(N) is the worst case of completely unbalanced tree, to keep a recursion stack.
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null)
                return false;
            if (q == null)
                return false;
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
