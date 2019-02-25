using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("DoWork Starting");
            Thread.Sleep(2000);
            Console.WriteLine("DoWork finished");

        }

        public static int CalculateResult()
        {
            Console.WriteLine("CalculateResult Starting");
            Thread.Sleep(2000);
            Console.WriteLine("CalculateResult finished");
            return 99;

        }
        static void Main(string[] args) { 
        
            // create a new task and start it
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            newTask.Wait();

            //or use Run to create and start in one method
            Task newTask2 = Task.Run(() => DoWork());
            newTask2.Wait();

            // Task returning a value
            Task<int> task = Task.Run(() => CalculateResult());
            Console.WriteLine(task.Result);

            Console.WriteLine("Hit any button to exit");
            Console.ReadKey();
        }
    }
}
