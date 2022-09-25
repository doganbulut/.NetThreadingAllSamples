using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _19TaskParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(Worker,"merhaba thread task");

            Console.ReadLine();
        }

        static void Worker(object obj)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine((string)obj + " : " + DateTime.Now.ToString());
                Thread.Sleep(100);
            }
        }
    }
}
