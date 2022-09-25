using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _07ThreadLazyInstall
{
    class ClthClass
    {

        private List<int> ilst;

        public List<int> IList {
            get {
                ilst = new List<int>();

                for (int i = 0; i < 100; i++)
                {
                    ilst.Add(i);
                    Thread.Sleep(100);
                }
                return ilst;
            } 
        }

        public ClthClass()
        {
            Console.WriteLine("install");
        }
        

        

        

    }
}
