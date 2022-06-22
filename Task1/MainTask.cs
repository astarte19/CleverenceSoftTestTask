using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class MainTask
    {
        public static void Start()
        {
            TaskAddToCount(5, 1000);
            TaskAddToCount(12, 2000);
            TaskGetCount(1000);
            TaskGetCount(1000);
        }
        
        private static void TaskGetCount(int timeout)
        {
            var task = new Task(() =>
            {
                while (true)
                {
                    Console.WriteLine($"Читатель | Счетчик: {Server.GetCount()}");
                    Thread.Sleep(timeout);
                }
            });
            task.Start();
        }
        
        private static void TaskAddToCount(int value, int timeout)
        {
            var task = new Task(() =>
            {
                while (true)
                {
                    if (Server.Waiting)
                    {
                        Console.WriteLine("Писатель | Ожидание...");
                    }
                    
                    Server.AddToCount(value);
                    Console.WriteLine($"Писатель | Счетчик: {Server.GetCount()}");
                   // Thread.Sleep(1000);
                    Thread.Sleep(timeout);
                }
            });
            task.Start();
        }
    }
}