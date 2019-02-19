using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor
{
    public class Program
    {


        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);

        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopstate) =>
            {
                if (i == 200)
                {
                    //Stop will just stop when 200 is done, break will guaranty all below 200 are garanteed to be completed.
                    loopstate.Break();
                    //loopstate.Stop();
                }
                WorkOnItem(items[i]);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            Console.WriteLine("Finished processing, Press any key to end.");
            Console.ReadKey();
        }
    }
}
