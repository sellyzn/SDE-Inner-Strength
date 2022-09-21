using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FLAMG
{
    internal class Threadexample
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }

        public static void Main()
        {
            // foreground thread



            // background thread

            Thread backgroundThread = new Thread(new ThreadStart(ThreadProc));
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }
        
    }
    
}
