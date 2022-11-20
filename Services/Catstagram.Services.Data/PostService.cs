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

        public async Task<IEnumerable<Post>> GetByUsernameAsync(string username)
        {
            return await _repository.GetByUsernameAsync(username);
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }

        public async Task<IEnumerable<PostHomeModel>> GetTopTenAsync()
        {
            var posts = await _repository.GetTopTenAsync();
            var postModels = new List<PostHomeModel>();

            foreach (var post in posts)
            {
                var postModel = new PostHomeModel()
                {
                    Id = post.Id,
                    Author = post.User.Username,
                    Caption = post.Caption,
                    Image = post.Image,
                    Likes = post.Likes.Count(),
                    TopComment = new CommentHomeModel()
                    {
                        Author = post.Comments.First()?.User.Username,
                        Content = post.Comments.First()?.Content
                    }
                };

                postModels.Add(postModel);
            }

            return postModels;
        }
    }
}
