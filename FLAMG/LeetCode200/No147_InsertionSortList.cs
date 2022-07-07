using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No147_InsertionSortList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T: O(N^2)
        /// S: O(1)
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var dummyHead = new ListNode(0);
            dummyHead.next = head;
            var lastSorted = head;
            var cur = head.next;
            while(cur != null)
            {
                if(lastSorted.val <= cur.val)
                {
                    lastSorted = lastSorted.next;
                }
                else
                {
                    var pre = dummyHead;
                    while(pre.next.val <= cur.val)
                    {
                        pre = pre.next;
                    }
                    lastSorted.next = cur.next;
                    cur.next = pre.next;
                    pre.next = cur;
                }
                cur = lastSorted.next;
            }
            return dummyHead;
        }
    }
}
