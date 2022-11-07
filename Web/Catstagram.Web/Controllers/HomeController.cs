using Catstagram.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _postService.GetAllAsync();

            return View(model);
        }
    }
}
