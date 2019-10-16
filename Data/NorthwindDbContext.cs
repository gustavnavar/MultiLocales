using MultiLocales.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiLocales.Data
{
    public class NorthwindDbContext : DbContext
    {

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderVM>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_Order");
            });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderVM> OrderVMs { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
