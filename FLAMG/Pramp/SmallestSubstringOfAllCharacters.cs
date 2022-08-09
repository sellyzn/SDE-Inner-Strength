using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Pramp
{
    internal class SmallestSubstringOfAllCharacters
    {
        /// <summary>
        /// Sliding Window
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetShortestUniqueSubstring(char[] arr, string str)
        {            
            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();

            foreach (var ch in arr)
            {
                if (need.ContainsKey(ch))
                    need[ch]++;
                else
                    need[ch] = 1;
            }

            int left = 0, right = 0;
            int valid = 0;
            int startIndex = 0, len = int.MaxValue;
            while(right < str.Length)
            {
                var ch = str[right];
                right++;

                if (need.ContainsKey(ch))
                {
                    if(window.ContainsKey(ch))
                        window[ch]++;
                    else
                        window[ch] = 1;

                    if (window[ch] == need[ch])
                        valid++;
                }

                // 判断左侧窗口是否要收缩
                while(valid == need.Count)
                {
                    // 在这里更新最小覆盖子串
                    if(right - left < len)
                    {
                        startIndex = left;
                        len = right - left;
                    }
                    var d = arr[left];
                    left++;
                    if (need.ContainsKey(d))
                    {
                        if(window[d] == need[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return len == int.MaxValue ? "" : str.Substring(startIndex, len);
        }
    }
}
