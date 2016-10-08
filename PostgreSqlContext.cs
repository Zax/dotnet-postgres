using Microsoft.EntityFrameworkCore;

namespace PostgresTestApplication
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options){}
        public DbSet<Anagrafe> Anagrafe { get; set; }
    }
}

