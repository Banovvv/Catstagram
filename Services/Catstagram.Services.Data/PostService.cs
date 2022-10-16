using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;

namespace Catstagram.Services.Data
{
    public class PostService : IPostService
    {
        private readonly IPostRepository repository;

        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> GetByUserIdAsync(int userId)
        {
            return await this.repository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Post>> GetByUsernameAsync(string username)
        {
            return await this.repository.GetByUsernameAsync(username);
        }

        public int GetCount()
        {
            return this.repository.GetCount();
        }
    }
}
