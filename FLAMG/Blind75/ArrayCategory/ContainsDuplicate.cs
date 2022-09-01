using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class ContainsDuplicate
    {
        // 217. Contains Duplicate
        // sort + traverse
        // T: O(NlogN)
        // S: O(logN)
        public bool ContainsDuplicateI_Sort(int[] nums)
        {
            Array.Sort(nums);
            if(nums == null || nums.Length <= 1)
                return false;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if(nums[i] == nums[i + 1])
                    return true;
            }
            return false;
        }

        // HashSet
        public bool ContainsDuplicateI_Hashset(int[] nums)
        {
            var set = new HashSet<int>();
            if (nums == null || nums.Length <= 1)
                return false;
            for(int i = 0; i < nums.Length; i++)
            {
                if(set.Contains(nums[i]))
                    return true;
                set.Add(nums[i]);
            }
            return false;
        }
        
        // 219. Contains Duplicate II
        // nums[i] == nums[j], abs(i - j) <= k
        // sliding window, window size is k, 判断在滑动窗口中能否找到两个相等的值，HashMap

        /*
                l
        nums: 1 2 3 1 2 3       k = 2
                    r
        window:{{2，1}，{3，1}}


         */
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1)
                return false;
            if (k == 0)
                return false;
            var window = new Dictionary<int, int>();
            int left = 0, right = 0;
            while (right < nums.Length)
            {

                var num = nums[right];
                right++;
                if (window.ContainsKey(num))
                    return true;
                else
                    window[num] = 1;

                if (right - left > k)
                {
                    var del = nums[left];
                    left++;
                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
            }
            return false;
        }

        // 更清晰易理解
        public bool ContainsNearbyDuplicate1(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1)
                return false;
            if (k == 0)
                return false;
            var window = new Dictionary<int, int>();
            int left = 0, right = 0;
            while (right < nums.Length)
            {
                var num = nums[right];
                right++;
                if (window.ContainsKey(num))
                    window[num]++;
                else
                    window[num] = 1;
                if (right - left > k)
                {
                    var del = nums[left];
                    left++;
                    if (right - left == k)
                    {
                        if (window[num] > 1)
                            return true;
                    }

                    if (window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
                if (window[num] > 1)
                    return true;
            }
            return false;
        }

        // Use a hashtable, store the num and the largest index
        public bool ContainsNearbyDuplicate_Hashtable(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            int length = nums.Length;
            for(int i = 0; i < length; i++)
            {
                var num = nums[i];
                if (dict.ContainsKey(num) && i - dict[num] <= k)
                    return true;
                if (dict.ContainsKey(num))
                    dict[num] = i;
                else
                    dict.Add(num, i);
            }
            return false;
        }

        // 220. Contains Duplicate III
        // sorted set
        // 根据题意，对于任意一个位置i（假设其值为u），我们希望在下标范围为[max(0,i-k),i)内找到值范围在[u-t,u+t]的数。
        // 我们需要在大小为k的滑动窗口所在的有序集合中找到与u接近的数
        // 查询：能够在有序集合中快速找到【小于等于u的最大值】和【大于等于u的最小值】（即有序集合中的最接近u的数）
        // 插入/删除： 在忘有序集合中添加或删除元素时，能够在低于线性的复杂度内完成（维持有序特性）

        // 如果将k个数字分到k个桶的化，那么我们就能O(1)的复杂度确定是否有[u-t,u+t]的数字（检查目标桶是否有元素）

        /*
                  i
        nums: 1 5 9 1 5 9,  k = 2,  t = 3

        u:  9
        l:  5
        r:  9
        set:[1,5]


         */
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            //var n = nums.Length;
            //var set = new SortedSet<int>();
            //for(int i = 0;i < n; i++)
            //{
            //    long ceiling = (long)Math.Ceiling((decimal)((long)nums[i] - (long)t));
            //    if(ceiling != null && ceiling <= (long)nums[i] + (long)t)
            //        return true;
            //    set.Add(nums[i]);
            //    if (i >= k)
            //        set.Remove(nums[i - k]);
            //}
            //return false;
            if (nums == null || nums.Length <= 1)
                return false;
            if (k == 0)
                return false;
            var n = nums.Length;
            var set = new SortedSet<long>();
            set.Add((long)nums[0]);
            for(int i = 0; i < n; i++)
            {
                long u = (long)nums[i];     
                // 从set中找到小于等于u的最大值（小于等于u的最接近u的数）
                long l = set.Min > u ? u + 1 : set.GetViewBetween(long.MinValue, u).Max;
                // 从set中招待大于等于u的最小值（大于等于u的最接近u的数）
                long r = set.Min < u ? u - 1: set.GetViewBetween(u, long.MaxValue).Min;

                if(l <= u && u - l <= t)
                    return true;
                if (r >= u && r - u <= t)
                    return true;
                // 将当前数加到 ts 中，并移除下标范围不在 [max(0, i - k), i) 的数（维持滑动窗口大小为 k）
                set.Add(u);
                if (i >= k)
                    set.Remove((long)nums[i - k]);

            }

            return false;
        }

        public bool ContainsNearbyAlmostDuplicate1(int[] nums, int k, int t)
        {
            var n = nums.Length;
            var map = new Dictionary<long, long>();
            var size = (long)(t + 1);
            for(int i = 0; i < n; i++)
            {
                long u = (long)(nums[i]);
                long idx = GetIdx(u, size);
                // 目标桶已存在（桶不为空），说明前面已有[u-t,u+t]范围的数字
                if (map.ContainsKey(idx))
                    return true;
                // 检查相邻的桶
                long l = idx - 1, r = idx + 1;
                if (map.ContainsKey(l) && u - map[l] <= t)
                    return true;
                if (map.ContainsKey(r) && map[r] - u <= t)
                    return true;
                // 建立目标桶,走到这里，说明没有满足要求的，先把当前的元素放到桶里，等待下一次比较
                map.Add(idx, u);
                // 移除下标范围不在[max(0,i-k),i)内的桶
                if (i >= k)
                    map.Remove(GetIdx(nums[i - k], size));
            }
            return false;
        }
        public long GetIdx(long u, long size)
        {
            return u >= 0 ? u / size : ((u + 1) / size) - 1;
        }

    }
}
