using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No19RemoveNthNodeFromEndOfList
    {
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(L)
        /// S: O(1)
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var fast = head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            var dummy = new ListNode(-1);
            dummy.next = head;
            var slow = dummy;
            while(fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            slow.next = slow.next.next;
            return dummy.next;
        }
    }
}
