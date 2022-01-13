using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeII
{
    public class LegalIdentifier
    {
        public bool IsLegalIdentifier(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            if (str[0] >= '0' && str[0] <= 9)
                return false;
            foreach (var c in str)
            {
                if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '_'))
                    return false;
            }
            return true;
        }

        public int Count(string s)
        {
            bool status = true;
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (status && s[i] >= 'a' && s[i] <= 'z')
                    res++;
                if (s[i] >= 'a' && s[i] <= 'z' || s[i] >= 'A' && s[i] <= 'Z')
                    status = false;
                if (s[i] == '.')
                    status = true;
                if (i > 0 && (s[i - 1] >= 'a' && s[i - 1] <= 'z' || s[i - 1] >= 'A' && s[i - 1] <= 'Z') && s[i] >= 'A' && s[i] <= 'Z')
                    res++;
            }
            return res;
        }
    }
}
