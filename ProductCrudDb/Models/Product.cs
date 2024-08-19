using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCrudDb.Models
{
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Name should be 3 to 50 characters", MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Price { get; set; }

        [MfgDateValidation]
        public DateTime Mfg { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
