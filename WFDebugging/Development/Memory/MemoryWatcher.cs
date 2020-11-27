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
		static MemoryWatcher()
		{
			m_Index = 0;
			m_MemoryValues = new long[360];
			m_Thread = new Thread(ThreadWatcher) { Name = "Thread Memory Watcher" };
			m_Thread.IsBackground = true;
			m_Thread.Start();
		}

		private static readonly Thread m_Thread;
		private static long[] m_MemoryValues;
		private static int m_Index = 0;

		private static void ThreadWatcher()
		{
			while (m_Thread != null)
			{
				lock (m_MemoryValues)
				{
					m_MemoryValues[m_Index] = GC.GetTotalMemory(false);
					Calculate(m_Index);
				}

				m_Index = (m_Index + 1) % m_MemoryValues.Length;

				Thread.Sleep(10000);
			}
		}

		private static void Calculate(int Index)
		{
			int Count = 0;
			long Last = 0;
			long Memory = 0;

			for (int i = 0, l = m_MemoryValues.Length; i < l; i++)
			{
				long Current = m_MemoryValues[(l - i + Index) % l];
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
			lock (m_MemoryValues)
			{
				CurrentGCCount = 0;
				WorstGCCount = 0;
				Array.ForEach(m_MemoryValues, item => item = 0);
			}
		}

		public static long CurrentGCCount { get; private set; }
		public static long WorstGCCount { get; private set; }
		public static long CurrentMemoryCleaning { get; private set; }
		public static long MaximumMemoryCleaning { get; private set; }
	}
}
