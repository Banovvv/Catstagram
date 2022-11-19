using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
