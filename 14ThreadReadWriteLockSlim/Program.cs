using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _14ThreadReadWriteLockSlim
{
    class Program
    {
        static ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();
        static List<int> items = new List<int>();
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Thread rth1 = new Thread(ReadWorker);
            rth1.Name = "RTH1";
            rth1.Start();

            Thread rth2 = new Thread(ReadWorker);
            rth2.Name = "RTH2";
            rth2.Start();

            Thread rth3 = new Thread(ReadWorker);
            rth3.Name = "RTH3";
            rth3.Start();

            Thread wth1 = new Thread(WriteWorker);
            wth1.Name = "WTH1";
            wth1.Start();

            Thread wth2 = new Thread(WriteWorker);
            wth2.Name = "WTH2";
            wth2.Start();

            Console.ReadLine();

        }

        private  static void ReadWorker()
        {
            string name = Thread.CurrentThread.Name;

            while (true)
            {
                rwls.EnterReadLock();
                foreach (var it in items)
                {
                    Console.WriteLine(name + " Read: " + it);
                    Thread.Sleep(1000);
                }
                rwls.ExitReadLock();
            }
        }

        private static void WriteWorker()
        {
            string name = Thread.CurrentThread.Name;

            while (true)
            {
                int say = GetRandom(100);
                rwls.EnterWriteLock();
                items.Add(say);
                rwls.ExitWriteLock();
                Console.WriteLine(name + " thr write " + say);
                Thread.Sleep(5000);
            }
        }

        private static int GetRandom(int Max)
        {
            lock (rnd)
            {
                return rnd.Next(Max);
            }   
        }

    }
}
