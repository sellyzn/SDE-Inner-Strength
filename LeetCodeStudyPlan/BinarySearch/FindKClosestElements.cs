using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class FindKClosestElements
    {
        /*
         [1,2,3,4,5], k = 4, x = 3
        3，2，4，1 ==> 1,2,3,4
        
        
        行不通：
        1. find the k closest intergers to x 
            => find the kth closet interger to x + for(i:1~k)
            => (arr: ascending order), binary search to find the first closest integer to x,
            => update the leftnumbers and rightnumbers

            (1)how to find the first closest number to x?
            Binary search
           
            (2)calculate leftnumbers and rightnumbers:
            [-1,0,1,2,3,4,5,6,7], k = 4, x = 3
            3，2，4，1 ==> 1,2,3,4

            first closest: 3, index = 2,
                leftnumbers = (k - 1) / 2 + 1;
                if(index <= leftnumbers) ==> select all of the left numbers
                    rightnumbers = k - index - 1
                if(index > leftnumbers) ==> select leftnumbers of the left numbers
                    rightnumbers = k - 1 - leftnumbers

        2. sort the result in asceding order
            Array.Sort()

        方法二：
        (1)base case
        (2)find the closest interger to x (binary search)
        (3)sliding window(中心扩展)
            left == -1 ==> right++
            right == arr.Length || abs(arr[left] - x) <= abs(arr[right] - x) ==> left--
            else ==> right--
        (4) build the result： (left, right) ==> [left + 1, right - 1]

        Time complexity: O(log(N)+k).
        The initial binary search to find where we should start our window costs O(log(N)). 
        Our sliding window initially starts with size 0 and we expand it one by one until it is of size k, thus it costs O(k) to expand the window.

        Space complexity: O(1)

         */
        public IList<int> FindClosestElements1(int[] arr, int k, int x)
        {
            var result = new List<int>();
            //base case
            if(k == arr.Length)
            {
                foreach (var num in arr)
                {
                    result.Add(num);
                }
                return result;
            }

            // binary search to find the closest element
            int left = 0, right = arr.Length - 1;
            while(left < right)
            {
                var mid = left + (right - left) / 2;
                if (arr[mid] >= x)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            // initialize sliding window's bounds
            left -= 1;
            right = left + 1;

            // while the window size is less than k
            while(right - left - 1 < k)
            {
                // note the bound
                if(left == -1)
                {
                    right++;
                    continue;
                }

                // Expand the window towards the side with the closer number
                // note the bound
                if (right == arr.Length || Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x))
                {
                    left--;
                }
                else
                {
                    right++;
                }
            }

            // build and return the window
            for(int i = left + 1; i < right; i++)
            {
                result.Add(arr[i]);
            }

            return result;
        }
        // find the index of the closest element to x
        /*
         [1,2,3,3,3,4,5], x = 3               
         result: 4
         */
        public int FindTheClosestElement(int[] arr, int x)
        {
            var minDiff = int.MaxValue;
            var result = 0;    
            for(int i = 0; i < arr.Length; i++)
            {
                var abs = Math.Abs(arr[i] - x);
                if(abs < minDiff)
                {
                    minDiff = abs;
                    result = i;
                }else if(abs == minDiff)
                {
                    result = Math.Max(i, result);
                }
            }            
            return result;
        }
    }
}
