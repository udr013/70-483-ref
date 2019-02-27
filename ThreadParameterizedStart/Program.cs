using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadParameterizedStart
{
    class Program
    {
        public static void WorkOnData(object data)
        {
            Console.WriteLine("Working on {0}", data);
            Thread.Sleep(1000);
        }

        static void Main(string[] args)
        {
            ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
            Thread thread = new Thread(ps);
            thread.Start(99);

            //same can be done using a lambda
            Thread thread2 = new Thread((data) =>
            {
                WorkOnData(data);
            });
            thread2.Start(22);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
