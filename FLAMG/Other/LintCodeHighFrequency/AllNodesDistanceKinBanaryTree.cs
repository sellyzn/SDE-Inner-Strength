using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Other.LintCodeHighFrequency
{
    public class AllNodesDistanceKinBanaryTree
    {
        // DFS + Hashtable
        Dictionary<int, TreeNode> parents = new Dictionary<int, TreeNode>();
        IList<int> ans = new List<int>();

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            // 从root出发DFS， 记录每个节点的父节点
            FindParents(root);

            // 从target出发DFS，寻找所有深度为K的节点
            FindAns(target, null, 0, k);

            return ans;
        }
        public void FindParents(TreeNode root)
        {
            if(root.left != null)
            {
                parents.Add(root.left.val, root);
                FindParents(root.left);
            }
            if(root.right != null)
            {
                parents.Add(root.right.val, root);
                FindParents(root.right);
            }
        }
        public void FindAns(TreeNode node, TreeNode from, int depth, int k)
        {
            if(depth == k)
            {
                ans.Add(node.val);
                return;
            }
            if(node.left != from)
                FindAns(node.left, from, depth + 1, k);
            if(node.right != from)
                FindAns(node.right, from, depth + 1, k);

            var parent = parents.ContainsKey(node.val) ? parents[node.val] : null;
            if(parent != from)
                FindAns(parent, node, depth + 1, k);
        }


        // step1: 遍历二叉树，找到所有节点对应的parent，构建图parents。
        // step2: 在graph上以target为起点做分层遍历。当distance=k时，queue中的节点就是距离为k的节点

        public IList<int> DistanceK_BFS(TreeNode root, TreeNode target, int k)
        {
            var parents = new Dictionary<TreeNode, TreeNode>();
            var result = new List<int>();
            if (root == null)
                return result;
            FindParents(root, parents);
            var queue = new Queue<TreeNode>();
            var visited = new HashSet<int>();
            queue.Enqueue(target);
            visited.Add(target.val);
            int distance = 0;
            while (queue.Count > 0)
            {
                if(distance == k)
                {
                    foreach (var node in queue)
                    {
                        result.Add(node.val);
                    }
                }
                var length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null && !visited.Contains(node.left.val))
                    {
                        queue.Enqueue(node.left);
                        visited.Add(node.left.val);
                    }
                    if (node.right != null && !visited.Contains(node.right.val))
                    {
                        queue.Enqueue(node.right);
                        visited.Add(node.right.val);
                    }
                    if (parents.ContainsKey(node) && !visited.Contains(parents[node].val))
                    {
                        queue.Enqueue(parents[node]);
                        visited.Add(parents[node].val);
                    }
                }
                distance++;
            }
            
            return result;
        }
        public void FindParents(TreeNode node, Dictionary<TreeNode, TreeNode> parents)
        {
            if (node == null)
                return;
            if (node.left != null)
            {
                parents.Add(node.left, node);
                FindParents(node.left, parents);
            }
            if (node.right != null)
            {
                parents.Add(node.right, node);
                FindParents(node.right, parents);
            }
        }

    }
}
