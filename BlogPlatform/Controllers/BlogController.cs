using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: Blog
        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog); 
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return NotFound(); 
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var existingBlog = _context.Blogs.Find(blog.Id);
                if (existingBlog != null)
                {
                    existingBlog.Title = blog.Title;
                    existingBlog.Content = blog.Content;

                    _context.SaveChanges();
                    return RedirectToAction("Index"); 
                }
                ModelState.AddModelError("", "Blog not found."); 
            }
            return RedirectToAction("Index"); 
        }

        [HttpGet]
    public IActionResult Delete(int id)
    {
        var blog = _context.Blogs.Find(id);
        if (blog == null)
        {
            return NotFound();
        }
        
        _context.Blogs.Remove(blog);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
    }
}
