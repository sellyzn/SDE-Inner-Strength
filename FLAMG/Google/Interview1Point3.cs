using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google
{
    public class Master
    {
        public int Guess(string word);
    }
    public class Interview1Point3
    {
        public void FindSecretWord(string[] wordlist, Master master)
        {
            for(int i = 0, count = 0; i < 10 && count < 6; i++)
            {
                int rand = new Random().Next();
                string guess = wordlist[rand % (wordlist.Length)];
                count = master.Guess(guess);
                List<string> t = new List<string>();
                foreach(var word in wordlist)
                {
                    if(Match(guess, word) == count)
                        t.Add(word);
                }
                 wordlist = t.ToArray();
            }
        }
        public int Match(string a, string b)
        {
            if (a == null || a.Length == 0 || b == null || b.Length == 0)
                return 0;
            int res = 0, n = Math.Min(a.Length, b.Length);
            for (int i = 0; i < n; i++)
            {
                if (a[i] == b[i])
                    res++;
            }
            return res;
        }
    }
}
