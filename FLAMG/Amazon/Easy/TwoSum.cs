using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class TwoSum
    {
        /////////////
        // Two Sum //
        /////////////
        //
        // Hashtable
        //
        public int[] TwoSum_I(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            var res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int minus = target - nums[i];
                if (dict.ContainsKey(minus))
                {
                    res[0] = dict[minus];
                    res[1] = i;
                    break;
                }
                else if(!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return res;
        }


        //////////////////////////
        // Three Sum / Four Sum //
        //////////////////////////
        //
        // 
        //
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            return nSumTarget(nums, 3, 0, 0);
        }
        public IList<IList<int>> FourSum(int[] nums)
        {
            Array.Sort(nums);
            return nSumTarget(nums, 4, 0, 0);
        }
        public IList<IList<int>> nSumTarget(int[] nums, int n, int start, int target)
        {
            int len = nums.Length;
            var res = new List<IList<int>>();

            if (n < 2 || len < n)
                return res;

            if(n == 2)
            {
                int lo = start, hi = len - 1;
                while(lo < hi)
                {
                    int sum = nums[lo] + nums[hi];
                    int left = nums[lo], right = nums[hi];
                    if(sum < target)
                    {
                        while (lo < hi && nums[lo] == left)
                            lo++;
                    }
                    else if(sum > target)
                    {
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                    else
                    {
                        var sub = new List<int> { left, right };
                        res.Add(sub);
                        while (lo < hi && nums[lo] == left)
                            lo++;
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                }
            }
            else
            {
                for(int i = start; i < len; i++)
                {
                    var subs = nSumTarget(nums, n - 1, i + 1, target - nums[i]);
                    foreach (var sub in subs)
                    {
                        sub.Add(nums[i]);
                        res.Add(sub);
                    }
                    while (i < len - 1 && nums[i] == nums[i + 1])
                        i++;
                }
            }

            return res;
        }



        ////////////////////////////////////////
        // Two Sum II - Input Array Is Sorted //
        ////////////////////////////////////////
        //
        // Two Pointers
        //
        public int[] TwoSum_Sorted(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while(left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                    return new int[] { left + 1, right + 1 };
                else if (sum < target)
                    left++;
                else if (sum > target)
                    right--;
            }
            return new int[0];
        }



        /////////////////////////////////////////
        // Two Sum III - Data Structure Design //
        /////////////////////////////////////////
        //
        // 
        //




        /////////////////////////////////
        // Two Sum IV - Input Is a BST //
        /////////////////////////////////
        //
        // BST inorder traverse + List
        //
        public bool FindTarget(TreeNode root, int k)
        {
            var list = new List<int>();
            Inorder(root, list);
            int left = 0, right = list.Count - 1;
            while(left < right)
            {
                int sum = list[left] + list[right];
                if (sum == k)
                    return true;
                else if (sum < k)
                    left++;
                else if (sum > k)
                    right--;
            }
            return false;
        }

        public void Inorder(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            Inorder(root.left, list);
            list.Add(root.val);
            Inorder(root.right, list);
        }

        /////////////////////////
        // Two Sum Less Than K //
        /////////////////////////
        //
        // 
        //


        ///////////////////////////
        // Subarray Sum Equals K //
        ///////////////////////////
        //
        // 
        //




        ///////////////////////////////////////////
        // Two Sum - Difference Equals to Target //
        ///////////////////////////////////////////
        //
        // given an sorted array
        //
        public int[] TwoSum_Difference(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while(left < right)
            {
                int diff = nums[right] - nums[left];
                if (diff == target)
                    return new int[] { nums[left], nums[right] };
                else if (diff < target)
                    left++;
                else if (diff > target)
                    right--;
            }
            return new int[0];
        }


        ////////////////////////////////////////////
        // Two Sum - Less Than or Equal to Target //
        ////////////////////////////////////////////
        //
        // 
        //



        /////////////////////////////////
        // Two Sum - Closest to Target //
        /////////////////////////////////
        //
        // 
        //



        ///////////////////////////////////
        // Two Sum - Greater Than Target //
        ///////////////////////////////////
        //
        // 
        //



        ////////////////////////////
        // Two Sum - Unique Pairs //
        ////////////////////////////
        //
        // 
        //





        /////////////////////////
        // Two Sum of Integers //
        /////////////////////////
        //
        // Bit Operation
        //
        // sum without carry bit: a ^ b
        // carry bit: (a & b) << 1;
        // 
        public int GetSum(int a, int b)
        {
            while(b != 0)
            {
                int carry = (a & b) << 1;
                a ^= b;
                b = carry;
            }
            return a;
        }
    }
}
