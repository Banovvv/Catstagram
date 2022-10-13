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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
