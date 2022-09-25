using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11ThreadEventCount
{
    class Program
    {
        private static CountdownEvent cde = new CountdownEvent(10);

        static void Main(string[] args)
        {
            
            for (int i = 0; i < 10; i++)
            {
                Thread thr = new Thread(Worker);
                thr.Name = "th" + i;
                thr.Start();
            }

            Thread.Sleep(1000);
            Console.WriteLine("Start Ver");
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
                cde.Signal();

            Console.ReadLine();
        }


        static void Worker()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine(name + ": thr start bekliyor...");
            cde.Wait();

            Console.WriteLine(name + ": no thread koştu...");
        }

    }
}
