using Microsoft.EntityFrameworkCore;
using Product.Services.ProductAPI.Configurations;
using Product.Services.ProductAPI.Models;

namespace Product.Services.ProductAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public  DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
