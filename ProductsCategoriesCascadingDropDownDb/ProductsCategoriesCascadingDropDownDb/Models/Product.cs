using System;
using System.Reflection.Metadata;

namespace ProductCrudDb.Models
{
    public class Product
    {
        public Product()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        
        public int CategoryId { get; set; }//foreign key
        public Category? Category { get; set; }//reference navigation property
    }
}

