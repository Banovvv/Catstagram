using Catstagram.Data.Configurations.Constants;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catstagram.Data.Configurations
{
    internal class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment.Property(x => x.Content)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.CommentTextMaxLength)
                .IsUnicode(true);

            comment.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            comment.Property(x => x.UserId)
                .IsRequired(true);

            comment.Property(x => x.PostId)
                .IsRequired(true);
        }
    }
}
