﻿using AutoFixture;
using AutoFixture.AutoMoq;
using Catstagram.Data.Common.Exceptions.Models;
using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data;
using Catstagram.Web.API.Tests.Utils;
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
            _fixture = TestHelper.SetupAutoFixture();

            _postRepository = _fixture.Freeze<Mock<IPostRepository>>();
            _postService = new PostService(_postRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllPosts()
        {
            //Assert
            var posts = _fixture.Build<Post>().CreateMany(5);
            _postRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(posts);

            //Act
            var result = await _postService.GetAllAsync();

            //Assert
            Assert.Equal(posts.Count(), result.Count());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsNoPosts()
        {
            //Assert
            var posts = _fixture.Build<Post>().CreateMany(0);
            _postRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(posts);

            //Act
            var result = await _postService.GetAllAsync();

            //Assert
            Assert.Equal(posts.Count(), result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_WithExistingPost_ReturnsAcurateResult()
        {
            //Assert
            var post = _fixture.Build<Post>().With(x => x.Id, 1).Create();
            _postRepository.Setup(x => x.GetByIdAsync(post.Id)).ReturnsAsync(post);

            //Act
            var result = await _postService.GetByIdAsync(post.Id);

            //Assert
            Assert.Equal(post.Id, result?.Id);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingPost_ThrowsNotFoundError()
        {
            //Assert
            var post = _fixture.Build<Post>().With(x => x.Id, 1).Create();
            _postRepository.Setup(x => x.GetByIdAsync(post.Id)).ReturnsAsync((Post?)null);

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _postService.GetByIdAsync(post.Id));
        }

        [Fact]
        public async Task GetByUserIdAsync_ReturnsAcurateResult()
        {
            //Assert
            var posts = _fixture.Build<Post>().With(x=>x.UserId, 1).CreateMany(5);
            _postRepository.Setup(x => x.GetByUserIdAsync(posts.First().UserId)).ReturnsAsync(posts);

            //Act
            var result = await _postService.GetByUserIdAsync(posts.First().UserId);

            //Assert
            Assert.Equal(posts.Count(), result.Count());
        }

        [Fact]
        public async Task GetByUserIdAsync_ThrowsNotFoundError()
        {
            //Assert
            _postRepository.Setup(x => x.GetByUserIdAsync(11)).ThrowsAsync(new NotFoundException());

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _postRepository.Object.GetByUserIdAsync(11));
        }

        [Fact]
        public void GetCount_ReturnsAccurateResult()
        {
            //Assert
            var posts = _fixture.Build<Post>().CreateMany(5);
            _postRepository.Setup(x => x.GetCount()).Returns(posts.Count);

            //Act
            var result = _postService.GetCount();

            //Assert
            Assert.Equal(posts.Count(), result);
        }

        [Fact]
        public async Task GetTopTenAsync_ReturnsAcurateResult()
        {
            //Assert
            var posts = _fixture.Build<Post>().CreateMany(15);
            _postRepository.Setup(x => x.GetTopTenAsync()).ReturnsAsync(posts.Take(10));

            //Act
            var result = await _postService.GetTopTenAsync();

            //Assert
            Assert.Equal(10, result.Count());
        }
    }
}
