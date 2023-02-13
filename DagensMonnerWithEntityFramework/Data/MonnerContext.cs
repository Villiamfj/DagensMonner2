using Microsoft.EntityFrameworkCore;
using DagensMonnerWithEntityFramework.Models;
using Microsoft.Extensions.Configuration;

namespace DagensMonnerWithEntityFramework.Data
{
    public class MonnerContext : DbContext
    {
        public DbSet<Monner> Monners { get; set; }
        public DbSet<LogState> LogStates { get; set; }

        private string connectionString { get; }

        public MonnerContext(string connectionstring)
        {
            connectionString = connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
