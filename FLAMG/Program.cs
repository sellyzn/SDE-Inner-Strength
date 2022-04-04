using FLAMG.Amazon.Easy;
using FLAMG.Facebook.Easy;
using FLAMG.Microsoft.Easy;
using FLAMG.Microsoft.Medium;
using FLAMG.Other;
using FLAMG.Other.Gold.GoldII;
using FLAMG.Other.Silver.SilverII;
using FLAMG.Other.Silver.SilverIII;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "[]{{}}";
            //var vp = new ValidParentheses();
            //var res = vp.IsValid(s);
            //Console.WriteLine(res);

            //int n = 3;
            //var ans = vp.GenerateParentheses(n);
            //foreach (var item in ans)
            //{
            //    Console.WriteLine(item);
            //}

            //var interval = new int[][] { new int[] { 0, 3 }, new int[] { 2, 6 }, new int[] { 0, 1 }, new int[] { 10, 12 }, new int[] { 1, 9 } };

            //MergeInterval a = new MergeInterval();
            //a.Merge(interval);

            //string s = "trreeeeddd";
            //FirstUniqueCharacter fc = new FirstUniqueCharacter();

            //Console.WriteLine(fc.FrequencySort(s));

            //var li = new List<char>();
            //li.Insert(0, '0');
            //li.Insert(1, '0');
            //li.Insert(2, '1');
            //li.Insert(3, '0');
            //int index = 0;
            //int len = li.Count;
            //foreach (var item in li)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(len);
            //for (int i = 0; i < len; i++)
            //{
            //    if(li[i] != '0')
            //    {
            //        index = i;
            //        break;
            //    }
            //}

            //Console.WriteLine(index);
            //var sb = new StringBuilder();
            //for(int i = index; i < len; i++)
            //{
            //    sb.Append(li[i]);
            //}
            //Console.WriteLine(sb.ToString());

            ////string num = "112";
            ////int k = 1;
            //RemoveDigits rd = new RemoveDigits();
            ////string res = rd.RemoveKdigits(num, k);
            ////Console.WriteLine(res);

            //int n = 1234;
            //int res = rd.MonotoneIncreasingDigits(n);
            //Console.WriteLine(res);

            ////int n = 1234;
            ////char[] strN = n.ToString().ToCharArray();
            ////string s = new string(strN.ToString());
            ////Console.WriteLine(s);

            ////Console.WriteLine(int.Parse(strN.ToString()));

            //int[] nums = new int[] { 3,1 };
            //int target = 1;
            //var sr = new SearchInRotatedSortedArray();
            //var res = sr.SearchII(nums, target);
            //Console.WriteLine(res);

            //int num = 38;
            //HappyNumber hn = new HappyNumber();
            //int res = hn.AddDigits(num);
            //int gs = hn.GetSum(num);
            //Console.WriteLine(res);


            //int n = 1;
            //NarcissisticNumber nn = new NarcissisticNumber();
            //var res = nn.GetNarcissisticNumber(n);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            //string source = "";
            //string target = "";
            //ImplementStrStr imstr = new ImplementStrStr();
            //int res = imstr.strStr(source, target);
            //Console.WriteLine(res);


            ////string s = "Hahaha. HahaHa. hahaha. haHaha H haha.";
            //string s = "This won iz correkt. It has, No Mistakes et Oll. But there are two BIG mistakes in this sentence. and here is one more.";
            //LegalIdentifier ld = new LegalIdentifier();
            //int res = ld.Count(s);
            //Console.WriteLine(res);

            //var A = new int[] { -1, 0, 1, 2 };
            //var target = 2;
            //SearchInsertPosition sip = new SearchInsertPosition();
            //int res = sip.SearchIntert(A, target);
            //Console.WriteLine(res);

            //var nums = new int[] { 101, 527, 373, 526, 199, 938, 915, 766, 429, 951 };
            //MedianIndex mi = new MedianIndex();
            //Console.WriteLine(mi.GetAns(nums));

            //var nums = new int[] { 1, 2, 2, 4, 3, 5, 7, 6, 6, 8 };
            //int k = 0;
            //PartitionArray pa = new PartitionArray();
            //Console.WriteLine(pa.PartitionArrayI(nums, k));


            //var nums = new int[] { 3, 2, 1, 4, 5 };
            //SortIntegersII si = new SortIntegersII();
            //si.SortIntegersIISollution(nums);
            //foreach (var item in nums)
            //{
            //    Console.WriteLine(item);
            //}

            //var nums = new int[] { 1, 3, 5, 6, 8, 9 };
            //int target = 7;
            //SearchForARange sr = new SearchForARange();
            //var res = sr.SearchRange(nums, target);
            //var start = sr.SearchRight(nums, target - 1);
            //var end = sr.SearchRight(nums, target);
            ////Console.WriteLine(res[0]);
            ////Console.WriteLine(res[1]);
            //Console.WriteLine(start);
            //Console.WriteLine(end);
            //Console.WriteLine();

            //var nums = new int[] { 1, 2, 1, 3, 4, 5, 7, 6 };
            //FindPeakElement fp = new FindPeakElement();
            //Console.WriteLine(fp.FindPeak(nums));

            //string str = "19201234567891011121314151618";
            //int n = 20;
            //FindTheMissingNumberII fm = new FindTheMissingNumberII();
            //Console.WriteLine(fm.FindMissing2(n, str));

            //string s = ")()())";
            //var lvp = new LongestValidParentheses();
            //Console.WriteLine(lvp.LongestValidParentheses_DP(s));

            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var bi = new BeaconfireInterview();
            int maxProfit = bi.MaxProfit(prices);

            Console.WriteLine(maxProfit);


        }        
    }
}
