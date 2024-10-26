using EffectiveMobile.DataReaders.Database.Repositories;
using EffectiveMobile.DataReaders.Database;
using EffectiveMobile.Loggers;

namespace EffectiveMobile.DataReaders.Factories
{
    internal class DbReaderFactory : DataReaderFactory
    {
        public DbReaderFactory(ILogger logger) : base(logger)
        {
        }

        public override IDataReader Create()
        {
            ApplicationContext context = new ApplicationContext(_logger);
            IOrderRepository orderRepository = new OrderRepository(context, _logger);

            return new DbReader(orderRepository);
        }
    }
}
