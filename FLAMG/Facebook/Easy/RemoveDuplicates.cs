using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Easy
{
    public class RemoveDuplicates
    {
        /////////////////////////////////////////
        // Remove Duplicates From Sorted Array //
        /////////////////////////////////////////
        
        //Two Pointers
        public int RemoveDuplicates_SortedArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n <= 1)
                return n;
            int slow = 1, fast = 1;
            while (fast < n)
            {
                if (nums[slow - 1] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }                     

        public int RemoveDuplicates_SortedArrayII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n <= 2)
                return n;
            int slow = 2, fast = 2;
            while (fast < n)
            {
                if (nums[slow - 2] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }


        ////////////////////////////////////////
        // Remove Duplicates From Sorted List //
        ////////////////////////////////////////

        //Two Pointers
        
        public ListNode RemoveDuplicates_SortedList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode slow = head, fast = head;
            while(fast != null)
            {
                if(fast.val != slow.val)
                {
                    slow.next = fast;
                    slow = slow.next;
                }
                fast = fast.next;
            }
            slow.next = null;
            return head;
        }
        public ListNode RemoveDuplicates_SortedListII(ListNode head)
        {
            if (head == null)
                return null;

            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode cur = dummy;
            while (cur.next != null && cur.next.next != null)
            {
                if (cur.next.val == cur.next.next.val)
                {
                    int x = cur.next.val;
                    while (cur.next != null && cur.next.val == x)
                    {
                        cur.next = cur.next.next;
                    }
                }
                else
                {
                    cur = cur.next;
                }
            }

            return dummy.next;
        }

        ////////////////////
        // Remove Element //
        ////////////////////

        //Two Pointers

        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                if(nums[fast] != val)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }
        public int RemoveElement_U(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                if(nums[left] == val)
                {
                    nums[left] = nums[right];
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return left;
        }

        //////////////////////////////////////////////
        // Remove All Adjacent Duplicates in String //
        //////////////////////////////////////////////

        

        //public string RemoveDuplicates_String(string s)   //超时
        //{
        //    if (s == null || s.Length == 0)
        //        return s;
        //    var st = new Stack<char>();
        //    foreach (var si in s)
        //    {
        //        if (st.Count > 0 && st.Peek() == si)
        //        {
        //            st.Pop();
        //        }
        //        else
        //        {
        //            st.Push(si);
        //        }
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    while(st.Count > 0)
        //    {
        //        sb.Append(st.Pop());
        //    }
        //    int left = 0, right = sb.Length - 1;
        //    while(left < right)
        //    {
        //        char tmp = sb[left];
        //        sb[left] = sb[right];
        //        sb[right] = tmp;
        //    }
        //    return sb.ToString();
        //}

        //

        // Stack Thinking
        // StringBuilder + top index record  --> sb.Remove(), sb.Append()  -->  Stack.Pop(), Stack.Push()
        public string RemoveDuplicates_StringI(string s)
        {
            StringBuilder sb = new StringBuilder();
            int top = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if(top >= 0 && sb[top] == s[i])
                {
                    sb.Remove(top,1);
                    top--;
                }
                else
                {
                    sb.Append(s[i]);
                    top++;
                }
            }
            return sb.ToString();
        }

        //Stack + StringBuilder

        //如果当前字符与前一个不同，在栈中压入1
        //否则如果相同，则：
        //      栈顶元素加1
        //      如果栈顶元素等于k， 则从字符产中删除这k个字符，并将k从栈顶移除.
        //When the current character is different from the previous one, push 1 into the stack.
        //Otherwise, add 1 to the top element of the stack.
        //      if the top element of the stack is equal to k,  delete these k characters from the string and remove  k from the top of the stack.
        //      if the top elememt of the stack is not equal to k, add 1 to the top element of the stack.
        //技巧： 当前元素与前一个元素相同时，直接将栈顶元素移除，如果栈顶元素等于k， 删除字符串中这k个字符，如果不等于k，则将栈顶元素值加1，压入到栈中。
        
        public string RemoveDuplicates_StringII(string s, int k)
        {
            var sb = new StringBuilder(s);   //用于对字符串的操作--删除操作--删除k个连续相等的字符
            var st = new Stack<int>();      //用于存储连续字符的个数
            for (int i = 0; i < sb.Length; i++)
            {
                if(i == 0 || sb[i] != sb[i - 1])
                {
                    st.Push(1);
                }
                else
                {
                    int count = st.Pop() + 1;
                    if(count == k)
                    {
                        sb.Remove(i - k + 1, k);
                        i -= k;     //注意字符串长度要改变
                    }
                    else
                    {
                        st.Push(count);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
