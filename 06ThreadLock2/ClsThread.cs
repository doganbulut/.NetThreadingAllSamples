using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06ThreadLock2
{
    class ClsThread
    {
        private int x;
        readonly object sync;
        Thread th1;
        Thread th2;

        public ClsThread(int ClassID)
        {
            x = 0;
            sync = new object();
            th1 = new Thread(() => Count(ClassID, 1));
            th2 = new Thread(() => Count(ClassID, 2));
            th1.Start();
            th2.Start();
        }

        void Count(int ClassID, int ThID)
        {
            for (int i = 0; i < 100; i++)
            {
                lock (sync)
                {
                    x++;
                    Console.WriteLine("("+ClassID+"):"+ThID + ":" + x);
                }
                Thread.Sleep(100);
            }
        }

    }
}
