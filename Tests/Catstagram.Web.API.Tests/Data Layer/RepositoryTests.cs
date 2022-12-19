using AutoFixture;
using Catstagram.Data;
using Catstagram.Data.Models;
using Catstagram.Data.Repositories;
using Catstagram.Web.API.Tests.Utils;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Web.API.Tests.Repositories
{
    public class RepositoryTests
    {
        private readonly CatsDataContext _db;
        private readonly Repository<User> _repository;
        private IFixture _fixture;
        private readonly User _user;

        public RepositoryTests()
        {
            _fixture = TestHelper.SetupAutoFixture();

            _user = _fixture.Build<User>().Create();

            var options = new DbContextOptionsBuilder<CatsDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _db = new CatsDataContext(options);
            _db.Database.EnsureCreated();
            _db.Users.AddRange(_fixture.Build<User>().CreateMany(2));
            _db.SaveChanges();

            _repository = new Repository<User>(_db);
        }

        [Fact]
        public async Task AddAsync_WithGivenEntity_ShouldAddTheEntityToDb()
        {
            //Act
            await _repository.AddAsync(_user);
            await _db.SaveChangesAsync();

            var result = _repository.All();

            //Assert
            Assert.Equal(3, result.Count());
        }
    }
}
