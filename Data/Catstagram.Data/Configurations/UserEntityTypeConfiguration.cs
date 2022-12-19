using Catstagram.Data.Configurations.Constants;
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
                .HasMaxLength(ConfigurationConstants.UserUsernameMaxLength)
                .IsUnicode(true);

            user.Property(x => x.Email)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.UserEmailMaxLength)
                .IsUnicode(true);

            user.Property(x => x.Password)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.UserPasswordMaxLength)
                .IsUnicode(true);

            user.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.UserFirstNameMaxLength)
                .IsUnicode(true);

            user.Property(x => x.LastName)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.UserLastNameMaxLength)
                .IsUnicode(true);

            user.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            user.Property(x => x.LastUpdatedOn)
                .IsRequired(false);

            user.HasMany(x => x.Likes)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            user.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
