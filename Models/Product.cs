using System.ComponentModel.DataAnnotations;
namespace ProductsWithRouting.Models;
public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Enter a product name")]
    [StringLength(100)]
    public string Name { get; set; } = "";
    [Range(0, 1000000, ErrorMessage = "Price must not be negative")]
    public decimal Price { get; set; }
    [StringLength(1000)]
    public string Description { get; set; } = "";
    [Required]
    public string Category { get; set; } = "Other";
}
