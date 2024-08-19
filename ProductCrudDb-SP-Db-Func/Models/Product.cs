using System.ComponentModel.DataAnnotations;

public class Product{
    public int Id { get; set;}
    [StringLength(30,MinimumLength =3,ErrorMessage="Name must be between 3 to 30 chars")]
    [Required(ErrorMessage = "Name must be provided")]
    public string Name { get; set;}
    [Required(ErrorMessage="Price must be provided")]
    [Range(1,100000,ErrorMessage="Price must be between 1 to 100000")]
    public int Price { get; set; }
}