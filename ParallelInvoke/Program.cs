using System;
using System.Threading;
using System.Threading.Tasks;

namespace listing_1.Parallel_Invoke

{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ended");

        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ended");

        }

        static void Main(String[] args)
        {
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("Finished processing. press any key to end");
            Console.ReadKey();
        }
    }
}