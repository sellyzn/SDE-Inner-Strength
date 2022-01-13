using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Medium
{
    public class ReverseString
    {
        ////////////////////
        // Reverse String //
        ////////////////////
        //
        // Two pointers
        //
        public void ReverseStringI(char[] s)
        {
            if (s == null || s.Length <= 1)
                return;
            int left = 0, right = s.Length - 1;
            while(left < right)
            {
                char tmp = s[left];
                s[left] = s[right];
                s[right] = tmp;
                left++;
                right--;
            }
        }

        //////////////////////
        // Reverse String II //
        //////////////////////
        //
        // Two pointers
        //
        public string ReverseStringII(string s, int k)
        {
            if (s == null || s.Length <= 1)
                return s;
            char[] charArr = s.ToCharArray();
            for(int i = 0; i < charArr.Length; i = 2 * k)
            {
                int start = i, end = Math.Min(start + k - 1, charArr.Length - 1);
                while(start < end)
                {
                    char tmp = charArr[start];
                    charArr[start] = charArr[end];
                    charArr[end] = tmp;
                    start++;
                    end--;
                }
            }
            return new string(charArr);
        }

        ////////////////////////////////
        // Reverse Vowels of a String //
        ////////////////////////////////
        //
        // 
        //
        public string ReverseVowels(string s)
        {
            if (s == null || s.Length <= 1)
                return s;
            HashSet<char> set = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            Stack<char> st = new Stack<char>();
            foreach (var c in s)
            {
                if (set.Contains(c))
                    st.Push(c);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var c in s)
            {
                if (set.Contains(c))
                    sb.Append(st.Pop());
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }


        ///////////////////////////////
        // Reverse Words in a String //
        ///////////////////////////////
        //
        // Two pointers
        //
        public string ReverseWords(string s)
        {
            s.Trim();
            if (s == null || s.Length == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            int i = s.Length - 1, j = s.Length - 1;
            while(i >= 0)
            {
                while (i >= 0 && s[i] != ' ') i--;
                sb.Append(s.Substring(i + 1, j - i) + ' ');
                while (i >= 0 && s[i] == ' ') i--;
                j = i;
            }
            return sb.ToString().Trim();
        }


        //////////////////////////////////
        // Reverse Words in a String II //
        //////////////////////////////////
        //
        // Two pointers
        //

        public string ReverseWordsIII(string s)
        {
            if (s == null || s.Length == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            int i = 0, j = 0;
            while(i < s.Length)
            {
                while (i < s.Length && s[i] != ' ') i++;
                for(int k = i - 1; k >= j; k--)
                {
                    sb.Append(s[k]);
                }
                sb.Append(' ');
                while (i < s.Length && s[i] == ' ') i++;
                j = i;
            }
            return sb.ToString().Trim();
        }


        /////////////////////////
        // Reverse Linked List //
        /////////////////////////
        //
        // 
        //
        public ListNode ReverseLinkedList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode pre = null;
            ListNode cur = head;
            
            while(cur != null)
            {
                ListNode nxt = cur.next; //断开节点前操作，记录当前节点的下一个节点
                cur.next = pre;
                pre = cur;
                cur = nxt;                
            }
            return pre;
        }

        ////////////////////////////
        // Reverse Linked List II //
        ////////////////////////////
        //
        // Two pointers
        //
        public ListNode ReverseLinkedListII(ListNode head, int left, int right)
        {
            ListNode dummyNode = new ListNode(-1);
            dummyNode.next = head;

            ListNode preNode = dummyNode;
            for(int i = 0; i < left - 1; i++)
            {
                preNode = preNode.next;
            }
            ListNode leftNode = preNode.next;

            ListNode rightNode = preNode;
            for(int i = left; i <= right; i++)
            {
                rightNode = rightNode.next;
            }
            ListNode currNode = rightNode.next;

            preNode.next = null;
            rightNode.next = null;

            ReverseLinkedList(leftNode);

            preNode.next = rightNode;
            leftNode.next = currNode;

            return dummyNode.next;
        }


        //////////////////////////////
        // Reverse Nodes in k-Group //
        //////////////////////////////
        //
        // 
        //

        //Recursion
        public ListNode ReverseKGroup_Recursion(ListNode head, int k)
        {
            if (head == null)
                return null;
            ListNode node1 = head, node2 = head;
            for(int i = 0; i < k; i++)
            {
                if (node2 == null)
                    return head;
                node2 = node2.next;
            }
            ListNode newHead = ReverseInterval(node1, node2);
            node1.next = ReverseKGroup_Recursion(node2, k);
            return newHead;
        }

        // Reverse linked list from node node1 to the former node of node2: [node1, node2), 左闭右开
        public ListNode ReverseInterval(ListNode node1, ListNode node2)
        {
            ListNode pre = null;
            ListNode cur = node1;
            while (cur != node2)
            {
                ListNode nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
            return pre;
        }

        //Iteration
        public ListNode ReverseKGroup_Iteration(ListNode head, int k)
        {
            if (head == null)
                return null;
            ListNode dummyNode = new ListNode(-1);
            dummyNode.next = head;
            ListNode pre = dummyNode;

            while(head != null)
            {
                ListNode tail = pre;
                for(int i = 0; i < k; i++)
                {
                    tail = tail.next;
                    if (tail == null)
                        return dummyNode.next;
                }
                ListNode nxt = tail.next;
                ListNode[] reverse = MyReverse(head, tail);
                head = reverse[0];
                tail = reverse[1];

                pre.next = head;
                tail.next = nxt;
                pre = tail;
                head = tail.next;
            }

            return dummyNode.next;

        }
        public ListNode[] MyReverse(ListNode head, ListNode tail)
        {
            ListNode pre = tail.next;
            ListNode cur = head;
            while(pre != tail)
            {

            }
            return new ListNode[] { tail, head };
        }
            



        /////////////////////
        // Reverse Integer //
        /////////////////////
        //
        // Math
        //
        public int ReverseInt(int x)
        {
            int res = 0;
            while(x != 0)
            {
                int mod = x % 10;
                if (res > int.MaxValue / 10 || res < int.MinValue / 10)
                    return 0;
                res = res * 10 + mod;
                x /= 10;
            }
            return res;
        }




        //////////////////
        // Reverse Bits //
        //////////////////
        //
        // 位运算分治
        //




        //public uint ReverseBits(uint n)
        //{
        //    int M1 = 0x55555555;    // 01010101010101010101010101010101
        //    int M2 = 0x33333333;    // 00110011001100110011001100110011
        //    int M4 = 0x0f0f0f0f;    // 00001111000011110000111100001111
        //    int M8 = 0x00ff00ff;    // 00000000111111110000000011111111

            
        //}



    //////////////////////////
    // Reverse Only Letters //
    //////////////////////////
    //
    // 1. Two pointers
    // 2. Stack
    public string ReverseOnlyLetters(string s)
        {
            if (s == null || s.Length <= 1)
                return s;
            char[] charArray = s.ToCharArray();
            int left = 0, right = charArray.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetter(charArray[left])) left++;
                while (left < right && !char.IsLetter(charArray[right])) right--;
                char tmp = charArray[left];
                charArray[left] = charArray[right];
                charArray[right] = tmp;
                left++;
                right--;
            }
            return new string(charArray);
        }

        public string ReverseOnlyLetters_stack(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (char.IsLetter(c))
                    stack.Push(c);
            }
            StringBuilder sb = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsLetter(c))
                    sb.Append(stack.Pop());
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }


        ////////////////////////////
        // Reverse Prefix of Word //
        ////////////////////////////
        //
        // 
        //
        public string ReversePrefix(string word, char ch)
        {
            int right = word.Length;
            for (int i = 0; i < word.Length; i++)
            {
                if(word[i] == ch)
                {
                    right = i;
                    break;
                }
            }
            if(right < word.Length)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = right; i >= 0; i--)
                {
                    sb.Append(word[i]);
                }
                for (int i = right + 1; i < word.Length; i++)
                {
                    sb.Append(word[i]);
                }
                return sb.ToString();
            }
            else
            {
                return word;
            }
        }

        public string ReversePrefix_stack(string word, char ch)
        {
            int index = 0;
            Stack<char> stack = new Stack<char>();
            foreach (var c in word)
            {
                stack.Push(c);
                if (c == ch)
                    break;
                index++;
            }
            if(index < word.Length)
            {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i <= index; i++)
                {
                    sb.Append(stack.Pop());
                }
                for(int i = index + 1; i < word.Length; i++)
                {
                    sb.Append(word[i]);
                }
                return sb.ToString();
            }
            else
            {
                return word;
            }
        }

    }
}
