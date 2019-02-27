using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLocal
{
    class Program
    {
        public static ThreadLocal<Random> RandomGenerator = new ThreadLocal<Random>(() =>
         {
             //seems not that random....
             return new Random(3);
         });


        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t1: {0}", RandomGenerator.Value.Next(20));
                    Thread.Sleep(500);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t2: {0}", RandomGenerator.Value.Next(20));
                    Thread.Sleep(500);
                }
            });

            t1.Start();
            t2.Start();

            Console.ReadKey();
        }
    }
}
