using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Medium
{
    public class LinkedListCycle
    {
        ///////////////////////
        // Linked List Cycle //
        ///////////////////////
        //
        // Two Pointers
        //
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head, slow = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }

        //////////////////////////
        // Linked List Cycle II //
        //////////////////////////
        //
        // Two Pointers
        // note: case no cycle.
        //
        public ListNode DeleteCycle(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (true)
            {
                if (fast == null || fast.next == null)  // case: no cycle
                    return null;
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;
            }
            slow = head;
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }

        //////////////////////////////////////
        // Intersection of Two Linked Lists //
        //////////////////////////////////////
        //
        //Two Pointers + Traverse
        //
        // nodes numbers headA: a
        // nodes numbers headB: b
        // common nodes numbers: c
        // Two pointers: A, B
        // A: after traversed all nodes of headA, traverse headB, when to the common node, the steps of A: a + (b - c)
        // B: after traversed all nodes of headB, traverse headA, when to the common node, the steps of B: b + (a - c)
        // when A and B coincide (A == B), a + (b - c) = b + (a - c)
        // 
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode A = headA, B = headB;
            while(A != B)
            {
                A = A != null ? A.next : B;
                B = B != null ? B.next : A;
            }
            return A;
        }



        /////////////////////////
        // Circular Array Loop //
        /////////////////////////
        //
        //
        //


        /////////////////////////////////
        // Intersections of Two Arrays //
        /////////////////////////////////
        //
        // 1. Two hashset
        // 2. sort + two pointers
        //
        //结果元素不重复

        //1. two sets
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            foreach(var num in nums1)
            {
                if (!set1.Contains(num))
                {
                    set1.Add(num);
                }
            }
            foreach (var num in nums2)
            {
                if (!set2.Contains(num))
                {
                    set2.Add(num);
                }
            }
            return GetIntersectionArray(set1, set2);
        }
        public int[] GetIntersectionArray(HashSet<int> set1, HashSet<int> set2)
        {
            if(set1.Count > set2.Count)
            {
                return GetIntersectionArray(set2, set1);
            }
            var intersectionSet = new HashSet<int>();
            foreach (var num in set1)
            {
                if (set2.Contains(num))
                    intersectionSet.Add(num);
            }
            int[] res = new int[intersectionSet.Count];
            int index = 0;
            foreach (var num in intersectionSet)
            {
                res[index++] = num;
            }
            return res;
        }


        //2. sorted + two pointers
         public int[] Intersection_OP(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int[] interseciton = new int[nums1.Length + nums2.Length];            
            int index1 = 0, index2 = 0, index = 0;
            while(index1 < nums1.Length && index2 < nums2.Length)
            {
                if(nums1[index1] == nums2[index2])
                {
                    if(index == 0 || interseciton[index - 1] != nums1[index1])
                    {
                        interseciton[index] = nums1[index1];
                        index++;
                    }
                    index1++;
                    index2++;
                }
                else if(nums1[index1] < nums2[index2])
                {
                    index1++;
                }
                else
                {
                    index2++;
                }                             
            }
            int[] res = new int[index];
            Array.Copy(interseciton, res, index);
            return res;
        }

        ////////////////////////////////////
        // Intersections of Two Arrays II //
        ////////////////////////////////////
        //
        // Sorted + Two Pointers
        //
        // 结果包含重复元素
        //

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int[] interseciton = new int[nums1.Length + nums2.Length];
            int index1 = 0, index2 = 0, index = 0;
            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                if (nums1[index1] == nums2[index2])
                {                    
                    interseciton[index] = nums1[index1];
                    index++;                    
                    index1++;
                    index2++;
                }
                else if (nums1[index1] < nums2[index2])
                {
                    index1++;
                }
                else
                {
                    index2++;
                }
            }
            int[] res = new int[index];
            Array.Copy(interseciton, res, index);
            return res;
        }

        //////////////////
        // Happy Number //
        //////////////////
        //
        // 1. use Hashset to detect cycles
        // 2. Two Pointers


        //
        //Three possible cases:
        //      1. End up with result is 1.
        //      2. Enter a loop
        //      3. The value will get larger and larger, and finally approach infinity (Impossible case)
        //
        // TC: O(logn)
        // SC: O(logn)

        public bool IsHappy(int n)
        {
            var set = new HashSet<int>();
            while(n != 1 && !set.Contains(n))
            {
                set.Add(n);
                n = GetNext(n);
            }
            return n == 1;
        }
        public int GetNext(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                int digit = n % 10;
                sum += digit * digit;
                n /= 10;
            }
            return sum;
        }

        // Two pointers
        // TC: O(logn)
        // SC: O(1)
        public bool IsHappy_TP(int n)
        {
            int slow = n;
            int fast = GetNext(n);   // wrong: fast = n;
            while(fast != 1 && slow != fast)
            {
                slow = GetNext(slow);
                fast = GetNext(GetNext(fast));
            }
            return fast == 1;
        }

        
    }
}
