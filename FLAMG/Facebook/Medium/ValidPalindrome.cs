using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Medium
{
    public class ValidPalindrome
    {

        //////////////////////
        // Valid Palindrome //
        //////////////////////

        //Two Pointers
        public bool IsPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return true;
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(s[right]))
                    right--;
                if (left < right)
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                        return false;
                    left++;
                    right--;
                }
            }
            return true;
        }


        /////////////////////////
        // Valid Palindrome II //
        /////////////////////////

        //Two pointers
        public bool ValidPalindromeII(string s)
        {
            if (s == null || s.Length == 0)
                return true;
            int left = 0, right = s.Length - 1;
            while(left < right)
            {
                if(s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else
                {
                    return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
                }
            }
            return true;
        }
        public bool IsPalindrome(string s, int left, int right)
        {
            while(left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }





        ////////////////////////
        // Longest Palindrome //
        ////////////////////////





        ///////////////////////
        // Palindrome Number //
        ///////////////////////





        ////////////////////////////
        // Palindrome Linked List //
        ////////////////////////////





        ///////////////////////////////////
        // Longest Palindromic Substring //
        ///////////////////////////////////





        //////////////////////////////////////
        // Longest Palindromic Substring II //
        //////////////////////////////////////







    }
}
