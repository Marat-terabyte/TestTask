using EffectiveMobile.Validators;
using EffectiveMobile.Loggers;
using EffectiveMobile.DataReaders;
using EffectiveMobile.DataReaders.Factories;
using EffectiveMobile.DataReaders.Database.Models;
using EffectiveMobile.ResultWriters;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;

namespace EffectiveMobile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider provider = Startup.ConfigureServices();
            
            ILogger logger = provider.GetRequiredService<ILogger>();

            if (!InputValidator.TryValidate(args, out string? msg))
            {
                logger.Log($"error: {DateTime.Now} {msg!}");
                Console.WriteLine(msg);

                return;
            }

            string cityDistrict = args[0];
            string firstDelivDateTime = args[1] + ' ' + args[2];

            DateTime deliveryTime = DateTime.ParseExact(firstDelivDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DataReaderFactory dataReaderFactory = provider.GetRequiredService<DataReaderFactory>();

            using IDataReader reader = dataReaderFactory.Create();
            ICollection<Order> orders = reader.GetOrders(cityDistrict, deliveryTime);

            using IResultWriter<Order> resultWriter = provider.GetRequiredService<IResultWriter<Order>>();
            resultWriter.Write(orders);
        }
    }
}
