using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CatId { get; set; }
    
    [Required]
    [StringLength(100)]  
    public string CatName { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public Product Product { get; set; }
}
