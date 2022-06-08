using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No93_RestoreIPAddresses
    {
        //IList<string> res = new List<string>();
        //static int SegCount = 4;
        //int[] segments = new int[SegCount];

        //public IList<string> RestoreIpAddresses(string s)
        //{
        //    DFS(s, 0, 0);
        //    return res;
        //}
        //public void DFS(string s, int segId, int segStart)
        //{
        //    // 如果找到了4段IP地址并遍历完了字符串，那么就是一种答案
        //    if(segId == SegCount)
        //    {
        //        if(segStart == s.Length)
        //        {
        //            var ipAddr = new StringBuilder();
        //            for(int i = 0; i < SegCount; i++)
        //            {
        //                ipAddr.Append(segments[i]);
        //                if(i != SegCount - 1)
        //                    ipAddr.Append(".");
        //            }
        //            res.Add(ipAddr.ToString());
        //        }
        //        return;
        //    }

        //    // 如果还没有找到4段IP地址就已经遍历完了字符串，那么提前回溯
        //    if (segStart == s.Length)
        //        return;

        //    // 由于不能有前导零，如果当前数字为0， 那么这一段IP地址只能为0
        //    if(s[segStart] == '0')
        //    {
        //        segments[segId] = 0;
        //        DFS(s, segId + 1, segStart + 1);
        //    }

        //    // 一般情况，枚举每一种可能性并递归
        //    int addr = 0;
        //    for(int segEnd = segStart; segEnd < s.Length; segEnd++)
        //    {
        //        addr = addr * 10 + (s[segEnd] - '0');
        //        if(addr > 0 && addr < 0xFF)
        //        {
        //            segments[segId] = addr;
        //            DFS(s, segId + 1, segStart + 1);
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //}

        /// <summary>
        /// Backtrack
        /// T: O((3^segCount) * |s|)， 由于IP地址的每一段的位数不会超过3，因此在递归的每一层，我们最多只会深入到下一层的3中情况。
        ///     由于segCount = 4,对应着递归的最大层数，所以递归本身的时间复杂度为O(3^segCount)。 
        ///     如果我们复原出了一种满足题目要求的IP地址，需要O(|s|)的时间将其加入答案数组中，因此总的时间复杂度为O((3^segCount) * |s|)。
        /// S: O(segCount), 因为值额外使用了长度为segCount的数组subRes来存储已经搜索过的IP地址。只计入除了用来存储答案数组以外的额外空间复杂度。
        /// </summary>
        IList<string> res;
        IList<string> subRes;
        public IList<string>  RestoreIpAdresses(string s)
        {
            int n = s.Length;
            res = new List<string>();
            subRes = new List<string>();            
            Backtrack(s, 0);
            return res;
        }
        public void Backtrack(string s, int start)
        {
            // 如果start等于s的长度并且ip段的数量是4，则加入结果集，并返回
            if (start == s.Length && subRes.Count == 4)
            {
                var str = subRes[0];
                for(int i = 1; i < subRes.Count; i++)
                {
                    str += "." + subRes[i];
                }
                res.Add(str);
                return;
            }

            // 如果start等于s的长度但是ip段的数量不为4，或者ip段的数量为4但start小于s的长度，则直接返回
            if (start == s.Length || subRes.Count == 4)
                return;
            
            //选择，每一小段最多3个字符
            for(int len = 1; len <= 3; len++)
            {
                // 保证后续s.Substring(start, len)合法，注意应该是start + len - 1
                if (start + len - 1 >= s.Length)
                    return;
                if (len != 1 && s[start] == '0')
                    return;
                var str = s.Substring(start, len);
                if (len == 3 && int.Parse(str) > 255)
                    return;
                subRes.Add(str);
                Backtrack(s, start + len); //起始位置应从start + len开始
                subRes.RemoveAt(subRes.Count - 1);
            }
        }

    }
}
