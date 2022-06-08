using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No105_ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N), 考虑递归栈空间和存储空间
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        public TreeNode BuildTree(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd)
                return null;
            int rootValue = preorder[preStart];
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
            root.left = BuildTree(preorder, preStart + 1, preStart + leftLength, inorder, inStart, index - 1);
            root.right = BuildTree(preorder, preStart + leftLength + 1, preEnd, inorder, index + 1, inEnd);
            return root;
        }
    }
}
