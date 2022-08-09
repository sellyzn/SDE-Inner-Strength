using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No443_StringCompression
    {
        public int Compress(char[] chars)
        {
            if (chars == null || chars.Length == 0)
                return 0;
            int left = 0, right = 0;
            var sb = new StringBuilder();
            while(right < chars.Length)
            {
                while (right < chars.Length && chars[right] == chars[left])
                    right++;
                int length = right - left;
                if (length == chars.Length)
                {
                    return chars.Length;
                }
                else
                {
                    if (length == 1)
                    {
                        sb.Append(chars[left]);
                    }
                    else
                    {
                        sb.Append(chars[left] + length.ToString());
                    }
                }
                left = right;
            }
            return sb.ToString().Length;
        }
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int Compress1(char[] chars)
        {
            if (chars == null || chars.Length == 0)
                return 0;
            int left = 0, right = 0, index = 1;
            Console.WriteLine($"index: {index}");
            while (right < chars.Length)
            {
                while (right < chars.Length && chars[right] == chars[left])
                    right++;
                int length = right - left;
                var str = length.ToString();

                if (length > 1)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        chars[index] = str[i];
                        index++;
                    }
                }
                if (right < chars.Length)
                {
                    chars[index] = chars[right];
                    index++;
                }
                left = right;
            }
            return index;
        }
    }
}
