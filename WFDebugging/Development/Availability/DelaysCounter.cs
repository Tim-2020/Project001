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
		static DelaysCounter()
		{
			m_Threshold = 50;
			m_Thread = new Thread(ThreadDelaysCounter) { Name = "Thread Delays Counter" };
			m_Thread.IsBackground = true;
			m_Thread.Start();
		}

		private static readonly Thread m_Thread;
		private static long m_Threshold;

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

				if (Time >= m_Threshold)
					TotalDelays += Time;
			}
		}

		public static void Reset(long threshold)
		{
			m_Threshold = threshold;

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
