using CarRentalWebApplication.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalWebApplication.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(order => order.InvoiceNo);
            builder.Property(order => order.RentalStart).HasColumnName("RentalStart").IsRequired();
            builder.Property(order => order.RentalEnd).HasColumnName("RentalEnd").IsRequired();
            builder.Property(order => order.ClientId).HasColumnName("ClientId").IsRequired();
            builder.Property(order => order.CarId).HasColumnName("CarId").IsRequired();
        }
    }
}
