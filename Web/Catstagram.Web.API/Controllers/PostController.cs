using Catstagram.Data.Common.Repositories;
using Catstagram.Data.Models;
using Catstagram.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.API.Controllers
{
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllAsync()
        {
            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }

        [HttpGet("GetTopTen")]
        public async Task<ActionResult<IEnumerable<Post>>> GetTopTenAsync()
        {
            var topTen = await _postService.GetTopTenAsync();

            return Ok(topTen);
        }
    }
}
