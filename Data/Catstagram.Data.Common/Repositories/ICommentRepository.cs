using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface ICommentRepository
    {
        int GetCount();
        Task<Comment?> GetByIdAsync(int id);
        Task<IEnumerable<Comment>> GetAllByUserAsync(string username);
        Task<IEnumerable<Comment>> GetAllByUserAsync(int id);
        Task<IEnumerable<Comment>> GetAllByPostAsync(int id);
    }
}
