using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No142_LinkedListCycleII
    {
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public ListNode DetectCycle(ListNode head)
        {            
            ListNode slow = head, fast = head;
            while(true)
            {
                if (fast == null || fast.next == null)
                    return null;                
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;
            }
            slow = head;
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }

        /// <summary>
        /// HashSet
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public ListNode DetectCycle_HashSet(ListNode head)
        {
            var visited = new HashSet<ListNode>();
            var cur = head;
            while(cur != null)
            {
                if (visited.Contains(cur))
                {
                    return cur;
                }
                else
                {
                    visited.Add(cur);
                    cur = cur.next;
                }
            }
            return null;    
        }
    }
}
