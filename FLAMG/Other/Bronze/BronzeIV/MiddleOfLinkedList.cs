using FLAMG.Other.Bronze.BronzeIV;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeIV
{
    public class MiddleOfLinkedList
    {
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }
}
