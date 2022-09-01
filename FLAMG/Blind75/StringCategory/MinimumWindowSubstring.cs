//using DotNetty.Common.Utilities;
//using Lucene.Net.Util;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FLAMG.Blind75.StringCategory
//{
    
//    internal class MinimumWindowSubstring
//    {
//        // 76. Minimum Window Substring
//        // return the minimum window substring of s such that every character in t (including duplicates) is included in the window.
//        // Slinding Window

//        public string MinWindow(string s, string t)
//        {
//            if (s.Length < t.Length)
//                return "";            
//            var need = new Dictionary<char, int>();
//            var window = new Dictionary<char, int>();
//            foreach (var ch in t)
//            {
//                if (need.ContainsKey(ch))
//                    need[ch]++;
//                else
//                    need[ch] = 1;
//            }
//            int left = 0, right = 0;
//            var valid = 0;
//            var minSub = "";
//            while (right < s.Length)
//            {
//                var ch = s[right];
//                right++;
//                if(window.ContainsKey(ch))
//                    window[ch]++;
//                else
//                    window[ch] = 1;
//                if (need.ContainsKey(ch))
//                {
//                    if (need[ch] == window[ch])
//                        valid++;
//                }
//                while(valid >= need.Count)
//                {
//                    if(valid == need.Count)
//                    {
//                        if(minSub == "" || minSub.Length > right - left)
//                            minSub = s.Substring(left, right - left);
//                    }
//                    var del = s[left];
//                    left++;
//                    if (need.ContainsKey(del) && window[del] == need[del])
//                        valid--;
//                    if(window[del] > 1)
//                        window[del]--;
//                    else
//                        window.Remove(del);
//                }
//            }
//            return minSub == "" ? "" : minSub;
//        }

//        // 239. Sliding Window Maximum
//        // sliding window

//        public int[] MaxSlidingWindow(int[] nums, int k)
//        {
//            var window = new Dictionary<int, int>();
//            var result = new List<int>();
//            int left = 0, right = 0;
//            while(right < nums.Length)
//            {
//                var num = nums[right];
//                right++;
//                if(window.ContainsKey(num))
//                    window[num]++;
//                else
//                    window[num] = 1;
//                while(right - left >= k)
//                {
//                    if(right - left == k)
//                    {
//                        var max = window.Keys.Max();
//                        result.Add(max);
//                    }
//                    var del = nums[left];
//                    left++;
//                    if (window[del] > 1)
//                        window[del]--;
//                    else
//                        window.Remove(del);
//                }
//            }
//            return result.ToArray();
//        }

//        public class MyComparer : IComparer<int[]>
//        {
//            public int Compare(int[] a, int[] b)
//            {
//                return a[0] != b[0] ? b[0] - a[0] : b[1] - a[1];
//            }
//        }

//        //// Priority Queue
//        //public int[] MaxSlidingWindow1(int[] nums, int k)
//        //{
//        //    int n = nums.Length;
//        //    var pq = new PriorityQueue<int, int>(new MyComparer<int[]>());
//        //    for(int i = 0; i < k; i++)
//        //    {
//        //        pq.Enqueue(new int[] { nums[i], i });
//        //    }
//        //    var ans = new int[n - k + 1];
//        //    ans[0] = pq.Peek();
//        //    for(int i = k; i < n; i++)
//        //    {
//        //        pq.Enqueue();
//        //        while(pq.Peek()[1] < i - k)
//        //            pq.Dequeue();
//        //        ans[i - k + 1] = pq.Peek()[0];
//        //    }
//        //    return ans;
//        //}

//        // 727. Minimum Window Subsequence
//        public string MinWindow(string s1, string s2)
//        {
//            if (s1.Length < s2.Length)
//                return "";
            
//        }

//        // 30. Substring with Concatenation of All Words
//        // 
//        public IList<int> FindSubstring(string s, string[] words)
//        {            
//            var permutations = new HashSet<string>();
//            var visited = new bool[words.Length];
//            GetPermutation(words, new List<string>(), permutations, visited);
//            var len = permutations.Count;
//            var result = new List<int>();
//            if (s.Length < len)
//                return null;            
//            for(int i = 0; i <= s.Length - len; i++)
//            {
//                if (permutations.Contains(s.Substring(i, len)))
//                    result.Add(i);
//            }
//            return result;
//        }
//        //public void GetPermutation(string[] words, int start, IList<string> track, HashSet<string> permutations, bool[] visited)
//        //{
//        //    if(track.Count == words.Length)
//        //    {
//        //        permutations.Add(new string(track.ToString()));
//        //        return;
//        //    }

//        //    visited[start] = true;
//        //    track.Add(words[start]);
//        //    GetPermutation(words, start + 1, track, permutations, visited);
//        //    track.Remove(words[start]);
//        //    visited[start] = false;
//        //}
//        public void GetPermutation(string[] words, IList<string> track, HashSet<string> ans, bool[] visited)
//        {
//            if(track.Count == words.Length)
//            {
//                ans.Add(new string(track.ToString()));
//                return;
//            }
//            for(int i = 0; i < words.Length; i++)
//            {
//                if (visited[i])
//                    continue;
//                visited[i] = true;
//                track.Add(words[i]);
//                GetPermutation(words, track, ans, visited);
//                track.Remove(words[i]);
//                visited[i] = false;
//            }
//        }

//        public IList<int> FindSubstring_SlidingWindow(string s, string[] words)
//        {
//            var need = new Dictionary<char, int>();
//            var window = new Dictionary<char, int>();
//            foreach (var word in words)
//            {
//                foreach (var ch in word)
//                {
//                    if (need.ContainsKey(ch))
//                        need[ch]++;
//                    else
//                        need[ch] = 1;
//                }
//            }

//            int left = 0, right = 0;
//            var valid
//            while(right < s.Length)
//            {
//                var ch = s[right];
//                right++;
//                if()
//            }
//        }
//    }
//}
