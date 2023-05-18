using API.Modules.Services.Core;
using API.Modules.Clinets.Core;
using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public void InitDb()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Service> Services => Set<Service>();
        public DbSet<Worker> Workers => Set<Worker>();
    }
}
