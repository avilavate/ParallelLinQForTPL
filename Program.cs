using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_For
{
    class Program
    {
        static void Main(string[] args)
        {
            //AccountOps ops = new AccountOps();
            //var t = Task.Factory.StartNew(() => { ops.UpdatePredictionsParallel(); });
            //t.Wait();
            //foreach (var account in ops.Accounts)
            //{
            //    Console.WriteLine($"{account.No} : {account.Warn}");
            //}


            //Operators.Execute();
            //new Task_Cancelation().Execute();

            var tp = new Task_Pipeline();
            var tasks=tp.Exexute();

            while (tasks.Count() > 0)
            {
                var index = Task.WaitAny(tasks.ToArray());
                var task = tasks[index];
                tasks.RemoveAt(index);
                try
                {
                    
                    Console.WriteLine($"task #{task.Id} : {task.Result}");
                   
                }
                catch (AggregateException AE)
                {
                    Console.WriteLine($"{AE.Flatten().InnerException.Message}");
                }
                
             
            }


            Console.Read();
            
        }


    }
}
