using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace WFDebugging.Development.Exceptions
{
    public class ExceptionCounter
    {
        private static object _SyncObject = new object();
        private static PerformanceCounter _PerfomanceCounter = null;

        public static long Calculate(string instanceName)
        {
            lock (_SyncObject)
            {
                if (_PerfomanceCounter == null)
                {
                    _PerfomanceCounter = new PerformanceCounter();
                    _PerfomanceCounter.CategoryName = ".NET CLR Exceptions";
                    _PerfomanceCounter.CounterName = "# of Exceps Thrown";
                    _PerfomanceCounter.InstanceName = instanceName;
                    _PerfomanceCounter.BeginInit();
                }
            }

            return _PerfomanceCounter.RawValue;
        }
    }
}