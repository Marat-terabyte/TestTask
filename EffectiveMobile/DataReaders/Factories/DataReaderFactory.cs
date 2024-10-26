using EffectiveMobile.Loggers;

namespace EffectiveMobile.DataReaders.Factories
{
    abstract class DataReaderFactory
    {
        protected ILogger _logger;

        public DataReaderFactory(ILogger logger)
        {
            _logger = logger;
        }

        public abstract IDataReader Create();
    }
}
