using EffectiveMobile.Database.Models;

namespace EffectiveMobile.Database.Repositories
{
    internal interface IOrderRepository : IDisposable
    {
        public ICollection<Order> GetOrders(string cityDistrict, DateTime firstDeliveryTime);
    }
}
