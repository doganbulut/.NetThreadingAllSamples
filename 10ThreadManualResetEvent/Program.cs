using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10ThreadManualResetEvent
{
    class Program
    {

        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Thredler Oluşturluyor");

            for (int i = 0; i <= 1000; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Console.WriteLine("Waiting");
            Thread.Sleep(10000);
            Console.WriteLine("Waiting End Start için Enter");
            Console.ReadLine();
            mre.Set();//Start All Thread
          
            Console.ReadLine();
        }

        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " mre.WaitOne()");

            mre.WaitOne();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(name + ":" + i);
                Thread.Sleep(5);
            }
        }
    }
}
