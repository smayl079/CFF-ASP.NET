namespace PracticeProject.Models;

public class Slider
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Subtitle { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? ButtonText { get; set; }
    public string? ButtonUrl { get; set; }
}
