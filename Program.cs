using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            // var tp = new Task_Pipeline();
            //var tasks=tp.Exexute();

            //while (tasks.Count() > 0)
            //{
            //    var index = Task.WaitAny(tasks.ToArray());
            //    var task = tasks[index];
            //    tasks.RemoveAt(index);
            //    try
            //    {

            //        Console.WriteLine($"task #{task.Id} : Status: {task.Status} : {task.Result}");

            //    }
            //    catch (AggregateException AE)
            //    {
            //        Console.WriteLine($"{task.Id} : {task.Status} : {AE.Flatten().InnerException.Message}");
            //    }
            //    catch(Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }


            //}
            //   Task.Factory.StartNew(null, TaskCreationOptions.PreferFairness);
            //  ThreadPool.QueueUserWorkItem(new WaitCallback((a) => { }));

            Parallel_Aggregation pa = new Parallel_Aggregation();
            var t = Task.Factory.StartNew(() =>
            {
                pa.Sequence.ForEach((seqItem) => { Console.WriteLine($"{seqItem}"); });
            });
            t.Wait();
            Console.WriteLine("----------Sum---------Average-----------");
            var result = pa.Sum();
            Console.WriteLine($"{result.Item1,10}  :  {result.Item2,10}");

            var result1 = pa.PlinqSum();
            Console.WriteLine($"{result1.Sum} : {result1.Avg}");

            Console.Read();

        }


    }
}
