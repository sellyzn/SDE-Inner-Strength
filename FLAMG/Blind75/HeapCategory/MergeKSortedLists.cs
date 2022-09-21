using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.HeapCategory
{
    internal class MergeKSortedLists
    {
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
            while (queue.Count > 0)
            {
                var f = queue.Dequeue();
                tail.next = f.ptr;
                tail = tail.next;
                if (f.ptr.next != null)
                    queue.Enqueue(new Status(f.ptr.next.val, f.ptr.next));
            }
            return head.next;
        }
    }
}
