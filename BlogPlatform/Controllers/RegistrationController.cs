using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Models;
using System.Linq;

namespace BlogPlatform.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly BlogDbContext _context;

        public RegistrationController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists
                var existingUser = _context.Blogs.FirstOrDefault(b => b.Title == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email already registered.");
                    return View(model);
                }

                // Save new user
                var newBlog = new Blog
                {
                    Title = model.Email,
                    Content = model.Password // For demonstration purposes; in a real app, store hashed passwords
                };
                _context.Blogs.Add(newBlog);
                _context.SaveChanges();

                // Redirect to login page
                return RedirectToAction("Login", "Registration");
            }

            return View(model);
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
                var user = _context.Blogs.FirstOrDefault(b => b.Title == model.Email && b.Content == model.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Blog");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
