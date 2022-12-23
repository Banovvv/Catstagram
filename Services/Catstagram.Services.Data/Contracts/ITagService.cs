using Catstagram.Data.Models;

namespace Catstagram.Services.Data.Contracts
{
    public interface ITagService
    {
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag?> GetByNameAsync(string name);
        Task<string> CreateTagAsync(string name);
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
