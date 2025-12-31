namespace PracticeProject.Models;

public class HomeViewModel

{
    public List<Slider> Sliders { get; set; } = new();
    public List<Category> Categories { get; set; } = new();

    public List<Product> NewProducts { get; set; } = new();
    public List<Product> BestSellerProducts { get; set; } = new();
    public List<Product> FeaturedProducts { get; set; } = new();
}
