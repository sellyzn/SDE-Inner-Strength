using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No106_ConstructBinaryTreeFromInorderAndPostorderTraversal
    {
        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return Build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        public TreeNode Build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
        {
            if (inStart > inEnd)
                return null;
            int rootValue = postorder[postEnd];
            int index = inStart;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootValue)
                    index = i;
            }
            int leftLength = index - inStart;
            TreeNode root = new TreeNode(rootValue);
            root.left = Build(inorder, inStart, index - 1, postorder, postStart, postStart + leftLength - 1);
            root.right = Build(inorder, index + 1, inEnd, postorder, postStart + leftLength, postEnd - 1);
            return root;
        }
    }
}
