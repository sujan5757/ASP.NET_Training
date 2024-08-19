using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
public class ProductsController: Controller{
    private readonly ProductMgmtDbContext productMgmtDbContext;
    public ProductsController(ProductMgmtDbContext productMgmtDbContext)
    {
        this.productMgmtDbContext = productMgmtDbContext;
    }
    public ActionResult List()
    {
        return View(productMgmtDbContext.Products.FromSqlRaw("EXEC GetProducts").ToList());
    }
    [HttpGet]
    public ActionResult Create(){
        return View();
    }
    [HttpPost]
    public ActionResult Create(Product product){
        if(ModelState.IsValid){
        productMgmtDbContext.Database.ExecuteSqlRaw($"Exec uspCreateProduct {product.Name},{product.Price}");
        // productMgmtDbContext.Products.Add(product);
        // productMgmtDbContext.SaveChanges();
        return RedirectToAction("List");
        }
        else{
            return View(product);
        }
    }
    public  int GetProductCount()
{
        var connection = productMgmtDbContext.Database.GetDbConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT dbo.GetProductCount()";
        command.CommandType = System.Data.CommandType.Text;

        connection.Open();
        var result =  command.ExecuteScalar();
        connection.Close();

        return (int)result;
}

    [HttpGet]
    public ActionResult Edit(int id){
        var product=productMgmtDbContext.Products.Where(p=>p.Id==id).FirstOrDefault();  
        return View(product);
    }
    [HttpPost]
    public ActionResult Edit(Product product){
        productMgmtDbContext.Products.Update(product);
        productMgmtDbContext.SaveChanges();
        return RedirectToAction("List");
    }
    [HttpGet]
    public ActionResult Delete(int id){
        var product=productMgmtDbContext.Products.Where(p=>p.Id==id).FirstOrDefault();  
        productMgmtDbContext.Products.Remove(product);
        productMgmtDbContext.SaveChanges();
        return RedirectToAction("List");
    }
}