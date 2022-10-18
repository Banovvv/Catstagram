using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(CatsDataContext context) : base(context)
        {
        }

        public int GetCount()
        {
            return this.AllAsNoTracking().Count();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await this.DbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByPostIdAsync(int id)
        {
            return await this.DbSet
                .Where(x => x.PostId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByUserIdAsync(int id)
        {
            return await this.DbSet
                .Where(x => x.UserId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByUsernameAsync(string username)
        {
            return await this.DbSet
                .Include(x => x.User)
                .Where(x => x.User.Username == username)
                .ToListAsync();
        }
    }
}
