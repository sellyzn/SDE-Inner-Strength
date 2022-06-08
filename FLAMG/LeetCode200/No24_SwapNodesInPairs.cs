using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No24_SwapNodesInPairs
    {
        /// <summary>
        /// Recursive / Iterate
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// Recursive:
        /// T: O(n), n是链表中的节点数量，需要对每个节点进行更新指针的操作
        /// S: O(n)， 空间复杂度主要取决于递归调用的栈空间。
        /// Iterate:
        /// T: O(n)
        /// S: O(1)
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode newHead = head.next;
            head.next = SwapPairs(newHead.next);
            newHead.next = head;
            return newHead;
        }
        public ListNode SwapPairs_Iterate(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var dummy = new ListNode(0);
            dummy.next = head;
            var temp = dummy;
            while(temp.next != null && temp.next.next != null)
            {
                var node1 = temp.next;
                var node2 = temp.next.next;
                temp.next = node2;
                node1.next = node2.next;
                node2.next = node1;
                temp = node1;   // node1
            }
            return dummy.next;
        }
    }
}
