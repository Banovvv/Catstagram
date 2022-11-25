using AutoFixture;
using AutoMapper;
using Catstagram.Services.Data.Contracts;
using Catstagram.Web.API.Controllers;
using Catstagram.Web.API.Tests.Utils;
using Moq;

namespace Catstagram.Web.API.Tests.Controllers
{
    public class PostControllerTests
    {
        private IFixture _fixture;
        private readonly Mock<IMapper> _mapper;
        private readonly PostController _postController;
        private readonly Mock<IPostService> _postService;

        public PostControllerTests()
        {
            _fixture = TestHelper.SetupAutoFixture();
            _mapper = _fixture.Freeze<Mock<IMapper>>();
            _postService = _fixture.Freeze<Mock<IPostService>>();
            _postController = new PostController(_postService.Object, _mapper.Object);
        }
    }
}
