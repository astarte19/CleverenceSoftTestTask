using System;
using System.Threading;

namespace Task2
{
    public class MainTask
    {
        public event EventHandler evtObj;
        AsyncCaller ac { get; set; }
        public void Start()
        {
            EventHandler h = new EventHandler(this.evtObj);
            ac = new AsyncCaller(h);
            bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);
            
        }
    }
}