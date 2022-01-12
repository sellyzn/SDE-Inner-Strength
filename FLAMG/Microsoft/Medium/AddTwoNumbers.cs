using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Medium
{
    public class AddTwoNumbers
    {
        /////////////////////
        // Add Two Numbers //
        /////////////////////
        //
        // reverse order
        //
        // simulate
        // 
        //public ListNode AddLists(ListNode l1, ListNode l2)
        //{
        //    ListNode head = null;
        //    ListNode cur = head;
        //    int carry = 0;
        //    while(l1 != null && l2 != null)
        //    {
        //        int sum = l1.val + l2.val + carry;
        //        cur = new ListNode(sum % 10);
        //        carry = sum / 10;
        //        l1 = l1.next;
        //        l2 = l2.next;
        //        cur = cur.next;
        //    }
        //    while(l1 != null)
        //    {
        //        int sum = l1.val + carry;
        //        cur = new ListNode(sum % 10);
        //        carry = sum / 10;
        //        l1 = l1.next;
        //        cur = cur.next;
        //    }
        //    while(l2 != null)
        //    {
        //        int sum = l2.val + carry;
        //        cur = new ListNode(sum % 10);
        //        carry = sum / 10;
        //        l2 = l2.next;
        //        cur = cur.next;
        //    }
        //    if(carry == 1)
        //    {
        //        cur = new ListNode(carry);
        //    }
        //    return head;
        //}

        public ListNode AddTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode cur = null;
            int carry = 0;
            while(l1 != null || l2 != null)
            {
                int n1 = l1 != null ? l1.val : 0;
                int n2 = l2 != null ? l2.val : 0;
                int sum = n1 + n2 + carry;
                if(head == null)
                {
                    head = new ListNode(sum % 10);
                    cur = head;
                }
                else
                {
                    cur.next = new ListNode(sum % 10);
                    cur = cur.next;
                }
                carry = sum / 10;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if(carry > 0)
            {
                cur.next = new ListNode(carry);
            }
            return head;
        }


        ///////////////////////
        // Add Two Numbers II //
        ///////////////////////
        //
        // forward order
        //
        // 1. stack
        // 2. reverse linkedlist + add two numbers of two linkedlists(reverse order)
        public ListNode AddLists2(ListNode l1, ListNode l2)
        {
            Stack<ListNode> stack1 = new Stack<ListNode>();
            Stack<ListNode> stack2 = new Stack<ListNode>();
            Stack<ListNode> stack3 = new Stack<ListNode>();
            int carry = 0;
            while(l1 != null)
            {
                stack1.Push(l1);
                l1 = l1.next;
            }
            while(l2 != null)
            {
                stack2.Push(l2);
                l2 = l2.next;
            }
            while(stack1.Count > 0 || stack2.Count > 0)
            {
                int n1 = stack1.Count > 0 ? stack1.Pop().val : 0;
                int n2 = stack2.Count > 0 ? stack2.Pop().val : 0;
                int sum = n1 + n2 + carry;
                stack3.Push(new ListNode(sum % 10));
                carry = sum / 10;
            }
            if(carry > 0)
            {
                stack3.Push(new ListNode(carry));
            }
            ListNode head = null;
            ListNode cur = null;
            while(stack3.Count > 0)
            {
                if(head == null)
                {
                    head = stack3.Pop();
                    cur = head;
                }
                //else
                //{
                //    cur = stack3.Pop();
                //}
                //cur = cur.next;
                else
                {
                    cur.next = stack3.Pop();
                    cur = cur.next;
                }
            }
            return head;
        }
    }
}
