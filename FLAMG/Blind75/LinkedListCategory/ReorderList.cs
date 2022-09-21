using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.LinkedListCategory
{
    internal class ReorderList
    {
        public void ReorderLists(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            var middle = FindMiddle(head);
            var l1 = head;
            var l2 = middle.next;
            middle.next = null;
            l2 = Reverse(l2);
            MergeTwoLists(l1, l2);
        }
        public ListNode FindMiddle(ListNode head)
        {
            ListNode fast = head, slow = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
                return null;
            ListNode pre = null, cur = head;
            while(cur != null)
            {
                var nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
            return pre;
        }
        public void MergeTwoLists(ListNode l1, ListNode l2)
        {
            while(l1 != null && l2 != null)
            {
                var l1tmp = l1.next;
                var l2tmp = l2.next;
                l1.next = l2;
                l1 = l1tmp;
                l2.next = l1;
                l2 = l2tmp;
            }
        }


        // 2095. Delete the Middle Node of a Linked List
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var middle = FindMiddle(head);
            var l1 = head;
            var l2 = middle.next;
            middle.next = null;
            var cur = head;
            while(cur.next.next != null)
            {
                cur = cur.next;
            }
            cur.next = l2;
            return head;
        }
    }
}
