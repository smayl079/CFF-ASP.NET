namespace FiorelloClone.Models;

public class ProductDetail : BaseEntity
{
    public string? Description { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

}
