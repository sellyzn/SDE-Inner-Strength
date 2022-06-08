using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No86_PartitionList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
                return null;
            ListNode leftHead = new ListNode(0);
            ListNode rightHead = new ListNode(0);
            var cur = head;
            ListNode left = leftHead, right = rightHead;
            while (cur != null)
            {
                if (cur.val < x)
                {
                    left.next = cur;
                    left = left.next;
                }
                else
                {
                    right.next = cur;
                    right = right.next;
                }
                cur = cur.next;
            }
            right.next = null;      // 注意： right.next = null，将尾节点下一个节点置空
            left.next = rightHead.next;
            return leftHead.next;
        }
    }
}
