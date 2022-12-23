using Catstagram.Data.Common.Constants;
using Catstagram.Data.Common.Exceptions.Models;
using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;
using Catstagram.Services.Data.Models;

namespace Catstagram.Services.Data
{
    public class PostService : IPostService
    {
        private readonly ITagService _tagService;
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository,
                           ITagService tagService)
        {
            _repository = repository;
            _tagService = tagService;
        }

        public async Task<string> CreatePostAsync(PostInputModel postInput)
        {
            var post = new Post()
            {
                Caption = postInput.Caption,
                UserId = postInput.UserId,
                CreatedOn = DateTime.UtcNow,
                LastUpdatedOn = DateTime.UtcNow
            };

            foreach (var tagInput in postInput.Tags)
            {
                var tag = await _tagService.GetByNameAsync(tagInput);

                if (tag == null)
                {
                    //TODO: add the tag
                }
            }

            await _repository.AddAsync(post);

            return ValidationMessages.PostCreatedSuccessfully;
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
                throw new NotFoundException(ValidationMessages.PostNotFoud);
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
