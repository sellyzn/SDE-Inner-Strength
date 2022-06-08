using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No82_RemoveDuplicatesFromSortedListII
    {
        /// <summary>
        /// 一次遍历
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// T : O(N)
        /// S : O(1)
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;
            var dummy = new ListNode(0);
            dummy.next = head;
            var cur = dummy;
            while(cur.next != null && cur.next.next != null)
            {
                if(cur.next.val == cur.next.next.val)
                {
                    int x = cur.next.val;
                    while(cur.next != null && cur.next.val == x)
                    {
                        cur.next = cur.next.next;   //将cur的下一个节点指针指向cur.next的下一个节点， 将cur.next节点从链表中删除。
                    }
                }
                else
                {
                    cur = cur.next;
                }
            }
            return dummy.next;
        }
        // 多加一个pre逻辑更清晰
        public ListNode DeleteDuplicatesI(ListNode head)
        {
            if (head == null) 
                return null;
            ListNode dummyHead = new ListNode(0);
            ListNode pre = dummyHead;
            pre.next = head;
            ListNode cur = head;
            while (cur != null && cur.next != null)
            {
                if (cur.val == cur.next.val)
                {
                    int val = cur.val;
                    while (cur != null && cur.val == val)
                    {
                        cur = cur.next;
                    }
                    pre.next = cur;
                }
                else
                {
                    pre = cur;
                    cur = cur.next;
                }
            }
            return dummyHead.next;
        }
    }
}
