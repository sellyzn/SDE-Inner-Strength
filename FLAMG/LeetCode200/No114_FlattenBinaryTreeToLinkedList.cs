using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No114_FlattenBinaryTreeToLinkedList
    {
        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="root"></param>
        /// T: O(N)
        /// S: O(N)
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            Flatten(root.left);
            Flatten(root.right);
            var left = root.left;
            var right = root.right;
            root.left = null;
            root.right = left;
            var cur = root;
            while(cur.right != null)
                cur = cur.right;
            cur.right = right;            
        }
    }
}
