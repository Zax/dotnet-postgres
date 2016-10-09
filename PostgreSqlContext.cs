using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PostgresTestApplication
{

    public class PostgreSqlContext : DbContext
    {
        public DbSet<Anagrafe> Anagrafe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Program.Configuration == null)
                throw new System.Exception("Configurazione non trovata.");
            optionsBuilder.UseNpgsql(Program.Configuration.GetConnectionString("Default"));
        }
    }
}

