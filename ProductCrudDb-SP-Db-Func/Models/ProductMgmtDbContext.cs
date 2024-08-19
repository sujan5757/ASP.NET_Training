using Microsoft.EntityFrameworkCore;

public class ProductMgmtDbContext:DbContext{
    public ProductMgmtDbContext(DbContextOptions<ProductMgmtDbContext> options) : base(options) { }
    public DbSet<Product> Products { get;set; }
}