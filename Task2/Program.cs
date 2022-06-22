using System;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainTask task = new MainTask();
            task.evtObj += delegate { Thread.Sleep(3000); };
            task.Start();
            Console.ReadKey();
        }
    }
}