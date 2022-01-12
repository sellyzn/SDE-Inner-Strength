using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeIV
{
    public class InsertNodeInSortedLinkedList
    {
        public ListNode InsertNode(ListNode head, int val)
        {
            if (head == null)
                return new ListNode(val);
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode pre = dummy;
            ListNode cur = head;
            while(cur != null && cur.val < val)
            {
                pre = cur;
                cur = cur.next;                
            }
            ListNode node = new ListNode(val);
            if(cur != null)
            {
                pre.next = node;
                node.next = cur;
            }
            else
            {
                pre.next = node;
                node.next = null;
            }
            
            return dummy.next;
        }
    }
}
