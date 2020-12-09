using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace WFDebugging.Development.Exceptions
{
	public class ExceptionCounter
	{
        private static object m_SyncObject = new object();
		private static PerformanceCounter m_PerfomanceCounter = null;

		public static long Calculate(string instanceName)
		{
            lock (m_SyncObject)
            {
                if (m_PerfomanceCounter == null)
                {
                    m_PerfomanceCounter = new PerformanceCounter();
                    m_PerfomanceCounter.CategoryName = ".NET CLR Exceptions";
                    m_PerfomanceCounter.CounterName = "# of Exceps Thrown";
                    m_PerfomanceCounter.InstanceName = instanceName;
                    m_PerfomanceCounter.BeginInit();
                }
            }

            return m_PerfomanceCounter.RawValue;
        }
	}
}
