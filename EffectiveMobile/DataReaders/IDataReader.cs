using EffectiveMobile.Database.Models;

namespace EffectiveMobile.DataReaders
{
    internal interface IDataReader : IDisposable
    {
        ICollection<Order> GetOrders(string cityDistrict, DateTime first);
    }
}
