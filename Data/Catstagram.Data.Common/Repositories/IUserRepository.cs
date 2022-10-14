using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface IUserRepository
    {
        int GetCount();
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
    }
}
