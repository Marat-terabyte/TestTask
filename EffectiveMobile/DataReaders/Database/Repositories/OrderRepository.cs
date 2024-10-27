using EffectiveMobile.DataReaders.Database.Models;
using EffectiveMobile.Loggers;

namespace EffectiveMobile.DataReaders.Database.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private bool _disposed;

        private ApplicationContext _context;
        private ILogger _logger;

        public OrderRepository(ApplicationContext context, ILogger logger)
        {
            _disposed = false;
            _context = context;
            _logger = logger;
        }

        public ICollection<Order> GetOrders(string cityDistrict, DateTime firstDeliveryTime)
        {
            try
            {
                _logger.Log($"info: {DateTime.Now} Getting orders from the database");

                return FetchOrders(cityDistrict, firstDeliveryTime);
            }
            catch (Exception ex)
            {
                _logger.Log($"error: {DateTime.Now} {ex.Message}");

                return new List<Order>(0);
            }
        }

        private ICollection<Order> FetchOrders(string cityDistrict, DateTime firstDeliveryTime)
        {
            var orders = from o in _context.Orders
                         where o.CityDistrict == cityDistrict
                         && firstDeliveryTime <= o.DeliveryTime
                         && firstDeliveryTime.AddMinutes(30) >= o.DeliveryTime
                         orderby o.DeliveryTime
                         select o;

            return orders.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
