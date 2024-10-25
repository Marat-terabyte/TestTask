using EffectiveMobile.Database;
using EffectiveMobile.Database.Models;
using EffectiveMobile.Database.Repositories;
using EffectiveMobile.DataReaders;
using EffectiveMobile.Loggers;
using EffectiveMobile.ResultWriters;
using EffectiveMobile.Validators;
using System.Globalization;

namespace EffectiveMobile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();

            if (!InputValidator.TryValidate(args, out string? msg))
            {
                logger.Log($"error: {DateTime.Now} {msg!}");
                Console.WriteLine(msg);

                return;
            }

            string cityDistrict = args[0];
            string firstDelivDateTime = args[1] + ' ' + args[2];

            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTime deliveryTime = DateTime.ParseExact(firstDelivDateTime, "yyyy-MM-dd HH:mm:ss", culture);

            ApplicationContext context = new ApplicationContext(logger);
            IOrderRepository orderRepository = new OrderRepository(context, logger);
            
            using IDataReader reader = new DbReader(orderRepository);
            ICollection<Order> orders = reader.GetOrders(cityDistrict, deliveryTime);

            using IResultWriter<Order> resultWriter = new FileResWriter(logger);
            resultWriter.Write(orders);
        }
    }
}
