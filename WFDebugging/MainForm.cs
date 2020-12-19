using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WFDebugging.Additional;
using WFDebugging.Development.Availability;
using WFDebugging.Development.Console;
using WFDebugging.Development.Exceptions;
using WFDebugging.Development.Memory;
using WFDebugging.Development.Trace;

namespace WFDebugging
{
    public partial class MainForm : Form, IConsoleReceiver
    {
        #region Fields

        private static string _InstanceName = null;
        private HardWork _HardWork = null;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            Icon = MainResource.recycling;
            ConsoleWritter.Initialize(this);
            DelaysCounter.Reset(50);
            MemoryWatcher.Reset();
        }

        static MainForm()
        {
            var c = new PerformanceCounterCategory(".NET CLR Exceptions");
            var inst = c.GetInstanceNames();
            Assembly asm = Assembly.GetExecutingAssembly();

            int indexcoma = asm.ToString().IndexOf(',');
            string asmName = asm.ToString().Substring(0, indexcoma);
            string s = inst.FirstOrDefault(a => a == asmName);
            if (string.IsNullOrEmpty(s) == true)
                s = "w3wp";

            _InstanceName = s;
        }

        #endregion

        #region Constants

        private const int CONSOLE_SIZE = 128;

        #endregion

        #region IConsoleRecevier

        public void Put(string value)
        {
            edConsole.Text += value;

            if (edConsole.Lines.Length >= CONSOLE_SIZE)
            {
                int firstIndex = edConsole.Lines[0].Length;
                int secondIndex = edConsole.Text.IndexOf(edConsole.Lines[1], firstIndex);
                if (firstIndex == secondIndex && secondIndex < edConsole.Text.Length) secondIndex++;
                edConsole.Text = edConsole.Text.Substring(secondIndex);
            }
            edConsole.SelectionStart = edConsole.Text.Length;
            edConsole.ScrollToCaret();
        }

        #endregion

        #region Private

        private void function0(string FirstName, string LastName)
        {
            Console.WriteLine("function 0");
            function1(FirstName, LastName);
        }

        private void function1(string FirstName, string LastName)
        {
            Console.WriteLine("function 1");
            function2(FirstName, LastName);
        }

        private void function2(string FirstName, string LastName)
        {
            Console.WriteLine("function 2");
            IEnumerable<MethodBase> methods = TraceBuilder.Build();

            bool wasFirst = false;
            Console.WriteLine();
            Console.WriteLine("Trace stack:");

            foreach (var method in methods)
            {
                if (!wasFirst)
                {
                    wasFirst = method.Name == LastName;
                }

                if (wasFirst)
                {
                    ParameterInfo[] parameters = method.GetParameters();

                    Console.WriteLine("Function: " + method.Name);
                    Console.Write("Parameters: ");

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (i > 0) Console.Write(", ");
                        Console.Write(string.Format("\t{0}: {1}", parameters[i].Name, parameters[i].ParameterType.ToString()));
                    }

                    Console.WriteLine();
                }

                if (method.Name == FirstName)
                    break;
            }
        }

        #endregion

        #region Events

        private void outOfRangeExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int[] tempArray = new int[4];

                for (int i = 0; i < 10; i++)
                    tempArray[i] = i;

                #region Never execute. Just "Release" not to optimize code

                Console.WriteLine("Number of elements: " + tempArray.Length);

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
            }
        }

        private void zeroDivisionExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 5;
                int b = 0;
                int c = a / b;

                #region Never execute. Just "Release" not to optimize code

                Console.WriteLine(string.Format("{0} {1} {2}", a, b, c));

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"Exceptions count: {ExceptionCounter.Calculate(_InstanceName)}");
        }

        private void twoFunctionsDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            function1("function1", "function2");
        }

        private void threeFunctionsDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            function0("function0", "function2");
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"Max delay: {DelaysCounter.MaxDelay:N0}ms");
            Console.WriteLine($"Total delay: {DelaysCounter.TotalDelays:N0}ms");
            Console.WriteLine($"Delays 500ms: {DelaysCounter.Delays500ms:N0}");
            Console.WriteLine($"Delays 100ms: {DelaysCounter.Delays100ms:N0}");
            Console.WriteLine($"Delays 50ms:  {DelaysCounter.Delays50ms:N0}");
        }

        private void btnGCCount_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"Number of GC Handling: {MemoryWatcher.CurrentGCCount}");
            Console.WriteLine($"Worst GC Handling: {MemoryWatcher.WorstGCCount}");
            Console.WriteLine($"Memory usage: {GC.GetTotalMemory(false)}");
            for (int i = 0, l = GC.MaxGeneration; i <= l; i++)
                Console.WriteLine($"Generation {i}: {GC.CollectionCount(i)}");
        }

        private void btnRunWork_Click(object sender, EventArgs e)
        {
            if (_HardWork == null)
            {
                _HardWork = new HardWork();
            }
            else
            {
                _HardWork.Stop();
                _HardWork = null;
            }

            btnRunWork.Checked = _HardWork != null;
        }

        private void btnWorkInfo_Click(object sender, EventArgs e)
        {
            if (_HardWork != null)
                _HardWork.Print();
        }

        #endregion
    }
}