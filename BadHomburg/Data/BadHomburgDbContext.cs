using System.Data.Entity;
using System.Data.Entity.Database;
using BadHomburg.Models;
using System.Web;

namespace BadHomburg.Data
{
    public class BadHomburgDbContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }

        public BadHomburgDbContext() : base(GetConnetionString())
        {
        }

        public static void InitDatabase()
        {
            DbDatabase.DefaultConnectionFactory =
                new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            DbDatabase.SetInitializer(new BadHomburgDatabase());
        }

        public static string GetConnetionString()
        {
            var path = HttpContext.Current.Request.MapPath("~/App_Data/BadHomburg.sdf");
            return string.Format("Data Source={0}", path);
        }
    }

    public class BadHomburgDatabase :
        DropCreateDatabaseIfModelChanges<BadHomburgDbContext>
    {
        protected override void Seed(BadHomburgDbContext dbContext)
        {
            base.Seed(dbContext);

            dbContext.Personen.Add(new Person {Anrede = "Herr", Nachname = "Weinert", Vorname = "Albert", Geburtsjahr=1981});
            dbContext.Personen.Add(new Person {Anrede = "Frau", Nachname = "Schmitz", Vorname = "Verena", Geburtsjahr=1974});
            dbContext.Personen.Add(new Person {Anrede = "Herr", Nachname = "Lange", Vorname = "Stefan", Geburtsjahr=1999});
            dbContext.SaveChanges();
        }
    }
}