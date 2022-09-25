using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22TaskChild
{
    class Program
    {
        static void Main(string[] args)
        {
            Task MainTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Main Task  Start");

                Task NoChildTask = Task.Factory.StartNew(() => { Console.WriteLine("No child task"); });

                Task ChildTask = Task.Factory.StartNew(() => { Console.WriteLine("Yes child task"); }, TaskCreationOptions.AttachedToParent);
            }
            );

            Console.ReadLine();
        }
    }
}
