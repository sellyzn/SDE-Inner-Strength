using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No438_FindAllAnagramsInAString
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();
            if(s.Length < p.Length)
                return result;
            for(int i = 0; i + p.Length <= s.Length && i < s.Length; i++)
            {
                var str = s.Substring(i, p.Length);
                if (IsAnagrams(str, p))
                    result.Add(i);
            }
            return result; 
        }
        public bool IsAnagrams(string s, string p)
        {
            //var strArrS = s.ToArray();
            //Array.Sort(strArrS);
            //var keyS = new string(strArrS);
            //var strArrP = p.ToArray();
            //Array.Sort(strArrP);
            //var keyP = new string(strArrP);
            //if (keyS.Equals(keyP))
            //    return true;
            //return false;

            var dict = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict.Add(ch, 1);                
            }
            foreach (var ch in p)
            {
                if (dict.ContainsKey(ch))
                    dict[ch]--;
                else
                    return false;
            }
            foreach (var item in dict)
            {
                if (item.Value != 0)
                    return false;
            }

            return true;

            //var dictP = new Dictionary<char, int>();
            //foreach (var ch in p)
            //{
            //    if (dictP.ContainsKey(ch))
            //        dictP[ch]++;
            //    else
            //        dictP.Add(ch, 1);
            //}
            //return dictS.Equals(dictP);
        }

        /// <summary>
        /// Sliding Window
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<int> FindAnagrams1(string s, string p)
        {
            // 用于存储目标字符串p中的字符及对应频率
            Dictionary<char, int> need = new Dictionary<char, int>();
            // 用于记录滑动窗口中字符及其频率
            Dictionary<char, int> window = new Dictionary<char, int>();

            List<int> res = new List<int>();

            // 记录目标字符串p中的字符及对应频率
            foreach (char c in p)
            {
                if (need.ContainsKey(c))
                    need[c]++;
                else
                    need[c] = 1;
            }

            // 同向双指针，记录滑动窗口两端位置
            int left = 0, right = 0;
            // valid 记录滑动窗口中与目标字符串中字符及其频率匹配的个数
            int valid = 0;
            while (right < s.Length)
            {
                char c = s[right];
                right++;

                if (need.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window[c] = 1;
                    
                    if (window[c] == need[c])
                        valid++;
                }

                // 保持窗口的长度为目标字符串长度 p.Length 大小
                // 滑动窗口记录的有效字符串长度长度为[left, right)
                while (right - left >= p.Length)
                {

                    if (valid == need.Count())
                        res.Add(left);
                    char d = s[left];
                    left++;
                    if (need.ContainsKey(d))
                    {
                        //先更新valid，再更新window，顺序不能反
                        if (window[d] == need[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return res;
        }

    }
}
