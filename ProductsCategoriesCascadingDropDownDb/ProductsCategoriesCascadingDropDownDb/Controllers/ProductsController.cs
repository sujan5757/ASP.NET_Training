using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCrudDb.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCrudDb.Controllers
{
    public class ProductsController : Controller
    {
        ProductMgmtMvcAppDbContext db;//
        public ProductsController(ProductMgmtMvcAppDbContext productMgmtMvcAppDbContext)
        {
            //db = new ProductMgmtMvcAppDbContext();
            db=productMgmtMvcAppDbContext;
        }
        // GET: /<controller>/

        public IActionResult List()
        {
            ViewBag.Msg="Hello";
            ViewBag.Categories =new SelectList( db.Category.ToList(),"Id","Name");
            return View(db.Products.ToList());
        }
        
        public JsonResult GetProductsByCategoryId(int id)
        {
            var products = db.Products.Where(p => p.CategoryId.Equals(id)).ToList();
            return Json(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
            productCategoryViewModel.Categories = db.Category.ToList();
            productCategoryViewModel.Product = new Product();
            return View(productCategoryViewModel);
        }
        [HttpPost]
        public IActionResult Create([Bind("Name,Price,CategoryId")] Product product)
        {
            db.Products.Add(product);//no need of most of data access code 1.SqlConnection 2.SqlCommand object 
            db.SaveChanges();
            return RedirectToAction("List");
        }
        //[HttpGet]
        //public IActionResult Delete(Product product)
        //{
        //    Product product1 = db.Products.Where(p => p.Id == product.Id).FirstOrDefault();
        //    if (product1 != null)
        //    {
        //        db.Products.Remove(product1);
        //        db.SaveChanges();
        //    }
        //    return View("List",db.Products.ToList());
        //}
        

    }
}

