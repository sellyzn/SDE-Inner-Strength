using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No2_AddTwoNumbers
    {
        // Add two numbers, linked list pattern
        // None empty linked list
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(-1);
            var cur = dummy;
            var sum = 0;
            var carry = 0;
            while(l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + carry;
                carry = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                l1 = l1.next;
                l2 = l2.next;
            }
            while(l1 != null)
            {
                sum = l1.val + carry;
                carry = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                l1 = l1.next;
            }
            while(l2 != null)
            {
                sum = l2.val + carry;
                carry = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                l2 = l2.next;
            }
            if (carry != 0)
                cur.next = new ListNode(carry);
            return dummy.next;
        }
        // T: O(Max(M, N))， M is the length of l1, N is the length of l2, we traverse all nodes of l1 and l2
        // S: O(Max(M, N)), the length of the new list is most Max(M, N) + 1.
    }
}
