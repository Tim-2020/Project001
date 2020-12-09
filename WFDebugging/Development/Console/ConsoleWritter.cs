using System.IO;
using System.Text;

namespace WFDebugging.Development.Console
{
	public class ConsoleWritter : TextWriter
	{
		private ConsoleWritter(IConsoleReceiver currentReceiver)
		{
			m_Receiver = currentReceiver;
			System.Console.SetOut(this);
		}

		#region Fields

		private static ConsoleWritter m_Instance = null;
		private readonly IConsoleReceiver m_Receiver;

		#endregion

		#region Static

		public static void Initialize(IConsoleReceiver currentReceiver)
		{
			if (m_Instance == null)
			{
				m_Instance = new ConsoleWritter(currentReceiver);
			}
		}

		#endregion

		#region Override

		public override Encoding Encoding
		{
			get
			{
				return Encoding.UTF8;
			}
		}

		public override void Write(char value)
		{
			m_Receiver.Put(new string(value, 1));
		}

		public override void Write(char[] buffer)
		{
			m_Receiver.Put(new string(buffer));
		}

		public override void Write(string value)
		{
			m_Receiver.Put(value);
		}

		public override void Write(char[] buffer, int index, int count)
		{
			m_Receiver.Put(new string(buffer, index, count));
		}

		#endregion
	}
}
