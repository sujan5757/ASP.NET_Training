Custom Validation
Define  custome validation as shown below
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductCrudDb.Models
{
    public class MfgDateValidationAttribute:ValidationAttribute
    {
        public MfgDateValidationAttribute()
        {
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product =(Product) validationContext.ObjectInstance;
            if (product.Mfg > DateTime.Now)
            {
               return new ValidationResult("Mfg Date can't be a future date");

            }
            else
                return ValidationResult.Success;
        }
    }
}

Apply on Product model as shown below
[MfgDateValidation]
        public DateTime Mfg { get; set; }