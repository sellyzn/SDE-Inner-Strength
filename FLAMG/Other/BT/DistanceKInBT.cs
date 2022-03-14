using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BT
{
    public class DistanceKInBT
    {
        Dictionary<int, TreeNode> parents = new Dictionary<int, TreeNode>();
        IList<int> res = new List<int>();
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            //从root出发DFS，记录每个节点的父节点
            FindParents(root);
            parents[root.val] = null;   //根节点的父节点为null
            //从target出发DFS，寻找所有深度为K的节点
            FindAns(target, null, 0, k);
            return res;
        }
        public void FindParents(TreeNode node)
        {
            //记录当前节点左孩子的父节点为当前节点
            if(node.left != null)
            {
                parents.Add(node.left.val, node);
                FindParents(node.left); //向左DFS
            }
            //记录当前节点右孩子的父节点为当前节点
            if (node.right != null)
            {
                parents.Add(node.right.val, node);
                FindParents(node.right); //向右DFS
            }
        }
        public void FindAns(TreeNode node, TreeNode from, int depth, int k)
        {
            //递归结束条件
            if (node == null)
                return;
            //以target节点为根节点，往三个方向DFS， 找到depth==k的节点并放入结果数组，from用于记录来源节点，以防重复
            if(depth == k)
            {
                res.Add(node.val);
                return;
            }
            //往左边DFS
            if (node.left != from)
                FindAns(node.left, node, depth + 1, k);
            //往右边DFS
            if (node.right != from)
                FindAns(node.right, node, depth + 1, k);            
            //往父节点方向DFS
            TreeNode parent = parents.ContainsKey(node.val) ? parents[node.val] : null;
            if (parent != from)
                FindAns(parent, node, depth + 1, k);
        }
    }
}
