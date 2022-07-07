using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No143_ReorderList
    {
        /// <summary>
        /// Middle of the Linked List
        /// Reverse Linked List
        /// Merge Two Sorted Lists
        /// </summary>
        /// <param name="head"></param>
        /// T: O(N)
        /// S: O(1)
        public void ReorderList(ListNode head)
        {
            // 分割链表
            // 翻转链表
            // 合并链表
            if (head == null || head.next == null)
                return;
            var middleNode = MiddleNode(head);
            var l1 = head;
            var l2 = middleNode.next;
            middleNode.next = null;

            l2 = Reverse(l2);
            MergeTwoLists(l1, l2);
        }
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode pre = null, cur = head;
            while(cur != null)
            {
                var next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
        public void MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode l1Temp, l2Temp;
            while(l1 != null && l2 != null)
            {
                l1Temp = l1.next;
                l2Temp = l2.next;

                l1.next = l2;
                l1 = l1Temp;

                l2.next = l1;
                l2 = l2Temp;
            }
        }
    }
}
