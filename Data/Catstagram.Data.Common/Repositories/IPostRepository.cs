﻿using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        int GetCount();
        Task<Post?> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetTopTenAsync();
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Post>> GetByUsernameAsync(string username);
    }
}
