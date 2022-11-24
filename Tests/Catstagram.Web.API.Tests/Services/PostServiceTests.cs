using AutoFixture;
using AutoFixture.AutoMoq;
using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data;
using Moq;

namespace Catstagram.Web.API.Tests.Services
{
    public class PostServiceTests
    {
        private IFixture _fixture;
        private readonly PostService _postService;
        private readonly Mock<IPostRepository> _postRepository;

        public PostServiceTests()
        {
            _fixture = SetupAutoFixture();

            _postRepository = _fixture.Freeze<Mock<IPostRepository>>();
            _postService = new PostService(_postRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllArticles()
        {
            var posts = _fixture.Build<Post>().CreateMany(5);

            _postRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(posts);

            //Act
            var result = await _postService.GetAllAsync();

            //Assert
            Assert.Equal(posts.Count(), result.Count());
        }

        private IFixture SetupAutoFixture()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture;
        }
    }
}
