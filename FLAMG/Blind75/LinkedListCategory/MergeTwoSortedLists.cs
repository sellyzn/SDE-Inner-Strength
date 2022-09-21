using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.LinkedListCategory
{
    internal class MergeTwoSortedLists
    {
        // 21. Merge Two Sorted Lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummyNode = new ListNode(0);
            var cur = dummyNode;
            while(l1 != null && l2 != null)
            {
                if(l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                    cur = cur.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                    cur = cur.next;
                }
            }
            cur.next = l1 != null ? l1 : l2;
            return dummyNode.next;
        }
    }
}
