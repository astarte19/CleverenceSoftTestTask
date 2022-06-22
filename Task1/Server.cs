using System;
using System.Threading;

namespace Task1
{
    public static class Server
    {
        private static object _locker = new object();
        public static int Count { get; set; }
        public static int GetCount()
        {
            evtObj.WaitOne();
            return Count;
        }
        public static void AddToCount(int value)
        {
            lock (evtObj)
            {
                evtObj.Reset();
                Count += value;
                evtObj.Set();
            }
        }
        public static bool Waiting { get { return !evtObj.WaitOne(0); } }
        private static ManualResetEvent evtObj { get; set; } = new ManualResetEvent(true);
    }
}