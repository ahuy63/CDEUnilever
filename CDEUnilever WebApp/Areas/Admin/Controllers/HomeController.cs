using Microsoft.AspNetCore.Mvc;

namespace CDEUnilever_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
