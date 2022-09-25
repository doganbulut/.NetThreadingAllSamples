using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06ThreadLock2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClsThread clsth = new ClsThread(1);
            ClsThread clsth2 = new ClsThread(2);
            Console.ReadLine();
        }
    }
}
