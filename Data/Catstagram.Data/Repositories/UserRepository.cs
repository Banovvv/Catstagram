using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CatsDataContext context) : base(context)
        {
        }

        public int GetCount()
        {
            return this.AllAsNoTracking().Count();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.DbSet
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByIdAsync(int id)
        {
            return await this.DbSet
                .Where(x => x.Id == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByUsernameAsync(string username)
        {
            return await this.DbSet
                .Where(x => x.Username == username)
                .ToListAsync();
        }
    }
}
