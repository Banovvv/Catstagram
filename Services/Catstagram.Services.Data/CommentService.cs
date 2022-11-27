using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;

namespace Catstagram.Services.Data
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository repository;

        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Comment>> GetALLByPostAsync(int id)
        {
            return await this.repository.GetAllByPostAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetALLByUserAsync(int id)
        {
            return await this.repository.GetAllByUserAsync(id);
        }
    }
}
