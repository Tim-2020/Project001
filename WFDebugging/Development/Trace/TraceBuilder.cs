using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

namespace WFDebugging.Development.Trace
{
    public class TraceBuilder
    {
        public static IEnumerable<MethodBase> Build()
        {
            StackTrace stackTrace = new StackTrace(true);

            for (int j = 0; j < stackTrace.FrameCount; j++)
            {
                StackFrame frame = stackTrace.GetFrame(j);

                if (frame != null)
                {
                    MethodBase method = frame.GetMethod();
                    if (method.MethodImplementationFlags != MethodImplAttributes.IL) break;

                    yield return method;
                }
            }
        }
    }
}