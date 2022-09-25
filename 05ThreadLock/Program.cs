using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05ThreadLock
{
    class Program
    {
        static int x = 0;
        static readonly object sylck = new object();

        static void Main(string[] args)
        {
            Thread mythread = new Thread(() => Count(0));
            mythread.IsBackground = true;
            mythread.Start();

            Thread mythread2= new Thread(() => Count(1));
            mythread2.IsBackground = true;
            mythread2.Start();
            Console.ReadLine();
        }

        static void Count(int ThreadID)
        {
            //static object sylck = new object(); burası olmaz değerler tekrarlanır
            for (int i = 0; i < 100; i++)
            {
                lock (sylck)
                {
                    ++x;
                    Console.WriteLine(ThreadID.ToString() + ":" + x.ToString());
                }
                Thread.Sleep(100);
            }
        }
    }
}
