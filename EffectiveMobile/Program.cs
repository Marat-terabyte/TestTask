using EffectiveMobile.Validators;
using EffectiveMobile.Loggers;
using EffectiveMobile.DataReaders;
using EffectiveMobile.DataReaders.Factories;
using EffectiveMobile.DataReaders.Database.Models;
using EffectiveMobile.ResultWriters;
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

            DataReaderFactory dataReaderFactory = new DbReaderFactory(logger);

            using IDataReader reader = dataReaderFactory.Create();
            ICollection<Order> orders = reader.GetOrders(cityDistrict, deliveryTime);

            using IResultWriter<Order> resultWriter = new FileResWriter(logger);
            resultWriter.Write(orders);
        }
    }
}
