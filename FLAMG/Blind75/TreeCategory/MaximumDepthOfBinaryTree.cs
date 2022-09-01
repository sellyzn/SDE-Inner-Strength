using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class MaximumDepthOfBinaryTree
    {
        // 104. Maximum Depth of Binary Tree
        // BFS
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var maxDepth = 0;
            while (queue.Count > 0)
            {
                var length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                maxDepth++;
            }
            return maxDepth;
        }

        // 111. Minimum Depth of Binary Tree
        // BFS
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var minDepth = 1;
            while (queue.Count > 0)
            {
                var curLength = queue.Count;
                for (int i = 0; i < curLength; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left == null && node.right == null)
                        return minDepth;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                minDepth++;
            }
            return minDepth;
        }

        // 559. Maximum Depth of N-ary Tree
        public int MaxDepthNaryTree(Node root)
        {
            if (root == null)
                return 0;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            var maxDepth = 0;
            while (queue.Count > 0)
            {
                var length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    var children = node.children;
                    foreach (var child in children)
                    {
                        queue.Enqueue(child);
                    }
                }
                maxDepth++;
            }
            return maxDepth;
        }

        // 110. Balanced Binary Tree
        // 自顶向下递归：
        // |Height(left) - height[right]| <= 1 && IsBalanced(root.left) && IsBalaced(root.right)
        // T:   O(NlogN),N为节点数，最坏情况是遍历每一个节点。对于节点 p，如果它的高度是 d，则height(p) 最多会被调用 d 次（即遍历到它的每一个祖先节点时）。
        //      对于平均的情况，一棵树的高度 hh 满足 O(h)=O(\log n)O(h)=O(logn)，因为 d≤h，所以总时间复杂度为O(nlogn)。
        //      对于最坏的情况，二叉树形成链式结构，高度为 O(n)O(n)，此时总时间复杂度为 O(n^2)
        // S: O(N)， 递归层数不会超过N
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            return Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right) ? true : false;
        }
        public int GetHeight(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
        // 自底向上递归：及时止损
        /*
        自顶向下递归，因此对于同一个节点，函数 height 会被重复调用，导致时间复杂度较高。如果使用自底向上的做法，则对于每个节点，函数 height 只会被调用一次。

        自底向上递归的做法类似于后序遍历，对于当前遍历到的节点，先递归地判断其左右子树是否平衡，再判断以当前节点为根的子树是否平衡。
        如果一棵子树是平衡的，则返回其高度（高度一定是非负整数），否则返回 -1。
        如果存在一棵子树不平衡，则整个二叉树一定不平衡。
        */

        public bool IsBalanced_FromBottomToTop(TreeNode root)
        {
            return Height(root) >= 0;
        }

        public int Height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftHeight = Height(root.left);
            int rightHeight = Height(root.right);
            if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

    }
}
