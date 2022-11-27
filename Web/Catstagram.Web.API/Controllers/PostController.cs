using AutoMapper;
using Catstagram.Services.Data.Contracts;
using Catstagram.Web.API.Mapping.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.API.Controllers
{
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IPostService postService, IMapper mapper)
        {
            _mapper = mapper;
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PostResponseModel>>> GetAllAsync()
        {
            var posts = await _postService.GetAllAsync();

            var responsePosts = _mapper.Map<List<PostResponseModel>>(posts);

            return Ok(responsePosts);
        }

        [HttpGet("GetTopTen")]
        public async Task<ActionResult<IEnumerable<PostResponseModel>>> GetTopTenAsync()
        {
            var topTen = await _postService.GetTopTenAsync();

            var responsePosts = _mapper.Map<List<PostResponseModel>>(topTen);

            return Ok(responsePosts);
        }
    }
}
