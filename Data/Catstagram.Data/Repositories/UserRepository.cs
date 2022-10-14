using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;

namespace Catstagram.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CatsDataContext context) : base(context)
        {
        }
    }
}
