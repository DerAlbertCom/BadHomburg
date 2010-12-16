using System.Data.Entity;
using System.Data.Entity.Database;
using BadHomburg.Models;

namespace BadHomburg.Data
{
    public class BadHomburgDbContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }

        public BadHomburgDbContext()
        {
        }

        public static void InitDatabase()
        {
            DbDatabase.DefaultConnectionFactory = 
                new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            DbDatabase.SetInitializer(new BadHomburgDatabase());
        }
    }

    public class BadHomburgDatabase :
        DropCreateDatabaseIfModelChanges<BadHomburgDbContext>
    {
        
    }
}