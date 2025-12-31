namespace FrontToBack.Models;

public class OurWork : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Description { get; set; } = null!;
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}
