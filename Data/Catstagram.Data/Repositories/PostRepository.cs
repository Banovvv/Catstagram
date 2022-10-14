using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;

namespace Catstagram.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(CatsDataContext context) : base(context)
        {
        }
    }
}
