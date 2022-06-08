using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No61_RotateList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public ListNode RotateRight(ListNode head, int k)
        {
            // calculate list length
            if (head == null || head.next == null || k == 0)
                return head;

            int length = 0;
            var cur = head;
            while(cur != null)
            {
                length++;
                cur = cur.next;
            }
            if (length == 0)
                return head;
            k = k % length;
            if (k == 0)
                return head;
            var newHead = head;
            var dummy = new ListNode(0);
            dummy.next = head;
            var pre = dummy;
            for(int i = 0; i < length - k; i++)
            {
                pre = pre.next;
                newHead = newHead.next;
            }
            pre.next = null;
            cur = newHead;
            while(cur.next != null)
            {
                cur = cur.next;
            }
            cur.next = head;
            return newHead;
        }
        public ListNode RotateRight_Cycle(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            // close the linked list into the ring
            var oldTail = head;
            var length = 1;
            while(oldTail.next != null)
            {
                length++;
                oldTail = oldTail.next;
            }
            oldTail.next = head;

            // find new tail: (length - k % length - 1)th node
            // and new head: (n - k % n)th node
            var newTail = head;
            for(int i = 0; i < length - k % length - 1; i++)
            {
                newTail = newTail.next;
            }
            var newHead = newTail.next;

            //break the ring
            newTail.next = null;

            return newHead;

        }
    }
}
