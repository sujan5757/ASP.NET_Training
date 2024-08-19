using Microsoft.AspNetCore.Mvc;

public class CategoriesController: Controller{
    private readonly ProductMgmtDbContext productMgmtDbContext;

    public CategoriesController(ProductMgmtDbContext productMgmtDbContext){
        this.productMgmtDbContext = productMgmtDbContext;
    }

    
    public ActionResult List(){
        return View(productMgmtDbContext.Categories.ToList());
    }

    [HttpGet]
    public ActionResult Create(){
        return View();
    }

    [HttpPost]
    public ActionResult Create(Category category){
        productMgmtDbContext.Categories.Add(category);
        productMgmtDbContext.SaveChanges();
        return RedirectToAction("List");
    }

    [HttpGet]
    public ActionResult Edit(int id){
        var cat = productMgmtDbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        return View(cat);
    }
    
    [HttpPost]
    public ActionResult Edit(Category category){
        productMgmtDbContext.Categories.Update(category);
        productMgmtDbContext.SaveChanges();
        return RedirectToAction("List");

    }

    [HttpGet]
    public ActionResult Delete(int id){
        var cat = productMgmtDbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        productMgmtDbContext.Categories.Remove(cat);
        productMgmtDbContext.SaveChanges();
        return RedirectToAction("List");

    }
}