using Catstagram.Data.Configurations.Constants;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catstagram.Data.Configurations
{
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post.Property(x => x.Caption)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.PostCaptionMaxLength)
                .IsUnicode(true);

            post.Property(x => x.Image)
                .IsRequired(true);

            post.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            post.Property(x => x.LastUpdatedOn)
                .IsRequired(false);

            post.Property(x => x.UserId)
                .IsRequired(true);

            post.HasMany(x => x.Likes)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.ClientSetNull);

            post.HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
