namespace FiorelloClone.Models;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}
