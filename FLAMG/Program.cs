using FLAMG.Amazon.Easy;
using FLAMG.Contractor;
using FLAMG.Facebook.Easy;
using FLAMG.Google;
using FLAMG.Google.HighestFrequency;
using FLAMG.Microsoft.Easy;
using FLAMG.Microsoft.Medium;
using FLAMG.Other;
using FLAMG.Other.BFS;
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

            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            //var bi = new BeaconfireInterview();
            //int maxProfit = bi.MaxProfit(prices);

            //Console.WriteLine(maxProfit);

            //var assignment = new NintendoAssignment();
            ////var oldFiles = new List<string> { "1111", "2222" };
            ////var newFiles = new List<string> { "2222", "3333", "8888" };

            //// Read old files and new files
            //var oldFiles = System.IO.File.ReadAllLines("C:/Users/selen/OneDrive/ZNUS/JobApplication/Interviewed/Nintendo/Assignment/Old.sha1.txt");
            //var newFiles = System.IO.File.ReadAllLines("C:/Users/selen/OneDrive/ZNUS/JobApplication/Interviewed/Nintendo/Assignment/New.sha1.txt");

            //// transform the old file and new file into Dictionary<string, string> format
            //var oldFilesDictionary = assignment.fileFormat(oldFiles);
            //var newFilesDictionary = assignment.fileFormat(newFiles);

            //IList<string> oldNotInNew, newNotInOld;
            //oldNotInNew = assignment.File1NotInFile2(oldFilesDictionary, newFilesDictionary);
            //newNotInOld = assignment.File1NotInFile2(newFilesDictionary, oldFilesDictionary);

            //Console.WriteLine("old not in new: ");
            //foreach (var item in oldNotInNew)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("\n");
            //Console.WriteLine("new not in old: ");
            //foreach (var item in newNotInOld)
            //{
            //    Console.WriteLine(item);
            //}

            //System.IO.File.WriteAllLines("C:/Users/selen/OneDrive/ZNUS/JobApplication/Interviewed/Nintendo/Assignment/OldNotInNew.txt", oldNotInNew);
            //System.IO.File.WriteAllLines("C:/Users/selen/OneDrive/ZNUS/JobApplication/Interviewed/Nintendo/Assignment/NewNotInOld.txt", newNotInOld);

            //// Google Contract OA
            ////var sequence = new[] { 1, 2, 3, 4, 5 };
            //var sequence = new[] { 1, 3, 4, 5, 2 };
            ////var sub_sequence = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5 } };   //return true
            //var sub_sequence = new int[][] { new int[] { 2, 3 }, new int[] { 1, 3 }, new int[] { 4, 2 }, new int[] { 2 }, new int[] { 4, 5 } };   //return true
            ////var sub_sequence = new int[][] { new int[] { 2, 3 }, new int[] { 1, 3 }, new int[] { 4, 2 }, new int[] { 4, 5 } };    //return false
            ////var sub_sequence = new int[][] { new int[] { 2, 3 }, new int[] { 3 }, new int[] { 1, 2 }, new int[] { 4, 5 } };   //return true
            ////var sub_sequence = new int[][] { new int[] { 2, 3 }, new int[] { 3 }, new int[] { 1, 2 }, new int[] { 4, 5 } };   //return true
            ////var sub_sequence = new int[][] { new int[] { 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 } };  //return false

            //var gc = new GoogleContract();
            //var result = gc.CanConstruct(sequence, sub_sequence);
            //Console.WriteLine(result);


            ////Hack Reactor TA
            //var itemData = new List<Dictionary<string, string>>();
            //var item0 = new Dictionary<string, string>
            //{
            //    { "category", "fruit" },
            //    { "itemName", "apple" },
            //    { "onSale", "false" }
            //};

            //var item1 = new Dictionary<string, string>
            //{
            //    { "category", "canned" },
            //    { "itemName", "beans" },
            //    { "onSale", "false" }
            //};

            //var item2 = new Dictionary<string, string>
            //{
            //    { "category", "canned" },
            //    { "itemName", "corn" },
            //    { "onSale", "true" }
            //};

            //var item3 = new Dictionary<string, string>
            //{
            //    { "category", "frozen" },
            //    { "itemName", "pizza" },
            //    { "onSale", "false" }
            //};

            //var item4 = new Dictionary<string, string>
            //{
            //    { "category", "fruit" },
            //    { "itemName", "melon" },
            //    { "onSale", "true" }
            //};

            //var item5 = new Dictionary<string, string>
            //{
            //    { "category", "canned" },
            //    { "itemName", "soup" },
            //    { "onSale", "false" }
            //};

            //itemData.Add(item0);
            //itemData.Add(item1);
            //itemData.Add(item2);
            //itemData.Add(item3);
            //itemData.Add(item4);
            //itemData.Add(item5);

            //var hrcc = new HackReactorCodingChallenge();

            //var result = hrcc.OrganizeItems(itemData);

            //foreach (var item in result)
            //{
            //    var itemKey = item.Key;
            //    var itemValue = item.Value;
            //    Console.WriteLine(itemKey);
            //    foreach (var value in itemValue)
            //    {
            //        Console.WriteLine(value);
            //    }
            //    Console.WriteLine("\n");
            //}


            ////AmazonOA
            //var aoa = new AmazonOA();
            //var lot = new List<List<int>>();
            //lot.Add(new List<int> { 1, 1, 1 });
            //lot.Add(new List<int> { 0, 0, 1 });
            //lot.Add(new List<int> { 1, 9, 1 });
            //var result = aoa.ShortestPath(lot);
            //Console.WriteLine(result);

            //var cb = new ConnectedBlocks();
            ////var grid = new int[][] {new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            ////                        new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            ////                        new int[]{ 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            ////                        new int[]{ 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
            ////                        new int[]{ 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
            ////                        new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            ////                        new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            ////                        new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }
            ////                        };
            //var grid = new int[][] { new int[] { 1, 0, 1 },
            //                        new int[]{ 0, 0, 1 }
            //                        };

            //var maxArea = cb.MaxAreaOfIsland(grid);
            //Console.WriteLine(maxArea);


            //var target = 7;
            //var nums = new int[] { 2, 3, 1, 2, 4, 3 };
            //var ps = new PrefixSumProblems();
            //var result = ps.MinSubArrayLen_prefixSum(target, nums);
            //Console.WriteLine(result);

            var lipm = new LongestIncreasingPathInAMatrix();
            var matrix = new int[3][];
            matrix[0] = new int[] { 9, 9, 4 };
            matrix[1] = new int[] { 6, 6, 8 };
            matrix[2] = new int[] { 2, 1, 1 };
            var result = lipm.LongestIncreasingPath(matrix);
            Console.WriteLine(matrix[0][0]);



        }
    }
}
