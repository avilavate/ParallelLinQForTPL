using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_For
{
    class Parallel_Aggregation
    {
        public List<int> Sequence { get; set; }
        public Parallel_Aggregation()
        {
            this.Sequence = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                var item = new Random(i).Next(5);
                this.Sequence.Add(item);
            }
        }
        public int Sum()
        {
            int result=0;
            Parallel.ForEach(
                this.Sequence,
                () => 0,
                (x, loopState, partialResult) => { return x + partialResult; },
                (partialResult) =>
                {
                    result += partialResult;
                });
            return result;
        }
    }
}
