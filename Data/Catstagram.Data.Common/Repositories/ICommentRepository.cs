using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        int GetCount();
        Task<Comment?> GetByIdAsync(int id);
        Task<IEnumerable<Comment>> GetAllByUserAsync(int id);
        Task<IEnumerable<Comment>> GetAllByPostAsync(int id);
    }
}
