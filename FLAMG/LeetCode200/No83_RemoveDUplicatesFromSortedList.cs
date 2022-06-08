using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No83_RemoveDUplicatesFromSortedList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S:(1)
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var pre = head;
            var cur = head.next;
            while(cur != null)
            {
                if(cur.val != pre.val)
                {
                    pre.next = cur;
                    pre = cur;
                }
                cur = cur.next;
            }
            pre.next = null;
            return head;
        }
        public ListNode DeleteDUplicates1(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var cur = head;
            while(cur != null && cur.next != null)
            {
                if(cur.val != cur.next.val)               
                    cur = cur.next;                
                else               
                    cur.next = cur.next.next;                
            }
            return head;
        }
    }
}
