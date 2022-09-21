using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG
{
    internal class MyLinkedList
    {
        LinkedListNode head;
        public class LinkedListNode
        {
            public int data;
            public LinkedListNode next;
            public LinkedListNode(int data)
            {
                this.data = data;
                next = null;
            }
        }

        public void Push(LinkedListNode node)
        {
            LinkedListNode temp = node;
            head = node;
            head.next = temp;
        }

        public void Insert(LinkedListNode node)
        {
            if(head == null)
            {
                head = node;
                return;
            }
            // insert node at the end of the list
            LinkedListNode temp = head;
            while(temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = node;
            node.next = null;
        }

        static void Main(string[] args)
        {
            MyLinkedList list = new MyLinkedList();
            list.head = new LinkedListNode(10);
            LinkedListNode second = new LinkedListNode(20);
            list.head.next = second;
            LinkedListNode third = new LinkedListNode(30);
            list.head.next = third;
        }


        // create/get/remove nodes from linked list
        public class Node
        {
            public object value;
            public Node next;
            public Node(object value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }

        // construc single node
        public Node ConstructNode(object value, Node next = null)
        {
            return new Node(value, next);
        }

        // Insert first node
        public Node AddFirst(object value)
        {
            return ConstructNode(value);
        }


        // insert last node
        public Node AddLast(Node objNode, object value)
        {
            Node tempNode = ConstructNode(value);
            objNode.next = tempNode;
            return objNode;
        }

        // insert at index
        public Node InsertNode(Node objNode, int index, object value)
        {
            int i = 0; 
            while(i < index - 1)
            {
                objNode = objNode.next;
                i++;
            }
            Node tempNode = ConstructNode(value, objNode.next);
            objNode.next = tempNode;
            return objNode;
        }

        // get at index
        public Node GetNode(Node objNode, int index)
        {
            int i = 0;
            while (i < index)
            {
                if (objNode.next == null)
                {
                    throw new IndexOutOfRangeException();
                }

                objNode = objNode.next;
                i++;
            }
            return objNode;
        }


        // remove at index
        public Node RemoveNode(Node objNode, int index)
        {
            int i = 0;
            while (i < index - 1)
            {
                objNode = objNode.next;

            }
            objNode.next = objNode.next.next;
            return objNode;
        }



        // clear list
        public Node ClearList(Node objNode)
        {
            while (objNode.next != null)
            {
                objNode = objNode.next;
            }
            return objNode.next;
        }




    }
}
