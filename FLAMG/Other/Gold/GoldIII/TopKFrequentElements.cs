using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIII
{
    public class TopKFrequentElements
    {
        ////快速选择
        ////find the top k largest elements
        //public IList<int> TopKLargest(int[] nums, int k)
        //{
        //    var res = new int[k];
        //    int index = 0;
        //    for(int i = k; i > 0; i--)
        //    {
        //        res[index++] = QuickSearch(nums, 0, nums.Length - 1, i);
        //    }
        //    return res;
        //}  
        ////Find the Kth Largest element
        //public int FindKthLargest(int[] nums, int k)
        //{
        //    return QuickSearch(nums, 0, nums.Length - 1, k);
        //}
        //public int QuickSearch(int[] nums, int left, int right, int k)
        //{
        //    int j = Partition(nums, left, right);
        //    if(j == k - 1)
        //    {
        //        return nums[j];
        //    }
        //    return j > k - 1 ? QuickSearch(nums, left, j - 1, k) : QuickSearch(nums, j + 1, right, k);
        //}
        //public int Partition(int[] nums, int left, int right)
        //{
        //    int pivot = nums[left];
        //    int l = left, r = right + 1;
        //    while (true)
        //    {
        //        while (++l <= right && nums[l] > pivot) ;
        //        while (--r >= left && nums[r] < pivot) ;
        //        if(l < r)
        //        {
        //            int tmp = nums[l];
        //            nums[l] = nums[r];
        //            nums[r] = tmp;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    nums[left] = nums[r];
        //    nums[r] = pivot;
        //    return r;
        //}
        

       
        //桶排序 + Linq
        public IList<int> TopK(int[] nums, int k)
        {
            var cnt = new Dictionary<int, int>();
            foreach(var num in nums)
            {
                if (cnt.ContainsKey(num))
                    cnt[num]++;
                else
                    cnt.Add(num, 1);
            }
            var rec = new List<int>();
            foreach (var item in cnt)
            {
                rec.Add(item.Key);
            }
            rec.Sort(
                delegate(int num1, int num2){
                    return cnt[num1] == cnt[num2] ? num1.CompareTo(num2) : cnt[num2] - cnt[num1];
            }
                );
            return rec.GetRange(0, k);
        }
    }
        
    }
}
