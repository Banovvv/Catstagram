using Catstagram.Data.Common.Exceptions.Models;
using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;
using Catstagram.Services.Data.Models;

namespace Catstagram.Services.Data
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public Task<string> CreatePostAsync(PostInputModel postInput)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);

            if (post == null)
            {
                throw new NotFoundException("Post not found!");
            }

            return post;
        }

        public async Task<IEnumerable<Post>> GetByUserIdAsync(int userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }

        public async Task<IEnumerable<Post>> GetTopTenAsync()
        {
            var posts = await _repository.GetTopTenAsync();

            return posts;
        }
    }
}
