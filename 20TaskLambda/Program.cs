using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20TaskLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(state =>
            {
                Worker("parametre"); Console.WriteLine("State:" + state.ToString());
            }
            , "Parameteli Method");

            Console.WriteLine("aync state:" + task.AsyncState);
            
            Console.ReadLine();
        }

        static void Worker(string str)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(str+":"+i);
                Thread.Sleep(200);
            }
        }
    }
}
