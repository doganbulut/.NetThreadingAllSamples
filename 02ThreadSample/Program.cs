using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread mythread = new Thread(new ThreadStart(Count));
            //mythread.IsBackground = true;// Bu satır açılırsa ana iş parçaçığı sonlandığında iş parçacığı sonlanır
            //mythread.Start();

            Task
            .Factory
            .StartNew(() => Console.WriteLine(Thread.CurrentThread.IsBackground))
            .Wait();

            Console.ReadLine();
        }

        private static void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
