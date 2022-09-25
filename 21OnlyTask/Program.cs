using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _21OnlyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(()=>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Task1 Merhaba: " + i);
                    Thread.Sleep(100);
                }
              
            });

            Task task2 = new Task(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("Task2 Merhaba: " + i);
                    Thread.Sleep(100);
                }

            });
           
            task.Start();
            task2.Start();
            //task.Wait();//<bunu koyarsanız kod burada bekler....kadırırsanız task bitince readline çalışır.task2 kesilir.
            

            //task.RunSynchronously();//Senkron

            Console.ReadLine();
        }
    }
}
