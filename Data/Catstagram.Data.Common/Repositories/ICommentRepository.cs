using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface ICommentRepository
    {
        int GetCount();
        Task<Comment?> GetByIdAsync(int id);
        Task<IEnumerable<Comment>> GetAllByUsernameAsync(string username);
        Task<IEnumerable<Comment>> GetAllByUserIdAsync(int id);
        Task<IEnumerable<Comment>> GetAllByPostIdAsync(int id);
    }
}
