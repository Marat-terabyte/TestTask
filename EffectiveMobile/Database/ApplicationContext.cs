using EffectiveMobile.Database.Models;
using EffectiveMobile.Loggers;
using Microsoft.EntityFrameworkCore;

namespace EffectiveMobile.Database
{
    internal class ApplicationContext : DbContext
    {
        private string _dataSource = "EffectiveMobile.sqlite";
        private ILogger _logger;
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
            optionsBuilder.UseSqlite($"Data Source={_dataSource}");
            optionsBuilder.LogTo(_logger.Log, new[] { DbLoggerCategory.Database.Command.Name });
        }
    }
}
