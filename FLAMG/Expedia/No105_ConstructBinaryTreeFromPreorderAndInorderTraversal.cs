using FLAMG.LeetCode200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No105_ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        /// <summary>
        /// Recursion
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        public TreeNode Build(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd)
                return null;
            int rootValue = preorder[inStart];
            var root = new TreeNode(rootValue);
            int index = inStart;
            for(int i = inStart; i <= inEnd; i++)
            {
                if(inorder[i] == rootValue)
                {
                    index = i;
                    break;
                }
            }
            int leftLength = index - inStart;
            root.left = Build(preorder, preStart + 1, preStart + leftLength, inorder, inStart, index - 1);
            root.right = Build(preorder, preStart + leftLength + 1, preEnd, inorder, index + 1, inend);
            return root;
        }
    }
}
