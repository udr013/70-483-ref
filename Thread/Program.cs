using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        public static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(1000);
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(ThreadHello);
            thread.Start();


            // also possible to start a thread with a lambda expression
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Hello from the thread2");
                Thread.Sleep(1000);
            });

            thread2.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
