using EffectiveMobile.DataReaders.Database.Models;

namespace EffectiveMobile.DataReaders.Database.Repositories
{
    internal interface IOrderRepository : IDisposable
    {
        public IEnumerable<Order> GetOrders(string cityDistrict, DateTime firstDeliveryTime);
    }
}
