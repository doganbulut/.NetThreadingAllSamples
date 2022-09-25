using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _17ParalelForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lst = new List<string>(100);

            for (int i = 0; i < 100; i++)
            {
                lst.Add(DateTime.Now.ToString());
                Thread.Sleep(100);
            }

            Parallel.ForEach(lst, (str) =>
            {
                Console.WriteLine(str);
            });

            Console.ReadLine();
        }
    }
}
