using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class BTLevelOrderTraversal
    {
        ///////////////////////////////////////
        // Binary Tree Level Order Traversal //
        ///////////////////////////////////////
        //
        // Queue
        //

        public IList<IList<int>> BTLevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var subList = new List<int>();
                int curLength = queue.Count;
                for(int i = 0; i < curLength; i++)
                {
                    TreeNode node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                res.Add(subList);
            }
            return res;
        }


        //////////////////////////////////////////
        // Binary Tree Level Order Traversal II //
        //////////////////////////////////////////
        //
        // Queue + List.Insert(index, subList)
        //
        public IList<IList<int>> BTLeverOrderBottom(TreeNode root)
        {
            var res = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var subList = new List<int>();
                var curLength = queue.Count;
                for(int i = 0; i < curLength; i++)
                {
                    var node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                res.Insert(0, subList);
            }
            return res;
        }

        //////////////////////////////////////////////
        // Binary Tree ZigZag Level Order Traversal //
        //////////////////////////////////////////////
        //
        // Queue + Stack
        //
        public IList<List<int>> LevelOrder_ZigZag(TreeNode root)
        {
            var res = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            int level = 0;
            while(queue.Count > 0)
            {
                var subList = new List<int>();
                var curLength = queue.Count;
                for(int  i = 0; i < curLength; i++)
                {
                    var node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                if(level % 2 == 0)
                {
                    res.Add(subList);
                }
                else
                {
                    var stack = new Stack<int>();
                    var subListOdd = new List<int>();
                    foreach (var item in subList)
                    {
                        stack.Push(item);
                    }
                    while(stack.Count > 0)
                    {
                        subListOdd.Add(stack.Pop());
                    }
                    res.Add(subListOdd);
                }
                level++;
            }
            return res;
        }

        //////////////////////////////////////////
        // Binary Tree Vertical Order Traversal //
        //////////////////////////////////////////
        //
        // 
        //



        /////////////////////////////////
        // Binary Tree Right Side View //
        /////////////////////////////////
        //
        // Recursion
        //


        //////////////////////////////////
        // Minimum Depth of Binary Tree //
        //////////////////////////////////
        //
        // 
        //

        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null || root.right == null)
                return 1;
            int minDepth = int.MinValue;
            if (root.left != null)
                minDepth = Math.Min(minDepth, MinDepth(root.left));
            if (root.right != null)
                minDepth = Math.Min(minDepth, MinDepth(root.right));
            return minDepth + 1;
        }


        //////////////////////////////////////
        // Average of Levels in Binary Tree //
        //////////////////////////////////////
        //
        // Queue
        //
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var res = new List<double>();
            var queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while(queue.Count> 0)
            {
                double sum = 0.00000;
                int curLength = queue.Count;
                for(int i = 0; i < curLength; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                res.Add(sum / curLength);
            }
            return res;
        }


        ////////////////////////////////////////
        // Maximum Level Sum of a Binary Tree //
        ////////////////////////////////////////
        //
        // Queue
        //
        public int MaxLevelSum(TreeNode root)
        {
            var dict = new Dictionary<int,int>();
            var queue = new Queue<TreeNode>();
            if (root == null)
                return 0;
            queue.Enqueue(root);
            int level = 1;
            int maxSum = int.MinValue;            
            while (queue.Count > 0)
            {                
                int sum = 0;
                int curLength = queue.Count;
                for (int i = 0; i < curLength; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                if (!dict.ContainsKey(sum))
                {
                    dict.Add(sum,level);
                }
                maxSum = Math.Max(maxSum, sum);
                level++;
            }
            foreach (var item in dict.Keys)
            {
                if (item == maxSum)
                    return dict[item];
            }
            return 0;
        }

        ////////////////////////////
        // Cousins in Binary Tree //
        ////////////////////////////
        //
        // DFS(node, depth, parent)
        // cousins: xDepth == yDepth && xParent != yParent
        //

        // x
        int x;
        TreeNode xParent;
        int xDepth;
        bool xFound = false;

        // y
        int y;
        TreeNode yParent;
        int yDepth;
        bool yFound = false;
        public bool IsCousins(TreeNode root, int x, int y)
        {
            this.x = x;
            this.y = y;
            DFS(root, 0, null);
            return xDepth == yDepth && xParent != yParent;
        }
        public void DFS(TreeNode node, int depth, TreeNode parent)
        {
            if (node == null || (xFound == true && yFound == true))
                return;
            if (node.val == x)
            {
                xParent = parent;
                xDepth = depth;
                xFound = true;
            }
            if(node.val == y)
            {
                yParent = parent;
                yDepth = depth;
                yFound = true;
            }
            
            DFS(node.left, depth + 1, node);            
            DFS(node.right, depth + 1, node);
        }


        //////////////////////////////////////
        // N-ary Tree Level Order Traversal //
        //////////////////////////////////////
        //
        // BFS
        //

        public IList<IList<int>> LeverOrder_NAry(Node root)
        {
            var res = new List<IList<int>>();
            var queue = new Queue<Node>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var subList = new List<int>();
                int curLength = queue.Count;
                for (int i = 0; i < curLength; i++)
                {
                    Node node = queue.Dequeue();
                    subList.Add(node.val);
                    foreach (var child in node.children)
                    {
                        queue.Enqueue(child);
                    }
                }
                res.Add(subList);
            }
            return res;
        }
    }
}
