using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
