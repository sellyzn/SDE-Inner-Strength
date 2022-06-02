using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.LintCode100
{
    public class MergeKSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            
            ListNode listnode = null;
            for (int i = 0; i < lists.Length; i++)
            {
                listnode = MergeTwoLists(listnode, lists[i]);
            }
            return listnode;
        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            var dummyNode = new ListNode(-1);
            var cur = dummyNode;
            while(l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;                    
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;                   
                }
                cur = cur.next;
            }
            cur.next = l1 != null ? l1 : l2;

            return dummyNode.next;
        }
    }
}
