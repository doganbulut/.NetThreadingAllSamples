using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _25ConcurrentType
{
    class Program
    {
        static ConcurrentBag<int> listBag = new ConcurrentBag<int>();
        static ConcurrentQueue<int> listQueue = new ConcurrentQueue<int>();

        static void Main(string[] args)
        {

            //Write Test
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var op1 = Task.Factory.StartNew(WorkerQueueWrite);
            var op2 = Task.Factory.StartNew(WorkerQueueWrite);
            var op3 = Task.Factory.StartNew(WorkerQueueWrite);

            Task.WaitAll(new Task[] { op1, op2, op3 });
            
            sw.Stop();
            Console.WriteLine("Eş zamnalı queue write sure:" + sw.ElapsedMilliseconds);

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            var op4 = Task.Factory.StartNew(WorkerBagWrite);
            var op5 = Task.Factory.StartNew(WorkerBagWrite);
            var op6 = Task.Factory.StartNew(WorkerBagWrite);

            Task.WaitAll(new Task[] { op4, op5, op6 });

            sw2.Stop();

            Console.WriteLine("Eş zamanlı bag write sure:" + sw2.ElapsedMilliseconds);

            //Read Test
            Stopwatch sw3 = new Stopwatch();
            sw3.Start();

            var rop1 = Task.Factory.StartNew(WorkerQueueRead);
            var rop2 = Task.Factory.StartNew(WorkerQueueRead);
            var rop3 = Task.Factory.StartNew(WorkerQueueRead);

            Task.WaitAll(new Task[] { rop1, rop2, rop3 });

            sw3.Stop();
            Console.WriteLine("Eş zamnalı queue read sure:" + sw3.ElapsedMilliseconds);

            Stopwatch sw4 = new Stopwatch();
            sw4.Start();

            var rop4 = Task.Factory.StartNew(WorkerQueueRead);
            var rop5 = Task.Factory.StartNew(WorkerQueueRead);
            var rop6 = Task.Factory.StartNew(WorkerQueueRead);

            Task.WaitAll(new Task[] { rop4, rop5, rop6 });

            sw4.Stop();

            Console.WriteLine("Eş zamanlı bag read sure:" + sw4.ElapsedMilliseconds);
            ///

            Console.ReadLine();
        }

        static void WorkerBagWrite()
        {
            for (int i = 0; i < 1000000; i++)
            {
                listBag.Add(i);
            }
        }

        static void WorkerBagRead()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int val;
                listBag.TryTake(out val);
            }
        }

        static void WorkerQueueWrite()
        {
            for (int i = 0; i < 1000000; i++)
            {
                listQueue.Enqueue(i);
            }
        }

        static void WorkerQueueRead()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int val;
                listQueue.TryDequeue(out val);
            }
        }

    }
}
