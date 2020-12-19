using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFDebugging.Development.Availability
{
    public static class DelaysCounter
    {
        private static readonly Thread _Thread;
        private static long _Threshold;

        static DelaysCounter()
        {
            _Threshold = 50;
            _Thread = new Thread(ThreadDelaysCounter) { Name = "Thread Delays Counter" };
            _Thread.IsBackground = true;
            _Thread.Start();
        }

        private static void ThreadDelaysCounter()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                long Time = stopwatch.ElapsedMilliseconds;
                Thread.Sleep(1);
                Time = stopwatch.ElapsedMilliseconds - Time;

                if (Time >= 500)
                    Delays500ms++;
                else if (Time >= 100)
                    Delays100ms++;
                else if (Time >= 50)
                    Delays50ms++;

                if (Time > MaxDelay)
                    MaxDelay = Time;

                if (Time >= _Threshold)
                    TotalDelays += Time;
            }
        }

        public static void Reset(long threshold)
        {
            _Threshold = threshold;

            Delays500ms = 0;
            Delays100ms = 0;
            Delays50ms = 0;
            MaxDelay = 0;
            TotalDelays = 0;
        }

        public static long MaxDelay { get; private set; }
        public static long TotalDelays { get; private set; }
        public static long Delays500ms { get; private set; }
        public static long Delays100ms { get; private set; }
        public static long Delays50ms { get; private set; }
    }
}