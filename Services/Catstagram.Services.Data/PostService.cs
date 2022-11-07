using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;
using Catstagram.Services.Data.Models;

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

        public async Task<IEnumerable<PostHomeModel>> GetTopTenAsync()
        {
            var posts = await this.repository.GetTopTenAsync();
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
