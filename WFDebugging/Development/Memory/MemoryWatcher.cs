using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFDebugging.Development.Memory
{
    public class MemoryWatcher
    {
        private static readonly Thread _Thread;
        private static long[] _MemoryValues;
        private static int _Index = 0;

        static MemoryWatcher()
        {
            _Index = 0;
            _MemoryValues = new long[360];
            _Thread = new Thread(ThreadWatcher) { Name = "Thread Memory Watcher" };
            _Thread.IsBackground = true;
            _Thread.Start();
        }

        private static void ThreadWatcher()
        {
            while (_Thread != null)
            {
                lock (_MemoryValues)
                {
                    _MemoryValues[_Index] = GC.GetTotalMemory(false);
                    Calculate(_Index);
                }

                _Index = (_Index + 1) % _MemoryValues.Length;

                Thread.Sleep(10000);
            }
        }

        private static void Calculate(int index)
        {
            int Count = 0;
            long Last = 0;
            long Memory = 0;

            for (int i = 0, l = _MemoryValues.Length; i < l; i++)
            {
                long Current = _MemoryValues[(l - i + index) % l];
                long Delta = Current - Last;

                if (Current == 0)
                    break;

                if (Delta > 0 && Last > 0)
                {
                    if (Delta > Memory)
                        Memory = Delta;
                    Count++;
                }

                Last = Current;
            }

            CurrentGCCount = Count;
            CurrentMemoryCleaning = Memory;

            if (Count > WorstGCCount)
                WorstGCCount = Count;
            if (Memory > MaximumMemoryCleaning)
                MaximumMemoryCleaning = Memory;
        }

        public static void Reset()
        {
            lock (_MemoryValues)
            {
                CurrentGCCount = 0;
                WorstGCCount = 0;
                Array.ForEach(_MemoryValues, item => item = 0);
            }
        }

        public static long CurrentGCCount { get; private set; }
        public static long WorstGCCount { get; private set; }
        public static long CurrentMemoryCleaning { get; private set; }
        public static long MaximumMemoryCleaning { get; private set; }
    }
}
