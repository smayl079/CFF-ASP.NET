namespace PracticeProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? SecondImageUrl { get; set; }

    public bool IsNew { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsFeatured { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
