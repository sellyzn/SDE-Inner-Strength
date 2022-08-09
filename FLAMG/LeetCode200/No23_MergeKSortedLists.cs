using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No23_MergeKSortedLists
    {
        /// <summary>
        /// Merge lists one by one
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        /// T: O(KN), K是lists的长度，merge（k - 1）次， N是lists中所有节点的数量
        /// S: O(1)
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            if(lists.Length == 1)
                return lists[0];
            var result = lists[0];
            for(int i = 1; i < lists.Length; i++)
            {
                result = MergeTwoLists(result, lists[i]);
            }
            return result;
        }
        /// <summary>
        /// Merge Two Lists
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        /// T: O(m + n), m, n分别是list1,list2的长度，即节点的数量
        /// S: O(1)
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if(list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            
            var dummyHead = new ListNode(0);
            var cur = dummyHead;
            while(list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }
                cur = cur.next;                    
            }
            cur.next = list1 == null ? list2 : list1;
            return dummyHead.next;
        }

        /// <summary>
        /// Merge lists with Divide and conquer
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        /// T: O(NlogK)
        /// S: O(1)

        public ListNode MergeKLists_Op(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            return Merge(lists, 0, lists.Length - 1);
        }
        public ListNode Merge(ListNode[] lists, int left, int right)
        {
            if (left == right)
                return lists[left];
            int mid = left + (right - left) / 2;
            var l1 = Merge(lists, left, mid);
            var l2 = Merge(lists, mid + 1, right);
            return MergeTwoLists(l1, l2);
        }
    }
}
