using Catstagram.Data.Configurations;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data
{
    public class CatsDataContext : DbContext
    {
        public CatsDataContext()
        {
        }

        public CatsDataContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Like> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TagEntityTypeConfiguration().Configure(modelBuilder.Entity<Tag>());
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new PostEntityTypeConfiguration().Configure(modelBuilder.Entity<Post>());
            new LikeEntityTypeConfiguration().Configure(modelBuilder.Entity<Like>());
        }
    }
}
