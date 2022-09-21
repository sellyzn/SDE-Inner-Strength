using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.LinkedListCategory
{
    internal class LinkedListCycle
    {
        // 141. Linked List Cycle
        public bool HasCycle(ListNode head)
        {
            if(head == null || head.next == null)
                return false;
            var slow = head;
            var fast = head.next;
            while(fast != null || fast.next != null)
            {
                if(slow == fast)
                    return true;
                slow = slow.next;
                fast = fast.next.next;
            }
            return false;
        }

        // 142. Linked List Cycle II
        /*
        f = 2s (快指针每次2步，路程刚好是慢指针的2倍)
        f = s + nb (相遇时，快指针刚好多走了n圈)
        上述两式推出：s = nb （第一次相遇时，慢指针slow步数为nb）

        如果让指针从链表头部一直向前走并统计步数k，那么所有 走到链表入口节点时的步数 是：k=a+nb（先走 a 步到入口节点，之后每绕 1 圈环（ b 步）都会再次到入口节点）。
        而目前，slow 指针走过的步数为 nbnb 步。因此，我们只要想办法让 slow 再走 a 步停下来，就可以到环的入口。
        但是我们不知道 a 的值，该怎么办？依然是使用双指针法。我们构建一个指针，此指针需要有以下性质：此指针和slow 一起向前走 a 步后，两者在入口节点重合。那么从哪里走到入口节点需要 a 步？答案是链表头部head。


        从head结点走到入环点需要走：a + nb，而slow已经走了nb，那么slow再走a步就是入环点了。
        如何直到slow刚好走了a步，从head开始，和slow指针一起走，相遇时刚好就是a步。
         */
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return null;
            var slow = head;
            var fast = head;
            
            while (true)
            {
                if (fast == null || fast.next == null)
                    return null;
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;                
            }
            fast = head;
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }
    }
}
