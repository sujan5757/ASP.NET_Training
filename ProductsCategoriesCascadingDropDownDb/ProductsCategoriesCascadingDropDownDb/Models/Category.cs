using System;
namespace ProductCrudDb.Models
{
    public class Category
    {
        public Category()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }//Collection navigation property: A navigation property that contains references to many related entities.
    }
}

