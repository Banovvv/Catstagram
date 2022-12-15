using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        int GetCount();
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag?> GetByNameAsync(string name);
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
