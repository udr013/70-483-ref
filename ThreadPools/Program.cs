using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPools
{
    class Program
    {

        static int highestThreadPoolnr;

        public static void DoWork(object state)
        {
            Console.WriteLine("Doing work {0}", state);
            Thread t = Thread.CurrentThread;
            Console.WriteLine("Current thread {0}", t.ManagedThreadId);
            if (t.ManagedThreadId > highestThreadPoolnr)
            {
                highestThreadPoolnr = t.ManagedThreadId;
            }

        }


        static void Main(string[] args)
        {
            Thread threadToWaitFor = new Thread(() =>
            {
                for (int x = 0; x < 500; x++)
                {
                    int threadstate = x;
                    ThreadPool.QueueUserWorkItem(state => DoWork(threadstate));
                }

                Thread.Sleep(3000);
            });
            threadToWaitFor.Start();
            threadToWaitFor.Join();

            Console.WriteLine("highestThreadPoolnr: {0}", highestThreadPoolnr);
            Console.ReadKey();
        }
    }
}
