using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<LoginViewModel> Login { get; set; }

    }
}
