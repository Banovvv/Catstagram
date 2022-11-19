using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.API.Controllers
{
    [ApiController]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
