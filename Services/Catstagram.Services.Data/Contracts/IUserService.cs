using Catstagram.Data.Models;

namespace Catstagram.Services.Data.Contracts
{
    public interface IUserService
    {
        int GetCount();
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
    }
}
