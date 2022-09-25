using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23TaskException
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<string> taskexp = Task.Factory.StartNew(() => 
            {
                throw new Exception("Task Hatası");
                return "";
            });


            try
            {
                var res = taskexp.Result;
            }
            catch (AggregateException aex)
            {
                Console.WriteLine(aex.InnerException.Message);
            }

            Console.ReadLine();
        }
    }
}
