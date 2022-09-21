using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.LinkedListCategory
{
    internal class MergeKSortedLists
    {
        // 23. Merge K Sorted Lists
        // 分治合并
        public ListNode MergeKLists(ListNode[] lists)
        {
            if(lists == null || lists.Length == 0)
                return null;
            return Merge(lists, 0, lists.Length - 1);
        }

        // T: O(KN * logK), 第一轮合并k/2组链表，每一组的时间代价是O(2N);
        //    第二轮合并k/4组链表，每一组的时间代价是O(4N)...
        //    所以总的时间代价为O(sum[(k/(2^i))* 2^i * N]), (i: 0~无穷)，也就是O(KN * logK)
        //    所以时间复杂度为O(KN*logK)
        // S: O(logK), 递归使用到O(logK)空间代价的栈空间。
        public ListNode Merge(ListNode[] lists, int left, int right)
        {
            if(left == right)
                return lists[left];
            int mid = left + (right - left) / 2;
            var l1 = Merge(lists, left, mid);
            var l2 = Merge(lists, mid + 1, right);
            return MergeTwoLists(l1, l2);
        }
        // T: O(N)， 两个链表的最长长度为N
        // S: O(1)
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummyNode = new ListNode(0);
            var cur = dummyNode;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                    cur = cur.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                    cur = cur.next;
                }
            }
            cur.next = l1 != null ? l1 : l2;
            return dummyNode.next;
        }



        /*
         顺序合并：
        时间复杂度：假设每个链表最长长度是n。在第一次合并后，ans的长度为n；第二次合并后，ans的长度为2*n，第i次合并后，ans的长度为i * n。
        第i次合并的时间代价为O(n + (i-1)*n) = O(i*n)。
        那么总的时间代价为O(sum[i*n]), i: 1到k。 也就是O((1+k)*k/2 * n) = O(k^2 * n)
        所以渐进时间复杂度为O(k^2 * n)。
        空间复杂度：没有拥戴与k和n闺蜜相关的辅助空间，故渐进空间复杂度为O(1)。
         */



        // 优先队列/堆
        class Status : IComparable<Status>
        {
            int val;
            ListNode ptr;

            public Status(int val, ListNode ptr)
            {
                this.val = val;
                this.ptr = ptr;
            }

            public int CompareTo(Status status2)
            {
                return this.val - status2.val;
            }
        }
        public ListNode MergeKListsHeap(ListNode[] lists)
        {
            var queue = new PriorityQueue<Status>();
            foreach (var list in lists)
            {
                if (list != null)
                    queue.Enqueue(new Status(list.val, list));
            }

            var head = new ListNode(0);
            var tail = head;
            while(queue.Count > 0)
            {
                var f = queue.Dequeue();
                tail.next = f.ptr;
                tail = tail.next;
                if(f.ptr.next != null)
                    queue.Enqueue(new Status(f.ptr.next.val, f.ptr.next));
            }
            return head.next;
        }
    }
}
