using EffectiveMobile.DataReaders.Database.Models;

namespace EffectiveMobile.DataReaders
{
    internal interface IDataReader : IDisposable
    {
        IEnumerable<Order> GetOrders(string cityDistrict, DateTime first);
    }
}
