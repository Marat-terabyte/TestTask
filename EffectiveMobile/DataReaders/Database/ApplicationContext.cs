using EffectiveMobile.DataReaders.Database.Models;
using EffectiveMobile.Loggers;
using Microsoft.EntityFrameworkCore;

namespace EffectiveMobile.DataReaders.Database
{
    internal class ApplicationContext : DbContext
    {
        private ILogger _logger;

        public string DataSource { get => "EffectiveMobile.sqlite"; }

        public DbSet<Order> Orders
        {
            get => Set<Order>();
        }

        public ApplicationContext(ILogger logger)
        {
            _logger = logger;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DataSource}");
            optionsBuilder.LogTo(_logger.Log, new[] { DbLoggerCategory.Database.Command.Name });
        }
    }
}
