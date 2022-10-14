using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catstagram.Data.Configurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasIndex(x => x.Username)
                .IsUnique();

            user.HasIndex(x => x.Email)
                .IsUnique();

            user.Property(x => x.Username)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            user.Property(x => x.Email)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            user.Property(x => x.Password)
                .IsRequired(true)
                .HasMaxLength(75)
                .IsUnicode(true);

            user.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            user.Property(x => x.LastName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            user.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            user.Property(x => x.LastUpdatedOn)
                .IsRequired(false);
        }
    }
}
