using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BeaconfirePrep
{
    public class IntersectionOfTwoArrays
    {
        public int[] Intersections(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return new int[0];
            HashSet<int> set = new HashSet<int>();
            HashSet<int> resSet = new HashSet<int>();
            foreach (var num in nums1)
            {
                if (set.Contains(num))
                    continue;
                else
                    set.Add(num);
            }
            foreach (var num in nums2)
            {
                if (set.Contains(num))
                    resSet.Add(num);
            }
            int size = resSet.Count;
            int[] res = new int[size];
            int index = 0;
            foreach (var num in resSet)
            {
                res[index++] = num;
            }
            return res;
        }
    }
}
