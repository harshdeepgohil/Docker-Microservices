using Microsoft.EntityFrameworkCore;
using Order.Services.OrderAPI.Configurations;
using Order.Services.OrderAPI.Models;

namespace Order.Services.OrderAPI.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
