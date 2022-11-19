using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.API.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
