using EffectiveMobile.Database.Models;
using EffectiveMobile.Database.Repositories;

namespace EffectiveMobile.DataReaders
{
    internal class DbReader : IDataReader
    {
        private bool _disposed = false;
        
        private IOrderRepository _orderRepository;

        public DbReader(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public ICollection<Order> GetOrders(string cityDistrict, DateTime firstDeliveryTime) => _orderRepository.GetOrders(cityDistrict, firstDeliveryTime);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _orderRepository.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
