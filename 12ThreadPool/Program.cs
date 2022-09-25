using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12ThreadPool
{
    class Program
    {
        private static ManualResetEvent[] mre = new ManualResetEvent[64];

        static void Main(string[] args)
        {
        
            ThreadPool.SetMinThreads(64, 64);
            for (int i = 0; i < 64; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Worker), i);
                mre[i] = new ManualResetEvent(false);
            }


            Console.ReadLine();

            foreach (var mr in mre)
                mr.Set();
            
            Console.ReadLine();
        }

        static void Worker(object obj)
        {
            Console.WriteLine(obj.ToString()+" Thread Bekliyor...");
            mre[(int)obj].WaitOne();
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i+" : "+obj.ToString());
                Thread.Sleep(100);
            }
        }

        static void Worker2(object obj)
        {
            for (int i = 100; i > 0; i--)
            {
                Console.WriteLine(i + " w2 : " + obj.ToString());
                Thread.Sleep(100);
            }
        }
    }
}
