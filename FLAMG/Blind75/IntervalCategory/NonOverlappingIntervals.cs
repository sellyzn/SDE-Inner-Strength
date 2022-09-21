using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.IntervalCategory
{
    internal class NonOverlappingIntervals
    {
        // 435. Non-overlapping Intervals
        // 动态规划
        // dp[i]表示以区间i为最后一个区间，可以选出的区间数量的最大值
        // dp[i] = max(dp[j]) + 1, j < i, rj <= li
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            int n = intervals.Length;
            var dp = new int[n];
            for(int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }
            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(intervals[j][1] <= intervals[i][0])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            return n - dp.Max();
        }

        /*
        贪心：
        我们不妨想一想应该选择哪一个区间作为首个区间。

        假设在某一种最优的选择方法中，[l_k, r_k]是首个（即最左侧的）区间，那么它的左侧没有其它区间，右侧有若干个不重叠的区间。
        设想一下，如果此时存在一个区间 [l_j, r_j]，使得 r_j < r_k，即区间 jj 的右端点在区间 k 的左侧，那么我们将区间 k 替换为区间 j，其与剩余右侧被选择的区间仍然是不重叠的。
        而当我们将区间 k 替换为区间 j 后，就得到了另一种最优的选择方法。

        我们可以不断地寻找右端点在首个区间右端点左侧的新区间，将首个区间替换成该区间。那么当我们无法替换时，首个区间就是所有可以选择的区间中右端点最小的那个区间。
        因此我们将所有区间按照右端点从小到大进行排序，那么排完序之后的首个区间，就是我们选择的首个区间。

        如果有多个区间的右端点都同样最小怎么办？由于我们选择的是首个区间，因此在左侧不会有其它的区间，那么左端点在何处是不重要的，我们只要任意选择一个右端点最小的区间即可。

        当确定了首个区间之后，所有与首个区间不重合的区间就组成了一个规模更小的子问题。由于我们已经在初始时将所有区间按照右端点排好序了，因此对于这个子问题，我们无需再次进行排序，
        只要找出其中与首个区间不重合并且右端点最小的区间即可。用相同的方法，我们可以依次确定后续的所有区间。

         */
        public int EraseOverlapIntervals2(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;
            intervals = intervals.OrderBy(x => x[1]).ToArray();

            var n = intervals.Length;
            var right = intervals[0][1];
            var ans = 1;
            for(int i = 1; i < n; i++)
            {
                if(intervals[i][0] >= right)
                {
                    ans++;
                    right = intervals[i][1];
                }
            }
            return n - ans;
        }

        // 646. Maximum Length of Pair Chain
        public int FindLongestChain(int[][] pairs)
        {
            if (pairs == null || pairs.Length == 0)
                return 0;
            if (pairs.Length == 1)
                return 1;
            pairs = pairs.OrderBy(x => x[1]).ToArray();

            var n = pairs.Length;
            var ans = 1;
            var right = pairs[0][1];
            for(int i = 1; i < n; i++)
            {
                if(pairs[i][0] > right)
                {
                    ans++;
                    right = pairs[i][1];
                }
            }
            return ans;
        }

        // 452. Minimum Number of Arrows to Burst Balloons
        public int FindMinArrowShots(int[][] points)
        {
            if (points == null || points.Length == 0)
                return 0;
            if (points.Length == 1)
                return 1;
            points = points.OrderBy(x => x[1]).ToArray();
            int n = points.Length;
            int right = points[0][1];
            int ans = 1;
            for(int i = 1;i < n; i++)
            {
                if(points[i][0] > right)
                {
                    right = points[i][1];
                    ans++;
                }
            }
            return ans;
        }

        // 300. Longest Increasing Subsequence
        // dp[i]: 以nums[i]结尾的最长严格递增子序列
        // DP
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;
            var dp = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }
            for(int i = 1;i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            return dp.Max();
        }
        // Greedy + Binary Search + DP
        /*
        降低复杂度： 解法一DP中，遍历计算dp数组需要O(N), 计算每个dp[k]需要O(N).
        1. 动态规划中，通过线性遍历来计算dp的复杂度无法降低
        2. 每轮计算中，需要通过线性遍历[0,k)区间元素来得到dp[k]。我们考虑：是否可以通过重新设计状态定义，
        使整个dp为一个排序列表；这样再计算每个dp[k]时，就可以通过二分法遍历[0,k)区间元素，将此部分复杂度有O(N)降到O(logN)。

        新的状态定义：
            维护一个列表tails,其中每个元素tails[k]的值代表长度为 k+1 的子序列尾部元素的值。
        状态转移设计：
            设常量数字N， 和随机数字x， 可以推出： 当N越小时，N < x的几率越大。
            在遍历计算每个tails[k]，不断更新长度为[1,k]的子序列尾部元素值，始终保持每个尾部元素值最小。
        tails列表一定是严格递增的


        */

        /*
        tails[k]: 表示长度为 K + 1 子序列的尾部元素最小值
        res: 为tails当前长度，代直到当前的最长上升子序列长度。

        比如序列是78912345，前三个遍历完以后tail是789，这时候遍历到1，就得把1放到合适的位置，
        于是在tail二分查找1的位置，变成了189（如果序列在此时结束，因为res不变，所以依旧输出3），
        再遍历到2成为129，然后是123直到12345

         */
        public int LengthOfLIS2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;

            var dp = new int[nums.Length];
            var end = 0;
            dp[0] = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                // 【逻辑1】比 tail 数组实际有效的末尾的那个元素还大
                if (nums[i] > dp[end])
                {
                    // 直接添加在那个元素的后面，所以 end 先加 1
                    end++;
                    dp[end] = nums[i];
                }
                else
                {
                    // 使用二分查找法，在有序数组 tail 中
                    // 找到第 1 个大于等于 nums[i] 的元素，尝试让那个元素更小
                    int left = 0, right = end;
                    while(left < right)
                    {
                        int mid = left + (right - left) / 2;
                        if(dp[mid] < nums[i])
                        {
                            // 中位数肯定不是要找的数，把它写在分支的前面
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid;
                        }                        
                    }
                    // 走到这里是因为 【逻辑 1】 的反面，因此一定能找到第 1 个大于等于 nums[i] 的元素
                    // 因此，无需再单独判断
                    dp[left] = nums[i];
                }
            }

            // end 是有序数组 tail 最后一个元素的索引
            // 题目要求返回的是长度，因此 +1 后返回
            return end + 1;
        }
    }
}
