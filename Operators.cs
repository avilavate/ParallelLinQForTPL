using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_For
{
    public class Operators
    {
        public static void Execute()
        {
            var left = 0;
            var Right = 0;
            var t_left = Task.Factory.StartNew(() =>
            {
                left = (10 * 10) + 2;
            });
            var t_right = Task.Factory.StartNew(() =>
            {
                Right = (10 * 10) + 2;
            });

            Task.WaitAll(new Task[] { t_left, t_right });

            Console.WriteLine($"Result: { left + Right}");
        }
    }
}
