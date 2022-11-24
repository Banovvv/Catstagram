using Catstagram.Data.Models;
using Catstagram.Services.Data.Models;

namespace Catstagram.Services.Data.Contracts
{
    public interface IPostService
    {
        int GetCount();
        Task<Post?> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetTopTenAsync();
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Post>> GetByUsernameAsync(string username);
    }
}
