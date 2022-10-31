using Catstagram.Data.Configurations.Constants;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catstagram.Data.Configurations
{
    internal class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> tag)
        {
            tag.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(ConfigurationConstants.TagNameMaxLength)
                .IsUnicode(true);
        }
    }
}
