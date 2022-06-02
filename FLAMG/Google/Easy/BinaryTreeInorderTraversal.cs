using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Google.Easy
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
    class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            // use a stack
            var result = new List<int>();
            if (root == null)
                return result;
            var stack = new Stack<TreeNode>();            
            var cur = root;
            while(cur != null || stack.Count > 0)
            {
                while(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }

                //cur = stack.Pop();
                //result.Add(cur.val);
                //cur = cur.right;
                var temp = stack.Pop();
                result.Add(temp.val);
                cur = temp.right;

            }
            return result;
        }
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            var stack = new Stack<TreeNode>();
            var cur = root;
            while (cur != null || stack.Count > 0)
            {
                while (cur != null)
                {
                    result.Add(cur.val);
                    stack.Push(cur);
                    cur = cur.left;
                }
                var temp = stack.Pop();
                cur = temp.right;
            }
            return result;
        }
        public IList<int> Preorder(Node root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            var stack = new Stack<Node>();
            var dict = new Dictionary<Node, int>();
            var cur = root;
            while (cur != null || stack.Count > 0)
            {
                while (cur != null)
                {
                    result.Add(cur.val);
                    stack.Push(cur);
                    var childrenList = cur.children;
                    if(childrenList != null && childrenList.Count > 0)
                    {
                        dict.Add(cur, 0);
                        cur = childrenList[0];
                    }
                    else
                    {
                        cur = null;
                    }
                }
                cur = stack.Peek();
                int index = (dict.ContainsKey(cur) ? dict[cur] : -1) + 1;
                var children = cur.children;
                if(children != null && children.Count > index)
                {
                    dict[cur] = index;
                    cur = children[index];
                }
                else
                {
                    stack.Pop();
                    dict.Remove(cur);
                    cur = null;
                }

            }
            return result;
        }
    }
}
