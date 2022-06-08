using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No92_ReverseLinkedListII
    {
        /// <summary>
        /// pre, left, right, cur
        /// reverse list
        /// </summary>
        /// <param name="head"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// T: O(n)
        /// S: O(1)
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var preNode = dummy;

            for(int i = 0; i < left - 1; i++)
            {
                preNode = preNode.next;
            }
            var leftNode = preNode.next;
            var rightNode = preNode;
            for(int i = left; i <= right; i++)
            {
                rightNode = rightNode.next;
            }
            var curNode = rightNode.next;

            preNode.next = null;
            rightNode.next = null;

            preNode.next = rightNode;
            leftNode.next = curNode;
            return dummy.next;
        }
        public void Reverse(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            var cur = head;
            ListNode pre = null;
            while(cur != null)
            {
                var next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
        }
    }
}
