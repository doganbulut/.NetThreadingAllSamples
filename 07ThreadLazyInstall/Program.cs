using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07ThreadLazyInstall
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Lazy<ClthClass> th1 = new Lazy<ClthClass>(()=>new ClthClass(),true);
            ClthClass th2 = th1.Value;
            foreach (int id in th2.IList)
            {
                Console.WriteLine(id);
            }
            Console.ReadLine();
        }
    }
}
