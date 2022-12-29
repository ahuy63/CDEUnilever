using CDEUnilever_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CDEUnilever_WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AppDbContext _context;
        public AuthenticationController(AppDbContext context)
        {
            _context = context;
        }
        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            bool Result = _context.Users.Any(user => user.UserName == username && user.Password == password);
            if (Result)
            {
                //Sử dụng một biến session để lưu Id người dùng hiện tại, đăng xuất thì mới xóa đi
                HttpContext.Session.SetInt32("UserId", _context.Users.Where(us => us.UserName == username).FirstOrDefault().Id);
                HttpContext.Session.SetString("UserFullName", _context.Users.Where(us => us.UserName == username).FirstOrDefault().FullName);

                return RedirectToAction("Index", "Home", new { area = "UserSection" });
            }
            ViewBag.MessLogin = "Wrong Username or Password";
            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserFullName");
            return RedirectToAction("Login", "Authentication");
        }
    }
}
