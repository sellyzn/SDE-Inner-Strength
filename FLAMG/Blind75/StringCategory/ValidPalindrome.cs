using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class ValidPalindrome
    {
        // 125. ValidPalindrome
        // string.ToLower().Trim();
        // Two Pointers

        // Runtime Error
        public bool IsPalindrome1(string s)
        {
            var str = s.ToLower().Trim();
            if (str == null || str.Length == 0)
                return true;
            int left = 0, right = s.Length - 1;
            while(left <= right)
            {
                while(left <= right && !char.IsLetterOrDigit(str[left]))
                    left++;
                while (left <= right && !char.IsLetterOrDigit(str[right]))
                    right--;
                if (left <= right && str[left] != str[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        // T: O(N)
        // S: O(1)
        public bool IsPalindrome2(string s)
        {
            int n = s.Length;
            int left = 0, right = n - 1;
            while(left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(s[right]))
                    right--;
                if(left < right)
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                        return false;
                    left++;
                    right--;
                }
                //if (left < right && char.ToLower(s[left]) != char.ToLower(s[right]))
                //    return false;
                //left++;
                //right--;
            }
            return true;
        }

        // 680. Valid Palindrome II
        
        public bool ValidPalindromeII_Wrong(string s)
        {
            var flag = false;
            int left = 0, right = s.Length - 1;
            while(left < right)
            {
                if(s[left] != s[right])
                {
                    if (!flag)
                    {
                        if (right - 1 >= 0 && s[left] == s[right - 1])
                        {
                            flag = true;
                            right--;
                        }
                        else if (left + 1 < s.Length - 1 && s[left + 1] == s[right])
                        {
                            flag = true;
                            left++;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }                    
                }
                else
                {
                    left++;
                    right--;
                }                
            }
            return true;
        }
        // Two Pointers
        public bool ValidPalindromeII(string s)
        {
            int left = 0, right = s.Length - 1;
            while(left < right)
            {
                if(s[left] != s[right])
                {
                    return IsPalindromeRange(s, left + 1, right) || IsPalindromeRange(s, left, right - 1);
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }
        public bool IsPalindromeRange(string s, int left, int right)
        {
            while(left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        // 234. Palindrome Linked List
        /*
        找到前半部分链表的尾节点。
        反转后半部分链表。
        判断是否回文。
        恢复链表。
        返回结果。
         */
        // T: O(n)
        // S: O(1)
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;
            ListNode slow = head, fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast != null)
                slow = slow.next;
            ListNode left = head;
            ListNode right = Reverse(slow);
            while(right != null)
            {
                if (left.val != right.val)
                    return false;
                left = left.next;
                right = right.next;
            }

            return true;
        }
        public ListNode Reverse(ListNode head)
        {
            ListNode pre = null;
            var cur = head;
            while(cur != null)
            {
                var nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
            return pre;
        }
    }
}
