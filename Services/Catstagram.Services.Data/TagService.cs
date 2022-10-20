using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;

namespace Catstagram.Services.Data
{
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;

        public TagService(ITagRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        public async Task<Tag?> GetByNameAsync(string name)
        {
            return await this.repository.GetByNameAsync(name);
        }
    }
}
