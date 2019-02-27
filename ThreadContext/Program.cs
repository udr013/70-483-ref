using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadContext
{
    class Program
    {

        static void DisplayThread( Thread t)
        {
            Console.WriteLine("Name: {0}", t.Name);
            Console.WriteLine("Culture {0}", t.CurrentCulture);
            Console.WriteLine("Priority {0}", t.Priority);
            Console.WriteLine("Context {0}", t.ExecutionContext);
            Console.WriteLine("IsBackground {0}", t.IsBackground);
            Console.WriteLine("IsPool {0}", t.IsThreadPoolThread);
            Console.WriteLine("ManagedThreadId {0}", t.ManagedThreadId);
            Console.WriteLine("ThreadState", t.ThreadState);
            Console.WriteLine("ApartmentState {0}", t.ApartmentState); //depricatec
            Console.WriteLine("CurrentUICulture {0}", t.CurrentUICulture);
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            DisplayThread(Thread.CurrentThread);

            Thread t2 = new Thread(()=> {
                Thread.Sleep(5000);
            });

            DisplayThread(t2);
            Console.ReadKey();


        }
    }
}
