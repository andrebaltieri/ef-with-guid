using EFWithGuid.Mapping;
using EFWithGuid.Models;
using System.Data.Entity;

namespace EFWithGuid.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base("AppConnectionString")
        {
            Database.SetInitializer<AppDbContext>(new AppDbContextInitializer());
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class AppDbContextInitializer : DropCreateDatabaseAlways<AppDbContext>
    {

    }
}
