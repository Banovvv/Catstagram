using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface IUserRepository
    {
        int GetCount();
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetByUsernameAsync(string username);
    }
}
