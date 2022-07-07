using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class No2296_DesignATextEditor
    {
        public No2296_DesignATextEditor()
        {
            a = new Stack<char>();
            b = new Stack<char>();
        }

        Stack<char> a, b;

        public void AddText(String text)
        {
            char[] array = text.ToCharArray();
            foreach (char c in array)
            {
                a.Push(c);
            }
        }

        public int DeleteText(int k)
        {
            int target = k;
            while (k > 0 && a.Count > 0)
            {
                a.Pop();
                k--;
            }
            return target - k;
        }

        public String CursorLeft(int k)
        {
            while (a.Count > 0 && k > 0)
            {
                b.Push(a.Pop());
                k--;
            }
            return ReadLeftChar();
        }

        private String ReadLeftChar()
        {
            if (a.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            while (sb.Length < 10 && a.Count > 0)
            {
                sb.Insert(0,a.Pop());
            }
            
            AddText(sb.ToString());
            return sb.ToString();
        }

        public String CursorRight(int k)
        {

            while (b.Count > 0 && k > 0)
            {
                a.Push(b.Pop());
                k--;
            }
            return ReadLeftChar();
        }

        
    }
}
