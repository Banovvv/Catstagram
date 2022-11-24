using Catstagram.Data.Common.Exceptions.Models;
using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(CatsDataContext context) : base(context)
        {
        }

        public int GetCount()
        {
            return this.AllAsNoTracking().Count();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await this.DbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await this.DbSet
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetByUserIdAsync(int userId)
        {
            return await this.DbSet
                .Where(x => x.UserId == userId)
                .ToListAsync() ?? throw new NotFoundException("User not found!");
        }

        public async Task<IEnumerable<Post>> GetByUsernameAsync(string username)
        {
            return await this.DbSet
                .Include(x => x.User)
                .Where(x => x.User.Username == username)
                .ToListAsync() ?? throw new NotFoundException("User not found!");
        }

        public async Task<IEnumerable<Post>> GetTopTenAsync()
        {
            return await this.DbSet
                .Include(x => x.User)
                .Include(x => x.Likes)
                .Include(x => x.Comments)
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .ToListAsync();
        }
    }
}
