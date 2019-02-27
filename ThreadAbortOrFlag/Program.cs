using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAbortOrFlag
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread tickThread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });

            tickThread.Start();

            Console.WriteLine("Press any key to stop the tick clock");
            Console.ReadKey();
            //a thread can be aborted, though instantly
            tickThread.Abort();

            bool tackRunning = true;
            Thread tackThread = new Thread(() =>
            {
                while (tackRunning)
                {
                    Console.WriteLine("Tack");
                    Thread.Sleep(1000);
                }
            });

            tackThread.Start();

            Console.WriteLine("Press any key to stop the tack clock");
            Console.ReadKey();
            //better use a flag
            tackRunning = false;

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
