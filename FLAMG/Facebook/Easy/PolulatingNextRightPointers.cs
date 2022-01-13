using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Easy
{
    public class PolulatingNextRightPointers
    {
        /////////////////////////////////////////////////
        // Polulating Next Right Pointers in Each Node //
        /////////////////////////////////////////////////


        // special method:
        //Two Pointers
        //Perfect Binary Tree
        public Node Connect_PBT(Node root)
        {
            if (root == null)
                return null;
            ConnectTwoNodes_PBT(root.left, root.right);
            return root;
        }
        public void ConnectTwoNodes_PBT(Node node1, Node node2)
        {
            if (node1 == null || node2 == null)
                return;
            node1.next = node2;
            ConnectTwoNodes_PBT(node1.left, node1.right);
            ConnectTwoNodes_PBT(node2.left, node2.right);
            ConnectTwoNodes_PBT(node1.right, node2.left);
        }

        //General Method:
        //Level Order Traversal (BFS)
        //Queue
        public Node Connect_PBT_BFS(Node root)
        {
            if (root == null)
                return null;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var n = queue.Count;
                
                for (int i = 0; i < n; i++)
                {
                    Node cur = queue.Dequeue();
                    if (i < n - 1)
                        cur.next = queue.Peek();
                    if (cur.left != null)
                        queue.Enqueue(cur.left);
                    if (cur.right != null)
                        queue.Enqueue(cur.right);                    
                }
            }
            return root;
        }

        //Binary Tree
        //same code with PBT -- Level Order Traversal (BFS)
        public Node Connect_BT(Node root)
        {
            if (root == null)
                return null;
            var queue = new Queue<Node>();
            while(queue.Count > 0)
            {
                var n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    Node cur = queue.Dequeue();
                    if (i < n - 1)
                        cur.next = queue.Peek();
                    if (cur.left != null)
                        queue.Enqueue(cur.left);
                    if (cur.right != null)
                        queue.Enqueue(cur.right);
                }
            }
            return root;
        }


        /////////////////////////////////
        // Binary Tree Right Side View //
        /////////////////////////////////

        //LevelOrder Traverse (BFS) + Stack
        public IList<int> RightSideView(TreeNode root)
        {
            var res = new List<int>();
            var queue = new Queue<TreeNode>();
            if (root == null)
                return null;
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var stack = new Stack<int>();
                var curLen = queue.Count;
                for(int i = 0; i < curLen; i++)
                {
                    var node = queue.Dequeue();
                    stack.Push(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                res.Add(stack.Pop());
            }
            return res;
        }


    }
}
