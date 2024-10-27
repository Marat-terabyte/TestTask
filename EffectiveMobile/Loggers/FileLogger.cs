using System.Text;

namespace EffectiveMobile.Loggers
{
    internal class FileLogger : ILogger
    {
        public string LogFile { get => "_deliveryLog"; }

        public void Log(string msg)
        {
            File.AppendAllText(LogFile, msg + '\n');
        }
    }
}
