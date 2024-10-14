using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P1768_MergeStringsAlternately
    {
        /*
         双指针模拟
         index1, index2分别指向word1,word2，初始值都为0，StringBuilder result存储结果
         while循环，循环条件index1 < word1.Length || index2 < word2.Length
         当index1 < word1.Length时，将word1[index1]加入到result中，index1++
         当index2 < word2.Length时，将word2[index2]加入到result中，index2++
         当index1和index2都超出对应的范围后，结束循环并返回答案
         time: O(m+n)
         space:O()
         */   
        public string MergeAlternately(string word1, string word2)
        {
            int index1 = 0, index2 = 0;
            StringBuilder result = new StringBuilder();
            //while(index1 < word1.Length && index2 < word2.Length)
            //{
            //    result.Append(word1[index1]);
            //    index1++;
            //    result.Append(word2[index2]);
            //    index2++;
            //} 
            //while(index1 < word1.Length)
            //{
            //    result.Append(word1[index1]);
            //}
            //while(index2 < word2.Length)
            //{
            //    result.Append(word2[index2]);
            //}
            while(index1 < word1.Length || index2 < word2.Length)
            {
                if(index1 < word1.Length)
                {
                    result.Append(word1[index1]);
                    index1++;
                }
                if(index2 < word2.Length)
                {
                    result.Append(word2[index2]);
                    index2++;
                }
            }
            return result.ToString();
        }
    }
}
