using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09ThreadAutoResetEvent2
{
    class Program
    {
        static EventWaitHandle wth1;
        static EventWaitHandle wth2;

        static void Main(string[] args)
        {
            wth1 = new AutoResetEvent(false);
            wth2 = new AutoResetEvent(false);

            Thread myth1 = new Thread(Worker1);
            myth1.IsBackground = true;
            myth1.Start();

            Thread myth2 = new Thread(Worker2);
            myth2.IsBackground = true;
            myth2.Start();


            Console.ReadLine();
        }

        private static void Worker1()
        {
            //İnitilize
            //
            //
            Console.WriteLine("Th1 Initilizng");
            Thread.Sleep(5000);
            Console.WriteLine("Th1 Init Finish");
            //İnit OK

            Console.WriteLine("Th2 Set");
            wth2.Set(); // Th2 start

            Console.WriteLine("Th1 Wait");
            wth1.WaitOne();//Th1 Bekle
            

            for (int i = 0; i < 100; i++)
            {
                int j = i;
                Console.WriteLine(i + ":Th1" + " : "+(++j)+" : "+(j++));
                Thread.Sleep(100);
            }
        }

        private static void Worker2()
        {
            //Kendini Durdur
            Console.WriteLine("Th2 Wait");
            wth2.WaitOne();

            for (int i = 0; i < 100; i++)
            {
                int j = i;
                Console.WriteLine(i + ":Th2" + " : " + (++j) + " : " + (j++));
                Thread.Sleep(100);
            }

            Console.WriteLine("Th1 Set");
            wth1.Set();
        }

       
    }
}
