using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _18Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => 
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("1:"+i);
                    Thread.Sleep(100);
                }
            });

            //Result
            Task<string> ret = Task.Factory.StartNew<string>(() =>
             {

                 for (int i = 0; i < 100; i++)
                 {
                     Console.WriteLine("2:" + i);
                     Thread.Sleep(100);
                 }
                 return "Bitti";
             });

            Console.WriteLine(ret.Result);

            Console.ReadLine();
        }
    }
}
