using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03ThreadLamda
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mythread = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            }
            );
            mythread.IsBackground = true;
            mythread.Start();
            Console.ReadLine();
        }
    }
}
