using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No141LinkedListCycle
    {
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;
            var slow = head;
            var fast = head.next;
            while(fast != null && fast.next != null)
            {
                if (slow == fast)
                    return true;
                slow = slow.next;
                fast = fast.next.next;
            }
            return false;
        }
        public bool HasCycle1(ListNode head)
        {            
            ListNode slow = head, fast = head;
            while(fast != null || fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }
    }
}
