using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG
{
    internal class BinaryTreeLongestConsecutiveSequence
    {
        public int LongestConsecutive(TreeNode root)
        {
            //if (root == null)
            //    return 0;
            //var leftLength = 0;
            //var rightLength = 0;
            //var length = 1;
            //if(root.left == null)
            //{
            //    leftLength = 0;
            //}
            //else
            //{
            //    leftLength = root.left.val == root.val + 1 ? length + LongestConsecutive(root.left) : LongestConsecutive(root.left);
            //}
            //if(root.right == null)
            //{
            //    rightLength = 0;
            //}
            //else
            //{
            //    rightLength = root.right.val == root.val + 1 ? length + LongestConsecutive(root.right) : LongestConsecutive(root.right);
            //}
            //return Math.Max(leftLength, rightLength);
            int maxLength = 0;
            DFS(root, maxLength);
            return maxLength;
        }
        public int DFS(TreeNode root, int maxLength)
        {
            if (root == null)
                return 0;
            int L = DFS(root.left, maxLength) + 1;
            int R = DFS(root.right,maxLength) + 1;
            if (root.left != null && root.val + 1 != root.left.val)
                L = 1;
            if (root.right != null && root.val + 1 != root.right.val)
                R = 1;
            var length = Math.Max(L, R);
            maxLength = Math.Max(maxLength, length);
            return length;
        }
    }
}
