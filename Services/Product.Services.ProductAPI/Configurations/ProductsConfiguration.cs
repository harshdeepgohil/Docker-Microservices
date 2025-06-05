using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Services.ProductAPI.Models;

namespace Product.Services.ProductAPI.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.ID);
            builder.Property(p=>p.ID).ValueGeneratedOnAdd();
                           

            builder.Property(p => p.Name);

            builder.Property(p => p.Description);

            builder.Property(p => p.Price);    

        }
    }
}
