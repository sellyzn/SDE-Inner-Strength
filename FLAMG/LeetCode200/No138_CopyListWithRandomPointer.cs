using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No138_CopyListWithRandomPointer
    {
        public NodeRandom CopyRandomList(NodeRandom head)
        {
            if (head == null)
                return null;
            var cur = head;
            var dict = new Dictionary<NodeRandom, NodeRandom>();
            while(cur != null)
            {
                dict.Add(cur, new NodeRandom(cur.val));
                cur = cur.next;
            }
            cur = head;
            while(cur != null)
            {
                dict[cur].next = dict[cur.next];
                if (dict.ContainsKey(cur.random))
                    dict[cur].random = dict[cur.random];
                else
                    dict[cur.random] = null;
                cur = cur.next;
            }
            return dict[head];
        }
        /// <summary>
        /// DFS+哈希表
        /// T: O(n), n为链表长度，对于每个节点，我们至多访问其后继节点和随机指针指向的节点各一次，均摊每个节点至多被访问两次。
        /// S: O(n)， 哈希表的空间开销。
        /// </summary>
        Dictionary<NodeRandom, NodeRandom> dict = new Dictionary<NodeRandom, NodeRandom>();
        public NodeRandom CopyRandomList_DFS(NodeRandom head)
        {
            if (head == null)
                return null;
            if (!dict.ContainsKey(head))
            {
                var newHead = new NodeRandom(head.val);
                dict.Add(head, newHead);
                newHead.next = CopyRandomList(head.next);
                newHead.random = CopyRandomList(head.random);
            }
            return dict[head];
        }
        // 直接复制
        // 复制旧节点作为新节点，将新节点接在旧节点之后，连接新随机指针，分离链表
        // 在每一个老节点之后，新建与老节点val相同的节点，插入在老节点之后，随即指针不急复制，因为随机在何处还不知，需要把链表全部新老节点建立连接完成。
        // 复制新随机指针，等于老随机指针的下一个。oldnode.random = oldnode.random.next.
        // 拆分链表。随即指针不受影响，老链表依然在，新链表复制完成。 oldnode.next = oldnode.next.next; newnode.next = newnode.next.next;
        // T: O(N)
        // S: (1)

        public NodeRandom CopyRandomList1(NodeRandom head)
        {
            if (head == null)
                return null;
            // 插入新节点
            var pNode = head;
            while(pNode != null)
            {
                var copyNode = new NodeRandom(pNode.val);
                copyNode.next = pNode.next;
                pNode.next = copyNode;
                pNode = pNode.next.next;
            }
            // 连接新随即指针
            var newNode = head.next;
            pNode = head;
            while(newNode.next != null)
            {
                if(pNode.random != null)
                    newNode.random = pNode.random.next;
                pNode = pNode.next.next;
                newNode = newNode.next.next;
            }
            if (pNode.random != null)
                newNode.random = pNode.random.next;
            // 分离链表
            var ans = new NodeRandom(0);
            var cur = ans;
            pNode = head;
            while(pNode != null)
            {
                cur.next = pNode.next;
                cur = cur.next;

                pNode.next = cur.next;
                pNode = pNode.next;
            }
            return ans.next;

        }
    }
}
