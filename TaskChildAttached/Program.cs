using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskChildAttached
{
    class Program
    {
        public static void DoChild(object state)
        {
            Console.WriteLine("DoWork for task {0} Starting", state);
            Thread.Sleep(1000);
            Console.WriteLine("DoWork for task {0} Finished", state);

        }

        static void Main(string[] args)
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent starts");

                for (int i = 0; i < 10; i++)
                {
                    int taskno = i; // we need to set i to num so not everything ends up with num 10
                    // ?? why x
                    Task.Factory.StartNew((task) => DoChild(task), taskno, TaskCreationOptions.AttachedToParent);
                }
            });

            //wait for all child tasks to complete before continue
            parent.Wait();

            Console.WriteLine("Parent finished, hit any button to exit");
            Console.ReadKey();
        }
    }
}
