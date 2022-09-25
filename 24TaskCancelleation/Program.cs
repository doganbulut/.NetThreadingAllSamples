using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _24TaskCancelleation
{
    class Program
    {
        static void Main(string[] args)
        {
            var CancelSource = new CancellationTokenSource();
            CancellationToken CancelToken = CancelSource.Token;

            Task work = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            if (i == 25)
                            {
                                CancelSource.Cancel();
                            }
                            if (CancelToken.IsCancellationRequested)
                            {
                                Console.WriteLine("Cancelletion Geldi");
                            }
                            CancelToken.ThrowIfCancellationRequested();//Check cancellation request
                            
                            Console.WriteLine(i);
                            Thread.Sleep(50);
                        }
                    }
                }
            , CancelToken);


            try
            {
                //CancelSource.Cancel();
                work.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is OperationCanceledException)
                {
                    Console.WriteLine("Görev İptal Edilmiştir!");
                } 
            }

            Console.ReadLine();

        }
    }
}
