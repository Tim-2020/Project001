using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFDebugging.Additional
{
    public class HardWork
    {
        #region Fields

        private Thread _ThreadGenerate;
        private Thread[] _ThreadHandle;

        private Queue<string> _Queue;
        private long _Summ;
        private int _Speed;
        private int _MaxQueue;

        #endregion

        #region Constructor

        public HardWork()
        {
            _Queue = new Queue<string>(100000);

            _ThreadHandle = new Thread[1];

            for (int i = 0; i < _ThreadHandle.Length; i++)
            {
                _ThreadHandle[i] = new Thread(ThreadHandle);
                _ThreadHandle[i].IsBackground = true;
                _ThreadHandle[i].Start();
            }

            _ThreadGenerate = new Thread(ThreadGenerate);
            _ThreadGenerate.IsBackground = true;
            _ThreadGenerate.Start();

        }

        #endregion

        #region Private

        private void ThreadGenerate()
        {
            int Counter = 0;
            Random rnd = new Random();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long Time = sw.ElapsedMilliseconds;

            while (_ThreadGenerate != null)
            {
                Counter++;
                string s = DateTime.Now.ToString()
                + "\t" + rnd.Next(1100).ToString()
                + "\t" + rnd.Next().ToString();

                for (int i = 0, l = 3; i < l; i++)
                {
                    s += "\t";
                    List<byte> list = new List<byte>(1000000);
                    for (int j = 0, t = 5; j < t; j++)
                        list.Add((byte)rnd.Next(0x30, 0x3A));
                    s += Encoding.UTF8.GetString(list.ToArray());
                }

                lock (_Queue)
                {
                    if (_Queue.Count < 100000)
                        _Queue.Enqueue(s);
                }

                long Temp = sw.ElapsedMilliseconds;
                if (Temp - Time >= 1000)
                {
                    _Speed = (int)(Counter * 1000.0 / (Temp - Time));
                    Time = Temp;
                    Counter = 0;
                }
            }
        }

        private void ThreadHandle()
        {
            while (_ThreadHandle != null)
            {
                string s = null;

                if (_Queue.Count > 0)
                {
                    lock (_Queue)
                    {
                        int Count = _Queue.Count;

                        if (Count > 0)
                        {
                            if (Count > _MaxQueue)
                                _MaxQueue = Count;
                            s = _Queue.Dequeue();
                        }
                    }
                }

                if (s != null)
                {
                    string[] m = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (int.Parse(m[1]) > 100)
                        _Summ += int.Parse(m[2]);
                }
                else
                    Thread.Sleep(1);
            }
        }

        #endregion

        #region Public

        public void Stop()
        {
            _ThreadGenerate = null;
            _ThreadHandle = null;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Summ: " + _Summ);
            Console.WriteLine("Current Queue: " + _Queue.Count);
            Console.WriteLine("Max queue: " + _MaxQueue);
            Console.WriteLine("Speed: " + _Speed);
        }

        #endregion
    }
}
