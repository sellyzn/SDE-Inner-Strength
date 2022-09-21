using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.LinkedListCategory
{
    internal class ReverseLinkList
    {
        // 206. Reverse Linked List
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode pre = null, cur = head;
            while (cur != null)
            {
                var nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
            return pre;
        }

        // 92. Reverse Linked List II
        // 1 -> 2 -> 3 -> 4 -> 5
        //           ||
        //           \/
        // 1 -> 4 -> 3 -> 2 -> 5
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var dummyNode = new ListNode(-1);
            dummyNode.next = head;
            var preNode = dummyNode;
            for(int i = 0; i < left - 1; i++)
            {
                preNode = preNode.next;
            }
            var leftNode = preNode.next;

            var rightNode = leftNode;
            for(int i = left; i < right; i++)
            {
                rightNode = rightNode.next;
            }

            var curNode = rightNode.next;

            preNode.next = null;
            rightNode.next = null;

            Reverse(leftNode);
            preNode.next = rightNode;
            leftNode.next = curNode;
            return dummyNode.next;
            
        }
        public void Reverse(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            var cur = head;
            ListNode pre = null;
            while(cur != null)
            {
                var nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
        }
        
    }
}
