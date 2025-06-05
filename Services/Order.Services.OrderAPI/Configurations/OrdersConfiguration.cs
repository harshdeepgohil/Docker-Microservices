using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Services.OrderAPI.Models;

namespace Order.Services.OrderAPI.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o=>o.ID);
            builder.Property(o => o.ID).ValueGeneratedOnAdd();

            builder.Property(o => o.ProductID);

            builder.Property(o=>o.ProName);

            builder.Property(o=>o.ProPrice);
            builder.Property(o=>o.OrderDate).HasDefaultValueSql("GETDATE()");


        }
    }
}
