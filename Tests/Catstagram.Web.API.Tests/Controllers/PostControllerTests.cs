using AutoFixture;
using AutoMapper;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;
using Catstagram.Web.API.Controllers;
using Catstagram.Web.API.Mapping.Models;
using Catstagram.Web.API.Tests.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catstagram.Web.API.Tests.Controllers
{
    public class PostControllerTests
    {
        private IFixture _fixture;
        private readonly IMapper _mapper;
        private readonly PostController _postController;
        private readonly Mock<IPostService> _postService;

        public PostControllerTests()
        {
            _fixture = TestHelper.SetupAutoFixture();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(x =>
                {
                    x.CreateMap<Post, PostResponseModel>();
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _postService = _fixture.Freeze<Mock<IPostService>>();
            _postController = new PostController(_postService.Object, _mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllPosts()
        {
            var posts = _fixture.Build<Post>().CreateMany(5);
            _postService.Setup(x=>x.GetAllAsync()).ReturnsAsync(posts);

            var result = await _postController.GetAllAsync();
            
            var resultObject = TestHelper.GetObjectResultContent(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(posts.Count(), resultObject.Count());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsNoPosts()
        {
            var posts = _fixture.Build<Post>().CreateMany(0);
            _postService.Setup(x => x.GetAllAsync()).ReturnsAsync(posts);

            var result = await _postController.GetAllAsync();

            var resultObject = TestHelper.GetObjectResultContent(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(posts.Count(), resultObject.Count());
        }
    }
}
