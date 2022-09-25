using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15ParalelInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => Worker1(),
                () => Worker2(100)
                );

            Console.WriteLine("Worker1-2 Bitti:" + DateTime.Now.ToString());
            Console.ReadLine();
        }

        static void Worker1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Worker1:" + i);
                Thread.Sleep(50);
            }
            Console.WriteLine("Worker1 Bitti:" + DateTime.Now.ToString());
        }

        static void Worker2(int z)
        {
            for (int i = 0; i < z; i++)
            {
                Console.WriteLine("Worker2:" + i);
                Thread.Sleep(100);
            }
            Console.WriteLine("Worker2 Bitti:" + DateTime.Now.ToString());
        }

    }
}
