using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class MaximumNumberOfRemovableCharacters
    {
        public int MaximumRemovals(string s, string p, int[] removable)
        {
            var str0 = s.ToCharArray();
            var str1 = p.ToCharArray();
            int ans = 0;
            int left = 1; //左边界
            int right = removable.Length;//右边界
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if(Check(mid, str0, str1, removable))
                {
                    ans = mid;//进入条件说明满足，当前的mid就是候选答案之一，最后一个满足要求的mid就一定是答案
                    left = mid + 1;// 当前mid满足的话，我们九月去尝试更大的数值，以缩小答案的范围
                }
                else//不满足
                {
                    right = mid - 1;//就要尝试更小的数，寻找能满足的
                }
                str0 = s.ToCharArray();//我们在Check方法中改变了str0的值，所以要重新赋值
            }
            return ans;
        }
        // 作用是删除前mid个removable所指的位置的字符后，是否还能满足p是s的子序列，如果满足返回true
        public bool Check(int mid, char[] str0, char[]str1, int[] removable)
        {
            for(int i = 0; i < mid; i++)//将前mid个removable中指的字符“删除”
            {
                str0[removable[i]] = '1';
            }
            int j = 0;
            for (int i = 0; i < str0.Length; i++)//判断p是不是s的子序列
            {
                if(j < str1.Length)
                {
                    if (str1[j] == str0[i])
                        j++;
                }
                else//已遍历完p，即可说明p是s的子序列
                {
                    return true;
                }
            }
            if (j == str1.Length)//已遍历完p，即可说明p是s的子序列
                return true;
            return false;//已遍历完s但是没有完全找到p对应的字符，即p不是s的子序列
        }
    }
}
