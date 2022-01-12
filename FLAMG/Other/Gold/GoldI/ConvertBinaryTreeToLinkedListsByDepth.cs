using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldI
{
    public class ConvertBinaryTreeToLinkedListsByDepth
    {
        public IList<ListNode> BinaryTreeToLists(TreeNode root)
        {
            var res = new List<ListNode>();
            if (root == null)
                return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int length = queue.Count;
                var dummy = new ListNode(-1);
                var cur = dummy;
                while(length > 0)
                {
                    var node = queue.Dequeue();
                    cur.next = new ListNode(node.val);
                    cur = cur.next;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    length--;
                }
                res.Add(dummy.next);
            }
            return res;
        }
    }
}
