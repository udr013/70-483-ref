using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuationTasks
{
    class Program {

        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
            throw new Exception();

        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");

        }

        public static void ExceptionTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Bye, Bye");

        }
        static void Main(string[] args)
        {

            Task task = Task.Run(() => HelloTask());
            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);
            
            Console.WriteLine("Hit any button to exit");
            Console.ReadKey();
        }
    }
}
