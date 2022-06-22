using System;
using System.Threading;

namespace Task2
{
    public class AsyncCaller
    {
        public AsyncCaller(EventHandler evtObj)
        {
            this.evtObj = evtObj;
        }
        private EventHandler evtObj { get; set; }
        public bool Invoke(int timeout,object sender, EventArgs e)
        {
            bool completedOK = false;
            var thread = new Thread(() =>
            {
                try
                {
                    if (!(evtObj is null))
                        evtObj.Invoke(null, EventArgs.Empty);
                    completedOK = true;
                }
                catch (ThreadAbortException)
                {

                }                
            });
            thread.Start();
            Console.WriteLine($"Поток: {Thread.CurrentThread.ManagedThreadId} Состояние: {Thread.CurrentThread.ThreadState}");
            thread.Join(timeout);
            
            if (thread.IsAlive)
            {
                thread.Abort();
                completedOK = false;
            }

            return completedOK;
        }
    }
}