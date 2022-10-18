using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(CatsDataContext context) : base(context)
        {
        }

        public int GetCount()
        {
            return this.AllAsNoTracking().Count();
        }


        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await this.DbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Tag?> GetByNameAsync(string name)
        {
            return await this.DbSet
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await this.DbSet
                .ToListAsync();
        }
    }
}
