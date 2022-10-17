using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catstagram.Data.Configurations
{
    internal class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment.Property(x => x.Text)
                .IsRequired(true)
                .HasMaxLength(250)
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
