using AutoFixture;
using AutoFixture.AutoMoq;
using Catstagram.Data.Common.Repositories;
using Catstagram.Services.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private IFixture SetupAutoFixture()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture;
        }
    }
}
