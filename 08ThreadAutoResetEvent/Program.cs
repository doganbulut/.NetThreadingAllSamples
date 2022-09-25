using System;
using System.Threading;

namespace _08ThreadAutoResetEvent
{
    class Program
    {
        //static EventWaitHandle ewh = new EventWaitHandle(false,EventResetMode.AutoReset);
        //veya
        static EventWaitHandle ewh = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Thread myth = new Thread(WaitingThread);
            myth.IsBackground = true;
            myth.Start();
            Thread.Sleep(10000);
            ewh.Set();//Thread beklemeden çıkıyor


            Console.ReadLine();
        }

        static void WaitingThread()
        {
            Console.WriteLine("Thread Başladı....");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
                if (i == 50)
                {
                    Console.WriteLine("Thread bekletilecek");
                    ewh.WaitOne();//Thread bekletiliyor
                }
            }
            
            Console.WriteLine("Thread Bekleme Modundan Çıkıldı");
        }
    }
}
