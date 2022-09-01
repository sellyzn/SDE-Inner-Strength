using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class LowestCommonAncesstorOfABinarySearchTree
    {
        // 235. Lowest Common Ancestor of a Binary Search Tree
        // Recursive
        // T: O(n)
        // S: O(n)
        public TreeNode LowestCommonAncestorBST(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestorBST(root.left, p, q);
            if(p.val > root.val && q.val > root.val)
                return LowestCommonAncestorBST(root.right, p, q);
            return root;
        }
        // Iterator
        // T: O(n)
        // S: O(1)
        public TreeNode LowestCommonAncestorBSTIterator(TreeNode root, TreeNode p, TreeNode q)
        {
            var node = root;
            while(node != null)
            {
                if (node.val > p.val && node.val > q.val)
                    node = node.left;
                else if (node.val < p.val && node.val < q.val)
                    node = node.right;
                else
                    return node;
            }
            return null;
        }


        // 236. Lowest Common Ancestor of a Binary Tree
        // node p and q are sure exist in the given tree, so it must exist a lowest common ancestor
        /*
        时间复杂度：O(N)，其中 N 是二叉树的节点数。二叉树的所有节点有且只会被访问一次，因此时间复杂度为 O(N)。
        空间复杂度：O(N) ，其中 N 是二叉树的节点数。递归调用的栈深度取决于二叉树的高度，二叉树最坏情况下为一条链，此时高度为 N，因此空间复杂度为 O(N)
         */
        public TreeNode LowestCommonAncestorBT(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;
            var left = LowestCommonAncestorBT(root.left, p, q);
            var right = LowestCommonAncestorBT(root.right, p, q);
            if (left != null && right != null)
                return root;
            else if (left == null && right == null)
                return null;
            else
                return left == null ? right : left;
        }


        // 1644. Lowest Common Ancestor of a Binary Tree II
        // node p and q are not sure in the given tree, so it may not exist a common ancestor. 
        // if p or q is not exist in the given tree, return null.
        // all values of the nodes in the tree are unique.
        public TreeNode LowestCommonAncestorBTII(TreeNode root, TreeNode p, TreeNode q)
        {
            if (!IsSubtree(root, p) || !IsSubtree(root, q))
                return null;
            return LowestCommonAncestorBT(root, p, q);
        }
        // t is the subtree of s
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;
            return Check(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }
        // trees s and t are the same
        public bool Check(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;
            if (s == null || t == null || s.val != t.val)
                return false;
            return Check(s.left, t.left) && Check(s.right, t.right);
        }


        // 1650. Lowest Common Ancestor of a Binary Tree III
        // 
        public NodeP LowestCommonAncestorBTIII(NodeP p, NodeP q)
        {
            var pParents = new HashSet<NodeP>();
            var cur = p;
            while(cur != null)
            {
                pParents.Add(cur);
                cur = cur.parent;
            }
            cur = q;
            while(q != null)
            {
                if (pParents.Contains(q))
                    return q;
                q = q.parent;
            }
            return null;
        }


        // 1676. Lowest Common Ancestor of a Binary Tree IV
        public TreeNode LowestCommonAncestorBTIV(TreeNode root, TreeNode[] nodes)
        {
            if (root == null)
                return null;
            foreach (var node in nodes)
            {
                if (root == node)
                    return root;
            }

            var left = LowestCommonAncestorBTIV(root.left, nodes);
            var right = LowestCommonAncestorBTIV(root.right, nodes);
            if (left != null && right != null)
                return root;
            if (left == null && right == null)
                return null;
            return left == null ? right : left;
        }
    }
}
