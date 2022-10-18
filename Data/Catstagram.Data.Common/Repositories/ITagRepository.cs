using Catstagram.Data.Models;

namespace Catstagram.Data.Common.Repositories
{
    public interface ITagRepository
    {
        int GetCount();
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag?> GetByNameAsync(string name);
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
