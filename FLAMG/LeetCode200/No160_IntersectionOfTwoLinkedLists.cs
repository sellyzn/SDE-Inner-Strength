using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No160_IntersectionOfTwoLinkedLists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int lenA = 0, lenB = 0;
            if (headA == null && headB == null)
                return null;
            if (headA == null || headB == null)
                return null;
            var cur = headA;
            while(cur != null)
            {
                lenA++;
                cur = cur.next;
            }
            cur = headB;
            while(cur != null)
            {
                lenB++;
                cur = cur.next;
            }
            var curA = headA;
            var curB = headB;
            if(lenA > lenB)
            {
                var diff = lenA - lenB;
                while(diff > 0)
                {
                    curA = curA.next;
                }
            }
            else
            {
                var diff = lenB - lenA;
                while(diff > 0)
                {
                    curB = curB.next;
                }
            }
            
            while(curA != null && curB != null)
            {
                if (curA == curB)
                    return curA;
                curA = curA.next;
                curB = curB.next;
            }
            return null;
        }
        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {
            ListNode A = headA, B = headB;
            while(A != B)
            {
                A = A != null ? A.next : headB;
                B = B != null ? B.next : headA;
            }
            return A;
        }
    }
}
