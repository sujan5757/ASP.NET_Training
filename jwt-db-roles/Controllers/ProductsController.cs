using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreJwtDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreJwtDb.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ProductManagementDbContext productManagementDbContext;
        public ProductsController(ProductManagementDbContext productManagementDbContext)
        {
            this.productManagementDbContext = productManagementDbContext;
        }
        // GET: api/values

        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productManagementDbContext.Products.ToList();
        }

        
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            
            return await this.productManagementDbContext.Products.Where(product => product.Id == id).FirstOrDefaultAsync();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            this.productManagementDbContext.Products.Add(product);
            this.productManagementDbContext.SaveChanges();
        }

        //[Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            this.productManagementDbContext.Products.Update(product);
            this.productManagementDbContext.SaveChanges();

        }

        //[Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.productManagementDbContext.Products.Remove(this.productManagementDbContext.Products.Where(product => product.Id == id).FirstOrDefault());
            this.productManagementDbContext.SaveChanges();
        }
    }
}

