using CDEUnilever_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDEUnilever_WebApp.Models;

namespace CDEUnilever_WebApp.Areas.UserSection.Controllers
{
    [Area("UserSection")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) 
        {
            _context = context;
        }
        [Route("/Home")]
        public async Task<IActionResult> Index()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            return View(user);
        }
    }
}
