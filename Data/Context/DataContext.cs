using CustomerPanel.Domain.Entity.Model;
using CustomerPanel.Data.Context.Structure;
using Microsoft.EntityFrameworkCore;

namespace CustomerPanel.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Telephone> Telephone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientStructure());
            modelBuilder.ApplyConfiguration(new TelephoneStructure());
        }
    }
}