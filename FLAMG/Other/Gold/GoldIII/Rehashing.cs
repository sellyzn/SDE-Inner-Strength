using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIII
{
    public class Rehashing
    {
        //public ListNode[] Rehashing(ListNode[] hashTable)
        //{
        //    int n = hashTable.Length * 2;
        //    ListNode[] res = new ListNode[n];
        //    foreach (ListNode node in hashTable)
        //    {
        //        while (node != null)
        //        {
        //            int pos = (node.val % n + n) % n;
        //            ListNode curr = new ListNode(node.val);
        //            if (res[pos] == null)
        //            {
        //                res[pos] = curr;
        //                curr.next = null;
        //            }
        //            else
        //            {
        //                ListNode head = res[pos];
        //                ListNode next = res[pos].next;
        //                head.next = curr;
        //                curr.next = next;
        //            }
        //            node = node.next;
        //        }
        //    }
        //    return res;
        //}
    }
}
