using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class FindTheStudentThatWillReplaceTheChalk
    {
        public int ChalkReplacer(int[] chalk, int k)
        {
            int n = chalk.Length;
            long total = 0;
            foreach (var num in chalk)
            {
                total += num;
            }
            if(k >= total)
            {
                k %= (int)total;
            }
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                if (chalk[i] > k)
                {
                    res = i;
                    break;
                }
                k -= chalk[i];
            }
            return res;
        }

        // prefix sum and binary search
        public int ChalkReplacerI(int[] chalk, int k)
        {
            int n = chalk.Length;
            if (chalk[0] > k)
                return 0;
            for(int i = 1; i < n; i++)
            {
                chalk[i] += chalk[i - 1];
                if (chalk[i] > k)
                    return i;
            }
            k %= chalk[n - 1];
            return BinarySearch(chalk, k);
        }
        public int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] <= target)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }
    }
}
