﻿using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface IPostRepository
    {
        int GetCount();
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Post>> GetByUsernameAsync(string username);
    }
}