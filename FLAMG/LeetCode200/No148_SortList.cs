using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No148_SortList
    {
        /// <summary>
        /// Merge Sort + Recursive
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// Recursive from top to bottom + MergeSort
        /// 自顶向下递归+归并排序
        /// T: O(nlogn), 归并排序时间复杂度是O(nlogn)。
        /// S: O(logn), 空间复杂度主要取决于递归调用的栈空间
        /// 
        /// Recursive from bottom to top + MergeSort
        /// 自底向上递归+归并排序
        /// T: O(nlogn), 归并排序时间复杂度是O(nlogn)。
        /// S: O(1), 空间复杂度主要取决于递归调用的栈空间

        public ListNode SortList(ListNode head)
        {
            // 
            // Find the middle node, cut, Recursive
            //Merge
            if (head == null || head.next == null)
                return head;

            var middle = MiddleNode(head);
            var rightHead = middle.next;
            middle.next = null;
            var l2 = SortList(rightHead);
            var l1 = SortList(head);

            return MergeTwoSortedLists(l1, l2);
        }
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode slow = head, fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode MergeTwoSortedLists(ListNode l1, ListNode l2)
        {
            var dummyHead = new ListNode(0);
            var cur = dummyHead;
            while(l1 != null && l2 != null)
            {
                if(l1.val < l2.val)
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
            return dummyHead.next;
        }


        // From bottom to Top + Recursive
        public ListNode SortList1(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            // calculate the length of linked list
            int length = 0;
            var node = head;
            while(node != null)
            {
                length++;
                node = node.next;
            }
            var dummyHead = new ListNode(0);
            dummyHead.next = head;
            for(int subLength = 1; subLength < length; subLength *= 2)
            {
                ListNode pre = dummyHead, cur = dummyHead.next;
                while(cur != null)
                {
                    ListNode head1 = cur;
                    for(int i = 1; i < subLength && cur.next != null; i++)
                    {
                        cur = cur.next;
                    }
                    ListNode head2 = cur.next;
                    cur.next = null;
                    cur = head2;
                    for(int i = 1; i < subLength && cur != null && cur.next != null; i++)
                    {
                        cur = cur.next;
                    }
                    ListNode next = null;
                    if (cur != null)
                    {
                        next = cur.next;
                        cur.next = null;
                    }
                    ListNode merged = MergeTwoSortedLists(head1, head2);
                    pre.next = merged;
                    while(pre.next != null)
                    {
                        pre = pre.next;
                    }
                    cur = next;
                }
            }
            return dummyHead.next;
        }
        

    }
}
