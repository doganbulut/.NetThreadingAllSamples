using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13ThreadBarrier
{
    class Program
    {
        static Barrier barrier = new Barrier(5, b => BarrierWorker());

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread th1 = new Thread(Worker);
                th1.IsBackground = true;
                th1.Name = "Th" + i;
                th1.Start();
            }
            

            Console.ReadLine();
        }

        static void BarrierWorker()
        {
            Console.WriteLine(" Barrier Worker ");
        }

        static void Worker()
        {
            string name = Thread.CurrentThread.Name;

            for (int i = 0; i < 100; i++)
            {
                Console.Write(name + " : " + i);
                barrier.SignalAndWait();
            }
        }
    }
}
