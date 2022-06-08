using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No109_ConvertSortedListToBinarySearchTree
    {
        // Time Limit Exceeded
        public TreeNode SortedListToBST(ListNode head)
        {
            if(head == null)
                return new TreeNode(0);
            // calculate the length of linked list
            // if length % 2 == 0 --> the node at length / 2 + 1 is the root
            // if length % 2 != 0 --> the node at length / 2 + 1 is the root
            // cut the linked list, DFS
            var length = 0;
            var cur = head;
            while(cur != null)
            {
                length++;
                cur = cur.next;
            }
            var rootIndex = length / 2;
            cur = head;
            var dummy = new ListNode(0);
            dummy.next = head;
            var pre = dummy;
            while(rootIndex > 0)
            {
                pre = pre.next;
                cur = cur.next;
                rootIndex--;
            }
            var rootValue = cur.val;
            pre.next = null;
            var root = new TreeNode(rootValue);
            root.left = SortedListToBST(head);
            root.right = SortedListToBST(cur);
            return root;
        }

        /// <summary>
        /// Divide and Conequer + Recursive + Two Pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T: O(nlogn)， n是链表的长度。 链表构造二叉树的时间为T(n)， T(n) = 2 * T(n/2) + O(n)， 
        /// S: O(logn), 这里只计算除了返回答案之外的空间。 平衡二叉树的高度为O(logn), 即递归过程中栈的最大深度，也就是需要的空间。
        public TreeNode SortedListToBST1(ListNode head)
        {
            return Traverse(head, null);
        }
        public TreeNode Traverse(ListNode left, ListNode right)
        {
            if (left == right)
                return null;
            ListNode middle = GetMidian(left, right);
            TreeNode root = new TreeNode(middle.val);
            root.left = Traverse(left, middle);
            root.right = Traverse(middle.next, right);
            return root;
        }
        public ListNode GetMidian(ListNode left, ListNode right)
        {
            ListNode fast = left;
            ListNode slow = left;
            while (fast != right && fast.next != right)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }
}
