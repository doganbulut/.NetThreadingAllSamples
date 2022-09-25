using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04ThreadParams
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread mythread = new Thread(()=>Count(25));
            //mythread.Start();

            Thread mythread = new Thread(new ParameterizedThreadStart(Count));
            mythread.Start(50);

            Console.ReadLine();
        }

        static void Count(object cnt)
        {
            for (int i = 0; i < (int)cnt; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }


        static void Count(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
