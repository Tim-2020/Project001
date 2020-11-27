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
		public HardWork()
		{
			m_Queue = new Queue<string>(100000);
			
			m_ThreadHandle = new Thread[1];

			for (int i = 0; i < m_ThreadHandle.Length; i++)
			{
				m_ThreadHandle[i] = new Thread(ThreadHandle);
				m_ThreadHandle[i].IsBackground = true;
				m_ThreadHandle[i].Start();
			}

			m_ThreadGenerate = new Thread(ThreadGenerate);
			m_ThreadGenerate.IsBackground = true;
			m_ThreadGenerate.Start();
			
		}

		#region Fields

		private Thread m_ThreadGenerate;
		private Thread[] m_ThreadHandle;

		private Queue<string> m_Queue;
		private long m_Summ;
		private int m_Speed;
		private int m_MaxQueue;

		#endregion

		#region Private

		private void ThreadGenerate()
		{
			int Counter = 0;
			Random rnd = new Random();
			
			Stopwatch sw = new Stopwatch();
			sw.Start();

			long Time = sw.ElapsedMilliseconds;

			while (m_ThreadGenerate != null)
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

				lock (m_Queue)
				{
					if (m_Queue.Count < 100000)
						m_Queue.Enqueue(s);
				}

				long Temp = sw.ElapsedMilliseconds;
				if (Temp - Time >= 1000)
				{
					m_Speed = (int)(Counter * 1000.0 / (Temp - Time));
					Time = Temp;
					Counter = 0;
				}
			}
		}

		private void ThreadHandle()
		{
			while (m_ThreadHandle != null)
			{
				string s = null;

				if (m_Queue.Count > 0)
				{
					lock (m_Queue)
					{
						int Count = m_Queue.Count;

						if (Count > 0)
						{
							if (Count > m_MaxQueue)
								m_MaxQueue = Count;
							s = m_Queue.Dequeue();
						}
					}
				}

				if (s != null)
				{
					string[] m = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (int.Parse(m[1]) > 100)
						m_Summ += int.Parse(m[2]);
				}
				else
					Thread.Sleep(1);
			}
		}

		#endregion

		#region Public

		public void Stop()
		{
			m_ThreadGenerate = null;
			m_ThreadHandle = null;
		}

		public void Print()
		{
			Console.WriteLine();
			Console.WriteLine("Summ: " + m_Summ);
			Console.WriteLine("Current Queue: " + m_Queue.Count);
			Console.WriteLine("Max queue: " + m_MaxQueue);
			Console.WriteLine("Speed: " + m_Speed);
		}

		#endregion
	}
}
