using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_For
{
    public class Task_Pipeline
    {
        public List<Task<decimal>> Exexute()
        {
            List<Task<decimal>> Tasks = new List<Task<decimal>>();
            for (int i = 0; i < 10; i++)
            {
                Tasks.Add(Task.Factory.StartNew(this.Code));
            }
            return Tasks;
        }
        public decimal Code()
        {
            decimal d = new Random().Next() * 2;
            var rand = new Random();
            if (rand.NextDouble() >= 0.5)
            {
                throw new Exception("Found even");
            }
            return Math.Ceiling(d);
        }
    }
}
