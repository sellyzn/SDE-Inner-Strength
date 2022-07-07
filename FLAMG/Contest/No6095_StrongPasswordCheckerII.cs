using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class No6095_StrongPasswordCheckerII
    {
        public bool StrongPasswordCheckerII(string password)
        {
            if (password.Length < 8)
                return false;
            var set = new HashSet<char>();
            set.Add('!');
            set.Add('@');
            set.Add('#');
            set.Add('$');
            set.Add('%');
            set.Add('^');
            set.Add('&');
            set.Add('*');
            set.Add('(');
            set.Add(')');
            set.Add('-');
            set.Add('+');
            int hasLower = 0, hasUpper = 0, hasDigit = 0, hasSpecialChar = 0;
            foreach (var ch in password)
            {
                if (char.IsLower(ch))
                    hasLower = 1;
                else if (char.IsUpper(ch))
                    hasUpper = 1;
                else if (char.IsDigit(ch))
                    hasDigit = 1;
                else if(set.Contains(ch))
                    hasSpecialChar = 1;
            }
            if (hasLower == 0 || hasUpper == 0 || hasDigit == 0 || hasSpecialChar == 0)
                return false;
            for(int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1])
                    return false;
            }
            return true;
        }


        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {            
            int n = spells.Length;
            int m = potions.Length;
            Array.Sort(potions);
            var result = new int[n];
            for(int i = 0; i < n; i++)
            {
                var count = 0;
                int left = 0, right = m - 1;
                while(left <= right)
                {
                    int mid = left + (right - left) / 2;
                    var product = (long)spells[i] * potions[mid];
                    if (product < success)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                count = m - left;
               
                result[i] = count;
            }
            return result;
        }

        public bool MatchReplacement(string s, string sub, char[][] mappings)
        {

        }
        public long CountSubarrays(int[] nums, long k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (k < 1)
                return 0;
            var count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                var prod = 0;
                for(int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    prod = sum * (j - i + 1);
                    if (prod < k)
                        count++;
                }
            }
            return count;
        }
    }
}
