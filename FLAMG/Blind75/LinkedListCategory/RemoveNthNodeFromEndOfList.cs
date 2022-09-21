using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.LinkedListCategory
{
    internal class RemoveNthNodeFromEndOfList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var cur = head;
            for(int i = 0; i < n; i++)
            {
                cur = cur.next;
            }
            var dummy = new ListNode(0);
            dummy.next = cur;
            var pre = dummy;            
            while(cur != null){
                cur = cur.next;
                pre = pre.next;
            }
            pre.next = pre.next.next;
            return dummy.next;
        }
    }
}
