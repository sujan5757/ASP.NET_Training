using System;
using Microsoft.EntityFrameworkCore;//1
namespace ProductCrudDb.Models
{
    public class ProductMgmtDbContext:DbContext//2
    {
        public ProductMgmtDbContext(DbContextOptions<ProductMgmtDbContext> dbContextOptions):base(dbContextOptions)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}

