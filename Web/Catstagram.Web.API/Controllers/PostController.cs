using AutoMapper;
using Catstagram.Services.Data.Contracts;
using Catstagram.Services.Data.Models;
using Catstagram.Web.API.Mapping.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.API.Controllers
{
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly IValidator<PostInputModel> _validator;

        public PostController(IPostService postService, IMapper mapper, IValidator<PostInputModel> validator) 
        {
            _mapper = mapper;
            _validator = validator;
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

        [HttpPost("AddPost")]
        public async Task<IActionResult> CreatePostAsync([FromBody] PostInputModel postInput)
        {
            var validationResult = await _validator.ValidateAsync(postInput);

            if (!validationResult.IsValid)
            {

            }

            var createdPost = await _postService.CreatePostAsync(postInput);

            return Created(string.Empty, createdPost);
        }
    }
}
