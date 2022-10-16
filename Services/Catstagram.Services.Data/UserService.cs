using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;

namespace Catstagram.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await this.repository.GetByEmailAsync(email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await this.repository.GetByUsernameAsync(username);
        }

        public int GetCount()
        {
            return this.repository.GetCount();
        }
    }
}
