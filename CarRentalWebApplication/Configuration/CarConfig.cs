using CarRentalWebApplication.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalWebApplication.Configuration
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(item => item.CarId);
            builder.Property(item => item.CarName).HasColumnName("CarName").IsRequired();
            builder.Property(item => item.CarPrice).HasColumnName("CarPrice").IsRequired();
            builder.Property(item => item.IsAvailable).HasColumnName("IsAvailable").HasDefaultValue(true);
        }
    }
}
