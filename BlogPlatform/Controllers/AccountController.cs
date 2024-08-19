using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Models;
using System.Linq;

namespace BlogPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlogDbContext _context;

        public AccountController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists (for demonstration purposes, just checking email)
                var user = _context.Blogs.FirstOrDefault(b => b.Title == model.Email && b.Content == model.Password);

                if (user != null)
                {
                    // Redirect to Index page if login is successful
                    return RedirectToAction("Index", "Blog");
                }
                
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
