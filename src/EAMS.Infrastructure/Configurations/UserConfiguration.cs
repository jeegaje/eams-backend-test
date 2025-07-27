using EAMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAMS.Infrastructure.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Role).HasConversion<string>().HasMaxLength(20);
            builder.Property(e => e.Jti);
            builder.Property(e => e.InvitationToken);
            builder.Property(e => e.InvitationAcceptedAt);
            builder.Property(e => e.PasswordChangedAt);
            builder.Property(e => e.PrimaryContact).HasDefaultValue(false);
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(e => e.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
  }
}