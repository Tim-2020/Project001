using System.IO;
using System.Text;

namespace WFDebugging.Development.Console
{
    public class ConsoleWritter : TextWriter
    {
        #region Fields

        private static ConsoleWritter _Instance = null;
        private readonly IConsoleReceiver _Receiver;

        #endregion

        #region Constructor

        private ConsoleWritter(IConsoleReceiver currentReceiver)
        {
            _Receiver = currentReceiver;
            System.Console.SetOut(this);
        }

        #endregion

        #region Static

        public static void Initialize(IConsoleReceiver currentReceiver)
        {
            if (_Instance == null)
            {
                _Instance = new ConsoleWritter(currentReceiver);
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
            _Receiver.Put(new string(value, 1));
        }

        public override void Write(char[] buffer)
        {
            _Receiver.Put(new string(buffer));
        }

        public override void Write(string value)
        {
            _Receiver.Put(value);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            _Receiver.Put(new string(buffer, index, count));
        }

        #endregion
    }
}
