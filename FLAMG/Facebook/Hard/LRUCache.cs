using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Hard
{
    public class CacheEntry
    {
        public int CacheKey { get; set; }
        public int CacheValue { get; set; }
        public CacheEntry(int key, int value)
        {
            this.CacheKey = key;
            this.CacheValue = value;
        }        
    }
    public class LRUCache
    {
        private int capacity;
        private Dictionary<int, LinkedListNode<CacheEntry>> dict;
        private LinkedList<CacheEntry> cacheList;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            dict = new Dictionary<int, LinkedListNode<CacheEntry>>(2);
            cacheList = new LinkedList<CacheEntry>();
        }
        public int Get(int key)
        {
            if (!dict.ContainsKey(key))
                return -1;
            
            var node = dict[key];
            cacheList.Remove(node);
            cacheList.AddFirst(node);
            return dict[key].Value.CacheValue;
        }
        public void Put(int key, int value)
        {
            
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                node.Value.CacheValue = value;
                cacheList.Remove(node);
                cacheList.AddFirst(node);
            }
            else
            {
                if(dict.Count >= capacity)
                {
                    dict.Remove(cacheList.Last.Value.CacheKey);
                    cacheList.RemoveLast();
                }
                var cacheEntry = new CacheEntry(key, value);
                var node = new LinkedListNode<CacheEntry>(cacheEntry);
                
                dict.Add(key, node);                
                cacheList.AddFirst(node);
            }
        }
    }
}
