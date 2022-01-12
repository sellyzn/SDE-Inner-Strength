using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeIV
{
    public class CountLinkedListNodes
    {
        public int CountNodes(ListNode head)
        {
            int count = 0;
            while(head != null)
            {
                count++;
                head = head.next;
            }
            return count;
        }
        public int CountNodesII(ListNode head)
        {
            int count = 0;
            while(head != null)
            {
                if (head.val >= 0 && head.val % 2 == 1)
                    count++;
                head = head.next;
            }
            return count;
        }
    }
}
