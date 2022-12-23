using Catstagram.Data.Common.Constants;
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

        public async Task<string> CreateTagAsync(string name)
        {
            var tag = await this.repository.GetByNameAsync(name);

            if (tag != null)
            {
                // TODO: throw if tag exists
            }

            await this.repository.AddAsync(new Tag() { Name = name });

            return ValidationMessages.TagCreatedSuccessfully;
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
