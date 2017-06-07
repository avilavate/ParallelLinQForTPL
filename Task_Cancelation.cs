using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_For
{
    class Task_Cancelation
    {
        CancellationTokenSource ct = new CancellationTokenSource();

        public  void Execute()
        {
            var task = Task.Factory.StartNew(() => {
                Console.WriteLine("Task Started....");
                Thread.Sleep(1000);
                if (ct.Token.IsCancellationRequested)
                {
                    ct.Token.ThrowIfCancellationRequested();
                }
                Console.WriteLine("Unreacheable code!");
            }, ct.Token);


            try
            {
                Thread.Sleep(300);
                ct.Cancel();
                task.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        

    }
}
