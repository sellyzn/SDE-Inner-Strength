using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1487_MakingFileNamesUnique
    {
        public string[] GetFolderNames(string[] names)
        {
            if(names == null || names.Length == 0)
                return null;
            var result = new List<string>();
            var dict = new Dictionary<string, int>();
            for(int i = 0; i < names.Length; i++)
            {
                var key = GetKey(names[i]);
                var value = GetValue(names[i]);                
                
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, value);                    
                }
                else
                {
                    dict[key]++;              
                }
                var output = GetOutput(key, value);
                result.Add(output);
            }
            return result.ToArray();
                
        }
        public string GetKey(string s)
        {
            var index = 0;
            while (index < s.Length && s[index] != '(')
                index++;
            if (index == s.Length)
                return s;
            else
                return s.Substring(0, index);
        }
        public int GetValue(string s)
        {
            var left = 0;
            while (left < s.Length && s[left] != '(')
                left++;
            if (left == s.Length)
                return 0;
            
            int right = left;
            while (right < s.Length && s[right] != ')')
                right++;
            return int.Parse(s.Substring(left, right - left));
            
        }
        public string GetOutput(string key, int value)
        {
            if (value == 0)
                return key;
            else
                return key + "(" + value + ")";
        }



    }
}
