using Catstagram.Services.Data.Contracts;
using Catstagram.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
                { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
