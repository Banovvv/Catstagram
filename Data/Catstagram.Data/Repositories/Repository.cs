using Catstagram.Data.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private bool disposedValue;

        public Repository(CatsDataContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }
        protected CatsDataContext Context { get; set; }

        public Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public IQueryable<TEntity> All() => this.DbSet;

        public IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public void Delete(TEntity entity) => this.DbSet.Remove(entity);
        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Context?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
