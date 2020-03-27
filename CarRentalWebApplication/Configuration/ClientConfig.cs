using CarRentalWebApplication.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalWebApplication.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients").HasKey(item => item.ClientId);
            builder.Property(item => item.ClientName).HasColumnName("ClientName").IsRequired();
            builder.Property(item => item.ClientSurname).HasColumnName("ClientSurname").IsRequired();
            builder.Property(item => item.IdentificationNumber).HasColumnName("IdentificationNumber").IsRequired();
            builder.HasMany(item => item.Orders)
                .WithOne(oi => oi.Client)
                .HasForeignKey(oi => oi.ClientId);
        }
    }
}
