using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No21MergeTwoSortedLists
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        /// T: O(M + N)
        /// S: O(M + N)
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var dummy = new ListNode(-1);
            var cur = dummy;
            while(list1 != null && list2 != null)
            {
                if(list1.val <= list2.val)
                {
                    cur.next = new ListNode(list1.val);
                    list1 = list1.next;
                    cur = cur.next;
                }
                else
                {
                    cur.next = new ListNode(list2.val);
                    list2 = list2.next;
                    cur = cur.next;
                }
            }
            cur.next = list1 == null ? list2 : list1;
            return dummy.next;
        }
    }
}
