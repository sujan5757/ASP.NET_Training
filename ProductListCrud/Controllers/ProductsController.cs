using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class ProductsController : Controller
{
    private static List<Product> products = new List<Product>()
    {
        new Product { Name = "1", Prod = "pen", Cost = 25 },
        new Product { Name = "2", Prod = "pencil", Cost = 5 },
        new Product { Name = "3", Prod = "eraser", Cost = 4 }
    };

    public ActionResult List()
    {
        return View(products);
    }
    
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Product product)
    {
        products.Add(product);
        return View("List", products);
    }

    [HttpGet]
    public ActionResult Edit(string name)
    {
        var product = products.Where(p => p.Name == name).FirstOrDefault();
        return View(product);
    }
    
    [HttpPost]
    public ActionResult Edit(Product product)
    {
        var pro = products.Where(p => p.Name == product.Name).FirstOrDefault();
        pro.Prod = product.Prod;
        pro.Cost = product.Cost;
        return View("List", products);
    }
    [HttpGet]
    public ActionResult Delete(string name)
    {
    var product = products.Where(p => p.Name == name).FirstOrDefault();
    
    if (product != null)
    {
        products.Remove(product);
    }

    return View("List", products);
    }
}
