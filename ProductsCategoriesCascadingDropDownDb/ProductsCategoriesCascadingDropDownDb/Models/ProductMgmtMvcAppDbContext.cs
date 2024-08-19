using System;
using Microsoft.EntityFrameworkCore;//
namespace ProductCrudDb.Models
{
    public class ProductMgmtMvcAppDbContext:DbContext
    {
        public ProductMgmtMvcAppDbContext(DbContextOptions<ProductMgmtMvcAppDbContext> dbContextOptions):
            base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}

