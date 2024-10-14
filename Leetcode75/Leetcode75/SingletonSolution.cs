using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75
{
    // 单例模式：确保一个类只有一个示例，并提供一个访问它的全局访问点
    internal class SingletonSolution
    {
        private static SingletonSolution uniqueInstance;
        private static readonly object locker = new object();
        private SingletonSolution()
        {

        }
        //public static SingletonSolution GetInstance()
        //{
        //    if (uniqueInstance == null)
        //    {
        //        uniqueInstance = new SingletonSolution();
        //    }
        //    return uniqueInstance;
        //}
        //public static readonly SingletonSolution Instance = new SingletonSolution();
        
        public static SingletonSolution GetInstance()
        {
            if( uniqueInstance == null )
            {
                lock(locker)
                {
                    if(uniqueInstance == null)
                    {
                        uniqueInstance = new SingletonSolution();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
