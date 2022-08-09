using FLAMG.LeetCode200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No889_ConstructBinaryTreeFromPreorderAndPostorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] postorder)
        {
            return Build(preorder, 0, preorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        public TreeNode Build(int[] preorder, int preStart, int preEnd, int[] postorder, int postStart, int postEnd)
        {
            if (preStart > preEnd)
                return null;
            int rootValue = preorder[preStart];
            var root = new TreeNode(rootValue);
            if (preStart == preEnd)
                return root;
            int leftRootValue = preorder[preStart + 1];
            int index = postStart;
            for(int i = postStart; i <= postEnd; i++)
            {
                if(postorder[i] == leftRootValue)
                {
                    index = i;
                    break;
                }
            }
            int leftLength = index - postStart + 1;
            root.left = Build(preorder, preStart + 1, preStart + leftLength, postorder, postStart, postStart + leftLength - 1);
            root.right = Build(preorder, preStart + leftLength + 1, preEnd, postorder, postStart + leftLength, postEnd - 1);
            return root;
        }
    }
}
