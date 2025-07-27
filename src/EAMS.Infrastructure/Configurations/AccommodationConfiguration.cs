using EAMS.Domain.Constants;
using EAMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAMS.Infrastructure.Configurations
{
    public class AccommodationConfiguration : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.ToTable("Accommodations");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(AppConstants.Validation.MaxNameLength);
            builder.Property(e => e.Street).IsRequired().HasMaxLength(300);
            builder.Property(e => e.Suburb).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Postcode).IsRequired().HasMaxLength(10);
            builder.Property(e => e.State).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Region).HasMaxLength(100);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Email).HasMaxLength(AppConstants.Validation.MaxEmailLength);
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.Website).HasMaxLength(200);
            builder.Property(e => e.AccommodationType).HasMaxLength(100);
            builder.Property(e => e.Density).HasMaxLength(100);
            builder.Property(e => e.Duration).HasMaxLength(100);
            builder.Property(e => e.Inactive).HasDefaultValue(false);
        }
    }
}