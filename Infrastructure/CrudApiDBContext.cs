using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class CrudApiDBContext : DbContext
    {

        //To apply limitation to SQL Type like nvarchar 100 etc which are declared in Confugurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudApiDBContext).Assembly); // to add the configuration to SQL variables form the CONfiguratios folder.
                base.OnModelCreating(modelBuilder);
        }

        // after Adding construction and Dbset we need to add thr database connection string in AppSettings.json file.
        public CrudApiDBContext(DbContextOptions<CrudApiDBContext> options) : base(options) // this constructor is requried 
        {

        }

        public DbSet<Customer> Customers { get; set; } // This is requried to create tables insise the Database.
        public DbSet<Product> Products { get; set; } 
    }
}
