using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class Interview
    {
    }
}
// Given a list of strings, return the longest prefix the strings have in common
// EX # 1: 
// Input -> "expedia", "expedite", "express"
// m = 7, n = 8
// index = 6
// expedi

// m = words.Length
// n = words[i].Length
//T: O(m*n)
// S: O(n)

// expedi express
// exp
// n, m
// Output -> "exp"
// EX # 2:
// Input -> "cat", "dog", "aardvark"
// Output -> ""
// EX # 3:
// Input -> "puppy"
// Output -> "puppy"

using System;
using System.Collections.Generic;
using System.IO;
class Solution
{

    /*
    */
    static String FindLongestCommonPrefix(List<String> words)
    {
        // corner case
        if (words == null || words.Length == 0)
            return “”；
        if (words.Length == 1)
            return words[0];
        var prefix = GetCommonPrefix(words[0], words[1]);
        for (int i = 2; i < words.Length; i++)
        {
            prefix = GetCommonPrefix(prefix, words[i]);
        }
        return prefix;
    }
    public string GetCommonPrefix(string s1, string s2)
    {
        var index = 0;
        var m = s1.Length;
        var n = s2.Length;
        while (index < m && index < n)
        {
            if (s1[index] == s2[index])
                index++;
            else
                break;
        }
        return index == 0 ? "" : s1.Substring(0, index);
    }


}

