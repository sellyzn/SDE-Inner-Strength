using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Design
{
    internal class No705_DesignHashSet
    {
    }
    //public class MyHashSet
    //{
    //    //array
    //    public bool[] nodes;

    //    public MyHashSet()
    //    {
    //        nodes = new bool[1000009];
    //    }

    //    public void Add(int key)
    //    {
    //        nodes[key] = true;
    //    }

    //    public void Remove(int key)
    //    {
    //        nodes[key] = false;
    //    }

    //    public bool Contains(int key)
    //    {
    //        return nodes[key];
    //    }
    //}


    public class Bucket
    {
        private LinkedList<int> container;

        public Bucket()
        {
            container = new LinkedList<int>();
        }
        public void Insert(int key)
        {
            int index = this.container.IndexOf(key);
            if(index == -1)
                this.container.AddFirst(key);
        }
        public void Delete(int key)
        {
            this.container.Remove(key);
        }
        public bool Exist(int key)
        {
            int index = this.container.IndexOf(key);
            return index != -1;
        }
    }
    public class MyHashSet
    {

        private Bucket[] bucketArray;
        private int keyRange;

        public MyHashSet()
        {
            this.keyRange = 769;
            this.bucketArray = new Bucket[this.keyRange];
            for (int i = 0; i < this.keyRange; i++)
            {
                this.bucketArray[i] = new Bucket();
            }
        }

        protected int Hash(int key)
        {
            return key % this.keyRange;
        }

        public void Add(int key)
        {
            int bucketIndex = this.Hash(key);
            this.bucketArray[bucketIndex].Insert(key);
        }

        public void Remove(int key)
        {

        }

        public bool Contains(int key)
        {

        }

       
        
    }
}
