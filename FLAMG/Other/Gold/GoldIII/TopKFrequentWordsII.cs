//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace FLAMG.Other.Gold.GoldIII
//{
//    public class TopKFrequentWordsII
//    {
//        SortedSet<string> set;
//        Dictionary<string, int> map;
//        Comparator<string> cmp;
//        int k;
//        public TopKFrequentWordsII(int k)
//        {
//            this.k = k;
//            map = new Dictionary<string, int>();
//            //cmp = new Comparator<String>()
//            //{
//            //    public int compare(String a, String b)
//            //    {
//            //        int countA = map.getOrDefault(a, 0);
//            //        int countB = map.getOrDefault(b, 0);
//            //        if (countA == countB)
//            //            return a.compareTo(b);
//            //        return countB - countA;
//            //    }
//            //};
//            set = new SortedSet<string>(cmp);
//        }

//    public void add(String w)
//    {
//        set.Remove(w);
//            if (map.ContainsKey(w))
//                map[w]++;
//            else
//                map.Add(w, 1);
        
//        set.Add(w);
//        if (set.Count > k)
//            set.RemoveAt(set.Count - 1);
//    }

//    public IList<string> topk()
//    {
//        IList<string> ans = new List<string>(set);
//        return ans;
//    }
//}
//}
