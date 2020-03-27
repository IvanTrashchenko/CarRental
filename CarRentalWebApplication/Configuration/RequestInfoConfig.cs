using CarRentalWebApplication.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalWebApplication.Configuration
{
    public class RequestInfoConfig : IEntityTypeConfiguration<RequestInfo>
    {
        public void Configure(EntityTypeBuilder<RequestInfo> builder)
        {
            builder.ToTable("Requests").HasKey(item => item.RequestId);
            builder.Property(item => item.Comment).HasColumnName("Comment");
            builder.Property(item => item.IsDamaged).HasColumnName("IsDamaged").HasDefaultValue(false);
            builder.Property(item => item.IsApproved).HasColumnName("IsApproved").IsRequired();
            builder.Property(item => item.InvoiceNo).HasColumnName("InvoiceNo").IsRequired();
        }
    }
}
