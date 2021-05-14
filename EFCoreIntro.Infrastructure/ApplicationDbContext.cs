using EFCoreIntro.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIntro.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Customer>()
                .Property(b => b.Id)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(b => b.Name)
                .IsRequired();
        }
    }
}
