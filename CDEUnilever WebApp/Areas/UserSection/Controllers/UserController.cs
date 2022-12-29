using CDEUnilever_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDEUnilever_WebApp.Models;

namespace CDEUnilever_WebApp.Areas.UserSection.Controllers
{
    [Area("UserSection")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [Route("/UserInfo")]
        public async Task<IActionResult> UserInfo()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Route("/EditUserInfo")]
        public async Task<IActionResult> EditUserInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Route("/EditUserInfo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserInfo (int id, string fullname, string phone, string address)
        {
            var user = new User() { Id = id, FullName = fullname, Address = address, Phone = phone };
            _context.Attach(user);
            _context.Entry(user).Property(u => u.FullName).IsModified = true;
            _context.Entry(user).Property(u => u.Address).IsModified = true;
            _context.Entry(user).Property(u => u.Phone).IsModified = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserInfo));
        }
            
        [Route("/EditUserPassword")]
        public async Task<IActionResult> EditUserPassword(int id)
        {
            //int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            return View(user);
        }

        [Route("/EditUserPassword")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserPassword(int id, string newPassword)
        {
            var user = new User() { Id = id, Password = newPassword };
            _context.Attach(user);
            _context.Entry(user).Property(u => u.Password).IsModified = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserInfo));
        }
    }
}
