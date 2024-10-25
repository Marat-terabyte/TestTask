using System.Text;

namespace EffectiveMobile.Loggers
{
    internal class FileLogger : ILogger
    {
        private bool _disposed;

        private string _logFile = "_deliveryLog";

        public FileLogger()
        {
            _disposed = false;
        }

        public void Log(string msg)
        {
            File.AppendAllText(_logFile, msg + '\n');
        }
    }
}
