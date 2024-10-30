using EffectiveMobile.DataReaders.Database.Models;
using EffectiveMobile.DataReaders.Factories;
using EffectiveMobile.Loggers;
using EffectiveMobile.ResultWriters;
using Microsoft.Extensions.DependencyInjection;

namespace EffectiveMobile
{
    internal class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ILogger, FileLogger>();
            services.AddScoped<DataReaderFactory, DbReaderFactory>();
            services.AddScoped<IResultWriter<Order>, FileResWriter>();

            return services.BuildServiceProvider();
        }
    }
}
