using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWaitAll
{
    class Program
    {
        public static void DoWork(int num)
        {
            Console.WriteLine("DoWork for task {0} Starting", num);
            Thread.Sleep(1000);
            Console.WriteLine("DoWork for task {0} Finished", num);

        }

        static void Main(string[] args)
        {
            Task[] Tasks = new Task[10];

            //remember this runs in parallel vs the java version
            for(int i = 0; i < 10; i++)
            {
                int num = i; // we need to set i to num so not everything ends up with num 10
                Tasks[i] = Task.Run(() => DoWork(num));
            }

            //wait for all to complete before continue
            Task.WaitAll(Tasks);
            //wait for any to complete before continue
            // Task.WaitAny(Tasks);

            Console.WriteLine("Hit any button to exit");
            Console.ReadKey();
        }
    }
}
