using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace hm10.DataBase
{

    public class CalculatedExpressionsContext : DbContext
    {
        private const string ConnectionString =
            "Data Source=localhost;Initial Catalog=catttttalog;Integrated Security=True";

        private readonly ILoggerFactory _loggerFactory =
            LoggerFactory.Create(config => config.AddConsole());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<CalculatedExpression> Expressions { get; set; }
    }
}