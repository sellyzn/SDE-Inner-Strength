using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Design
{
    internal class No706_DesignHashMap
    {
    }
    //public class MyHashMap
    //{  
    //    /// <summary>
    //    /// 用int类型的数组实现哈希表功能
    //    /// T: O(1)
    //    /// S: O(1)
    //    /// </summary>
    //    private int INF = int.MaxValue;
    //    private int N = 1000009;
    //    private int[] map;
    //    public MyHashMap()
    //    {
    //        map = new int[N];
    //       Array.Fill(map, INF);
    //    }

    //    public void Put(int key, int value)
    //    {
    //        map[key] = value;
    //    }

    //    public int Get(int key)
    //    {
    //        return map[key] == INF ? -1 : map[key];
    //    }

    //    public void Remove(int key)
    //    {
    //        map[key] = INF;
    //    }
    //}

    public class Pair<U, V>
    {
        public U first;
        public V second;
        public Pair(U first, V second)
        {
            this.first = first;
            this.second = second;
        }
    }

    public class Bucket
    {
        public List<Pair<int, int>> bucket;
        public Bucket()
        {
            this.bucket = new List<Pair<int, int>>();
        }
        public int Get(int key)
        {
            foreach(var pair in this.bucket)
            {
                if(pair.first.Equals(key))
                    return pair.second;
            }
            return -1;
        }
        public void Update(int key, int value)
        {
            var found = false;
            foreach (var pair in this.bucket)
            {
                if (pair.first.Equals(key))
                {
                    pair.second = value;
                    found = true;
                }
            }
            if (!found)
            {
                this.bucket.Add(new Pair<int, int>(key, value));
            }
        }
        public void Remove(int key)
        {
            foreach (var pair in this.bucket)
            {
                if (pair.first.Equals(key))
                {
                    this.bucket.Remove(pair);
                    break;
                }
            }
        }
    }

    public class MyHashMap
    {
        private int key_space;
        private List<Bucket> hash_table;

        // Initialize your data structure
        public MyHashMap()
        {
            this.key_space = 2069;
            this.hash_table = new List<Bucket>();
            for (int i = 0; i < this.key_space; i++)
            {
                this.hash_table.Add(new Bucket());
            }
        }

        // value will always be non-negtive
        public void Put(int key, int value)
        {
            int hash_key = key % this.key_space;
            this.hash_table[hash_key].Update(key, value);
        }

        public int Get(int key)
        {
            int hash_key = key % this.key_space;
            return this.hash_table[hash_key].Get(key);
        }
        public void Remove(int key)
        {
            int hash_key = key % this.key_space;
            this.hash_table[hash_key].Remove(key);
        }
    }
}
