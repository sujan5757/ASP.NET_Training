using System;
namespace ProductCrudDb.Models
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}

