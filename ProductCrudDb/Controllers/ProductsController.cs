using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCrudDb.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCrudDb.Controllers
{
    public class ProductsController : Controller
    {
        private ProductMgmtDbContext db;
        public ProductsController(ProductMgmtDbContext db)
        {
            this.db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return View("Index", db.Products.ToList());
            }
            else
            {
                return View(product);
            }
        }
    }
}

