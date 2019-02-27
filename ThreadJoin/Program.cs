using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread threadToWaitFor = new Thread(() =>
            {
                Console.WriteLine("thread starting");
                Thread.Sleep(3000);
                Console.WriteLine("thread done");
            });

            threadToWaitFor.Start();
            Console.WriteLine("Joining thread");
            //main calls join on threadToWaitFor and waits till it's fininshed before continue with main
            threadToWaitFor.Join();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
