using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16ParalelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int>(100);

            Parallel.For(0, 100, (i) => 
            {
                lst.Add(i);
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
            );

            Console.WriteLine("Eklendi!");
            Console.ReadLine();

            Parallel.For(0, 100, (i) => 
                {
                    lst[i] = lst[i] * lst[i];
                }
                );

            Console.WriteLine("Karesi hesaplandı Eklendi!");
            Console.ReadLine();

        }
    }
}
