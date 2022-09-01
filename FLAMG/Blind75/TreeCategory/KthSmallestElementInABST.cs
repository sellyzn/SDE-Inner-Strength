using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class KthSmallestElementInABST
    {
        // 230. Kth Smallest Element in a BST
        // 中序遍历
        int res, k;
        public int KthSmallest(TreeNode root, int k)
        {            
            this.k = k;
            Recursive(root);
            return res;
        }
        public void Recursive(TreeNode root)
        {
            if (root == null || k == 0)
                return;
            Recursive(root.left);
            if(--k == 0)
            {
                res = root.val;
                return;
            }
            Recursive(root.right);
        }

        // T: O(H + k), H是树的高度。在开始遍历之前，我们需要O(H)到达叶节点。当树是平衡树时，时间复杂度取得最小值O(logN + K); 当树是线性树时，时间复杂度取得最大值O(N + K)
        // S: O(H)，栈中最对需要存储H个元素。当树是平衡树时，空间复杂度取得最小值 O(logN)；当树是线性树时，空间复杂度取得最大值 O(N)。
        public int KthSmallestIterator(TreeNode root, int k)
        {
            var stack = new Stack<TreeNode>();
            while(root != null || stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                k--;
                if (k == 0)
                    break;
                root = root.right;
            }
            return root.val;
        }


        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var cur = root;
            while(cur != null || stack.Count > 0)
            {
                while(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                result.Add(cur.val);
                cur = cur.right;
            }
            return result;
        }


        //
        public int FindSecondMinimumValue(TreeNode root)
        {

        }
    }
}
